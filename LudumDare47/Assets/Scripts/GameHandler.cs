﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{

    private float time = 0;
    private int minutes = 0;
    private int seconds = 0;
    public Text timeText;
    private int lap = 0;

    private float lap1time;
    private float lap2time;
    private float lap3time;


    public Text Lap1;
    public Text Lap2;
    public Text Lap3;


    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        System.TimeSpan t = System.TimeSpan.FromSeconds(time);
        

        //time += Time.deltaTime;
        //Debug.Log(t);
        timeText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Minutes, t.Seconds, t.Milliseconds);
    }

    public void Lap()
    {
        
        if (lap == 1)
        {
            System.TimeSpan t = System.TimeSpan.FromSeconds(time);
            Lap1.text = "Lap 1: \n" + string.Format("{0:D2}:{1:D2}:{2:D2}", t.Minutes, t.Seconds, t.Milliseconds);
            lap1time = time;
        }

        if (lap == 2)
        {
            lap2time = time - lap1time;
            System.TimeSpan t = System.TimeSpan.FromSeconds(lap2time);
            Lap2.text = "Lap 2: \n" + string.Format("{0:D2}:{1:D2}:{2:D2}", t.Minutes, t.Seconds, t.Milliseconds);
            
        }

        if (lap == 3)
        {
            lap3time = time - lap1time - lap2time;
            System.TimeSpan t = System.TimeSpan.FromSeconds(lap3time);
            Lap3.text = "Lap 3: \n" + string.Format("{0:D2}:{1:D2}:{2:D2}", t.Minutes, t.Seconds, t.Milliseconds);

        }
        lap++;

    }
}
