using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    [Header("Set Dinamicaly")]
    public Rigidbody rigid;
    private Neighborhood neighborhood;
    

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        neighborhood = GetComponent<Neighborhood>();

        //выберем случайную позицию
        pos = Random.insideUnitSphere * Spawner.S.spawnRadius;  // insideUnitSphere - точка внутри сферы r=1

        //выберем случайную начальную скорость
        Vector3 vel = Random.onUnitSphere * Spawner.S.velocity;         //onUnitSphere - точка на поверхности сферы r=1
        rigid.velocity = vel;

        LookAhead();

        //птица окрашивается в цвет отличный от очень темного
        Color randColor =Color.black;
        while ((randColor.r+randColor.g+randColor.b)<1.0f)
        {
            randColor = new Color(Random.value, Random.value, Random.value);
        }

        Renderer[] rends = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rends)
        {
            r.material.color = randColor;
        }
        TrailRenderer tRend = gameObject.GetComponent<TrailRenderer>();
        tRend.material.SetColor("_TintColor", randColor);
    }
    private void FixedUpdate()
    {
        Vector3 vel = rigid.velocity;
        Spawner spn = Spawner.S;
       
        //ПРЕДОТВРАЩЕНИЕ СТОЛКНОВЕНИЙ - избегать близких соседей
        Vector3 velAvoid = Vector3.zero;
        Vector3 tooClosePos = neighborhood.avgClosePos;
        //если получен Vector3.zero то ничего предпринимать не нужно
        if (tooClosePos!=Vector3.zero)
        {
            velAvoid = pos - tooClosePos;
            velAvoid.Normalize();
            velAvoid *= spn.velocity;
        }

        //СОГЛАСОВЫВАЕМ СКОРОСТИ - попробовать согласовать скорость с соседями
        Vector3 velAlign = neighborhood.avgVel;
        //согласование требуется если velAlign не равен Vector3.zero
        if (velAlign!=Vector3.zero)
        {
            velAlign.Normalize();
            velAlign *= spn.velocity;
        }

        //КОНЦЕНТРАЦИЯ СОСЕДЕЙ - движение в сторону центра соседей
        Vector3 velCenter = neighborhood.avgPos;
        if (velCenter != Vector3.zero)
        {
            velCenter -= transform.position;
            velCenter.Normalize();
            velCenter *= spn.velocity;
        }


        //ПРИТЯЖЕНИЕ организуем движение к Attractor
        Vector3 delta = Attractor.POS - pos;
        //проверить куда двигаться в сторону attractor или от него
        bool attracted = (delta.magnitude > spn.attractPushDist);
        Vector3 velAttract = delta.normalized * spn.velocity;

        //применить все скорости
        float fdt = Time.fixedDeltaTime;

        //
        if (velAvoid != Vector3.zero)
        {
            vel = Vector3.Lerp(vel, velAvoid, spn.collAvoid * fdt);
        }
        else
        {
            if (velAlign != Vector3.zero)
            {
                vel = Vector3.Lerp(vel, velAlign, spn.velMatching * fdt);
            }
            if (velCenter != Vector3.zero)
            {
                vel = Vector3.Lerp(vel, velAlign, spn.flockCentring * fdt);
            }
            if (velAttract != Vector3.zero)
            {
                if (attracted)
                {
                    vel = Vector3.Lerp(vel, velAttract, spn.attractPull * fdt);

                }


                else
                {
                    vel = Vector3.Lerp(vel, -velAttract, spn.attractPush * fdt);
                }
            }
        }

        //установить vel в соответствии с velocity spawner
        vel = vel.normalized * spn.velocity;

        //присвоить скорость
        rigid.velocity = vel;
        LookAhead();
    }

    void LookAhead()
    {
        transform.LookAt(pos + rigid.velocity);
    }
    public Vector3 pos
    {
        get { return transform.position; }
        set { transform.position = value; }
    }
    
}
