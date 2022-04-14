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
        TxtVelosity.text = "ускорение: " + Spawner.S.velocity;

        Spawner.S.nighborDist = nighborDist.value;
        txtNighborDist.text = "радиус опроса соседей: " + Spawner.S.nighborDist;

        Spawner.S.collDist = collDist.value;
        txtCollDist.text = "отталкивание от соседей: " + Spawner.S.collDist;     

        Spawner.S.velMatching = velMatching.value;
        txtVelMatching.text = "коэф. синхронности: " + Spawner.S.velMatching;      

        Spawner.S.flockCentring = flockCentring.value;
        txtFlockCentring.text = "коэф центрирования среди соседей: " + Spawner.S.flockCentring;
      
        Spawner.S.collAvoid = collAvoid.value;
        txtCollAvoid.text = "коэф. слияния в цепь: " + Spawner.S.collAvoid;

        Spawner.S.attractPull = attractPull.value;
        txtAttractPull.text = "коэф. притяжения к цели: " + Spawner.S.attractPull;

        Spawner.S.attractPush = attractPush.value;
        txtAttractPush.text = "коэф. отталкивание от цели: " + Spawner.S.attractPush;

        Spawner.S.attractPushDist = attractPushDist.value;
        txtAttractPushDist.text = "радиус отталкивания от цели: " + Spawner.S.attractPushDist;
    }
    public void SetValueDefailt()
    {
        SliderVelosity.value = 30f;        // ускорение
        nighborDist.value = 30f;       // радиус опроса соседей
        collDist.value = 4f;         // растояние до соседа
        velMatching.value = 0.25f;     //сплоченость движения
        flockCentring.value = 0.2f;  // группировка среди соседей
        collAvoid.value = 2;
        attractPull.value = 2;       // притяжание цели
        attractPush.value = 2;       // отталкивание цели
        attractPushDist.value = 5;   //минимальное расстояние отталкивания от аттрактора
}
    public void SetValuePreset1()
    {
        SliderVelosity.value = 30f;        // ускорение
        nighborDist.value = 30f;       // радиус опроса соседей
        collDist.value = 10f;         // растояние до соседа
        velMatching.value = 0.25f;     //сплоченость движения
        flockCentring.value = 0.2f;  // группировка среди соседей
        collAvoid.value = 4;
        attractPull.value = 1;       // притяжание цели
        attractPush.value = 2;       // отталкивание цели
        attractPushDist.value = 20;   //минимальное расстояние отталкивания от аттрактора
    }
    public void SetValuePreset2()
    {
        SliderVelosity.value = 30f;        // ускорение
        nighborDist.value = 8f;       // радиус опроса соседей
        collDist.value = 2f;         // растояние до соседа
        velMatching.value = 0.25f;     //сплоченость движения
        flockCentring.value = 8f;  // группировка среди соседей
        collAvoid.value = 10;
        attractPull.value = 1;       // притяжание цели
        attractPush.value = 20;       // отталкивание цели
        attractPushDist.value = 20;   //минимальное расстояние отталкивания от аттрактора
    }
    public void SetValuePreset3()
    {
        SliderVelosity.value = 30f;        // ускорение
        nighborDist.value = 30f;       // радиус опроса соседей
        collDist.value = 10f;         // растояние до соседа
        velMatching.value = 10;     //сплоченость движения
        flockCentring.value = 0.2f;  // группировка среди соседей
        collAvoid.value = 4;
        attractPull.value = 3;       // притяжание цели
        attractPush.value = 2;       // отталкивание цели
        attractPushDist.value = 1;   //минимальное расстояние отталкивания от аттрактора
    }
}
