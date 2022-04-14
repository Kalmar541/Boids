using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Этот класс демонстриует спользование шаблона "Одиночка".
    //Может существовать только дин экземпляр класса Spawner
    //Он сохранен в переменной S.

    //эти поля настривают порядок создания Boid экземпляров
    static public Spawner S;
    static public List<Boid> boids;
    [Header("Set in inspector: Spawner")]
    public GameObject boidPrefab;
    public Transform boidAnchor;
    public int numBoids = 100;
    public float spawnRadius = 100;
    public float spawnDelay = 0.1f;

    [Header("Set in inspector: Boid")]
    public float velocity = 30f;        // ускорение
    public float nighborDist=30f;       // радиус опроса соседей
    public float collDist = 4f;         // растояние до соседа
    public float velMatching=0.25f;     //сплоченость движения
    public float flockCentring = 0.2f;  // группировка среди соседей
    public float collAvoid = 2;
    public float attractPull = 2;       // притяжание цели
    public float attractPush = 2;       // отталкивание цели
    public float attractPushDist = 5;   //минимальное расстояние отталкивания от аттрактора



    private void Awake()
    {
        //сохраним экземпляр в Spawner S
        S = this;
        //запустить создание обьектов boid
        boids = new List<Boid>();
        InstatiateBoid();
    }
    public void InstatiateBoid()
    {
        GameObject go = Instantiate(boidPrefab);
        Boid b = go.GetComponent<Boid>();
        b.transform.SetParent(boidAnchor);
        boids.Add(b);
        if (boids.Count<numBoids)
        {
            Invoke("InstatiateBoid", spawnDelay);
        }

    }
    
}
