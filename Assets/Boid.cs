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

        //������� ��������� �������
        pos = Random.insideUnitSphere * Spawner.S.spawnRadius;  // insideUnitSphere - ����� ������ ����� r=1

        //������� ��������� ��������� ��������
        Vector3 vel = Random.onUnitSphere * Spawner.S.velocity;         //onUnitSphere - ����� �� ����������� ����� r=1
        rigid.velocity = vel;

        LookAhead();

        //����� ������������ � ���� �������� �� ����� �������
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
       
        //�������������� ������������ - �������� ������� �������
        Vector3 velAvoid = Vector3.zero;
        Vector3 tooClosePos = neighborhood.avgClosePos;
        //���� ������� Vector3.zero �� ������ ������������� �� �����
        if (tooClosePos!=Vector3.zero)
        {
            velAvoid = pos - tooClosePos;
            velAvoid.Normalize();
            velAvoid *= spn.velocity;
        }

        //������������� �������� - ����������� ����������� �������� � ��������
        Vector3 velAlign = neighborhood.avgVel;
        //������������ ��������� ���� velAlign �� ����� Vector3.zero
        if (velAlign!=Vector3.zero)
        {
            velAlign.Normalize();
            velAlign *= spn.velocity;
        }

        //������������ ������� - �������� � ������� ������ �������
        Vector3 velCenter = neighborhood.avgPos;
        if (velCenter != Vector3.zero)
        {
            velCenter -= transform.position;
            velCenter.Normalize();
            velCenter *= spn.velocity;
        }


        //���������� ���������� �������� � Attractor
        Vector3 delta = Attractor.POS - pos;
        //��������� ���� ��������� � ������� attractor ��� �� ����
        bool attracted = (delta.magnitude > spn.attractPushDist);
        Vector3 velAttract = delta.normalized * spn.velocity;

        //��������� ��� ��������
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

        //���������� vel � ������������ � velocity spawner
        vel = vel.normalized * spn.velocity;

        //��������� ��������
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
