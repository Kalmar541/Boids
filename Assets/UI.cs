using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [Header("Set in inspector")]
    public Text TxtVelosity;   
    public Slider SliderVelosity;

    public Slider collDist;
    public Text txtCollDist;

    public Slider attractPushDist;
    public Text txtAttractPushDist;

    public Slider velMatching;
    public Text txtVelMatching;

    public Slider nighborDist;
    public Text txtNighborDist;

    public Slider flockCentring;
    public Text txtFlockCentring;

   
    public Slider collAvoid ;
    public Slider attractPull ;
    public Slider attractPush ;
  
    public Text txtCollAvoid ;
    public Text txtAttractPull ;
    public Text txtAttractPush ;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Spawner.S.velocity = SliderVelosity.value;
        TxtVelosity.text = "���������: " + Spawner.S.velocity;

        Spawner.S.nighborDist = nighborDist.value;
        txtNighborDist.text = "������ ������ �������: " + Spawner.S.nighborDist;

        Spawner.S.collDist = collDist.value;
        txtCollDist.text = "������������ �� �������: " + Spawner.S.collDist;     

        Spawner.S.velMatching = velMatching.value;
        txtVelMatching.text = "����. ������������: " + Spawner.S.velMatching;      

        Spawner.S.flockCentring = flockCentring.value;
        txtFlockCentring.text = "���� ������������� ����� �������: " + Spawner.S.flockCentring;
      
        Spawner.S.collAvoid = collAvoid.value;
        txtCollAvoid.text = "����. ������� � ����: " + Spawner.S.collAvoid;

        Spawner.S.attractPull = attractPull.value;
        txtAttractPull.text = "����. ���������� � ����: " + Spawner.S.attractPull;

        Spawner.S.attractPush = attractPush.value;
        txtAttractPush.text = "����. ������������ �� ����: " + Spawner.S.attractPush;

        Spawner.S.attractPushDist = attractPushDist.value;
        txtAttractPushDist.text = "������ ������������ �� ����: " + Spawner.S.attractPushDist;
    }
    public void SetValueDefailt()
    {
        SliderVelosity.value = 30f;        // ���������
        nighborDist.value = 30f;       // ������ ������ �������
        collDist.value = 4f;         // ��������� �� ������
        velMatching.value = 0.25f;     //����������� ��������
        flockCentring.value = 0.2f;  // ����������� ����� �������
        collAvoid.value = 2;
        attractPull.value = 2;       // ���������� ����
        attractPush.value = 2;       // ������������ ����
        attractPushDist.value = 5;   //����������� ���������� ������������ �� ����������
}
    public void SetValuePreset1()
    {
        SliderVelosity.value = 30f;        // ���������
        nighborDist.value = 30f;       // ������ ������ �������
        collDist.value = 10f;         // ��������� �� ������
        velMatching.value = 0.25f;     //����������� ��������
        flockCentring.value = 0.2f;  // ����������� ����� �������
        collAvoid.value = 4;
        attractPull.value = 1;       // ���������� ����
        attractPush.value = 2;       // ������������ ����
        attractPushDist.value = 20;   //����������� ���������� ������������ �� ����������
    }
    public void SetValuePreset2()
    {
        SliderVelosity.value = 30f;        // ���������
        nighborDist.value = 8f;       // ������ ������ �������
        collDist.value = 2f;         // ��������� �� ������
        velMatching.value = 0.25f;     //����������� ��������
        flockCentring.value = 8f;  // ����������� ����� �������
        collAvoid.value = 10;
        attractPull.value = 1;       // ���������� ����
        attractPush.value = 20;       // ������������ ����
        attractPushDist.value = 20;   //����������� ���������� ������������ �� ����������
    }
    public void SetValuePreset3()
    {
        SliderVelosity.value = 30f;        // ���������
        nighborDist.value = 30f;       // ������ ������ �������
        collDist.value = 10f;         // ��������� �� ������
        velMatching.value = 10;     //����������� ��������
        flockCentring.value = 0.2f;  // ����������� ����� �������
        collAvoid.value = 4;
        attractPull.value = 3;       // ���������� ����
        attractPush.value = 2;       // ������������ ����
        attractPushDist.value = 1;   //����������� ���������� ������������ �� ����������
    }
}
