using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class clock : MonoBehaviour
{
    public TextMeshProUGUI Timer;//has a variable type of TextMEshProGUI as it'l be displayed
    public float liveTime;// will be used the store the real count
    public float roundedLiveTime;// this is the 'carrier' variable I made to hold a copy
    // of the 'liveTime' variable
    public TextMeshProUGUI accuracyStat;//has a variable type of TextMEshProGUI as it'l be displayed
    public float accuracy;// will be used the store the live accuracy

    target hitAccumSample;// this is the call reference to the 'target script' and I 
    // named it 'hitAccumSample' which will be this script's reference tag
    public GameObject sampleOne;//the sample variable that'll hold the extracted 'hitAccum' value
    public float x;//the copy of the sample variable that'll be used for the accuracy calculation

    shoot fireCountSample;// this is the call reference to the 'shoot script' and I 
    // named it 'fireCountmSample' which will be this script's reference tag
    public GameObject sampleTwo;//the sample variable that'll hold the extracted 'bulletsFired' value
    public float y;//the copy of the sample variable that'll be used for the accuracy calculation


    void Awake()
    {
        hitAccumSample = sampleOne.GetComponent<target>();
        fireCountSample = sampleTwo.GetComponent<shoot>();
        //these operations allow these samples to be at the ready to fetch any variable
        // I request for from the scripts, given the script and the particular variable is public
    }



    // Update is called once per frame
    void Update()
    {
       
        x = hitAccumSample.hitAccum;

        y = fireCountSample.bulletsFired;

        accuracy = Mathf.Round((x / y) * 100);
        accuracyStat.text = (accuracy, "%").ToString();

        liveTime += Time.deltaTime;
        roundedLiveTime = Mathf.Round(liveTime);
        Timer.text = roundedLiveTime.ToString();

        

    }


}
