using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //���� ����� ������������ ������������ ������� "��������".
    //����� ������������ ������ ��� ��������� ������ Spawner
    //�� �������� � ���������� S.

    //��� ���� ���������� ������� �������� Boid �����������
    static public Spawner S;
    static public List<Boid> boids;
    [Header("Set in inspector: Spawner")]
    public GameObject boidPrefab;
    public Transform boidAnchor;
    public int numBoids = 100;
    public float spawnRadius = 100;
    public float spawnDelay = 0.1f;

    [Header("Set in inspector: Boid")]
    public float velocity = 30f;        // ���������
    public float nighborDist=30f;       // ������ ������ �������
    public float collDist = 4f;         // ��������� �� ������
    public float velMatching=0.25f;     //����������� ��������
    public float flockCentring = 0.2f;  // ����������� ����� �������
    public float collAvoid = 2;
    public float attractPull = 2;       // ���������� ����
    public float attractPush = 2;       // ������������ ����
    public float attractPushDist = 5;   //����������� ���������� ������������ �� ����������



    private void Awake()
    {
        //�������� ��������� � Spawner S
        S = this;
        //��������� �������� �������� boid
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
