using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Cache;
using UnityEngine;
using TMPro;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
//This is the greatest script recompile of all time
public class TempScript : MonoBehaviour
{
    int waiter = 0;
    TextMeshProUGUI TextUI; //Ref to the TextMeshPro Text block that we want to show text on
    Thread thread;
    void Start()
    {
        TextUI = GameObject.Find("Temp").GetComponent<TextMeshProUGUI>(); //Get ref
        TextUI.text =  "EstFPS: " + (1 / Time.deltaTime);
        thread = new Thread(UpdateTask);
        thread.Start();
    }
    void UpdateTask()
    {
        while (true)
        {
            Thread.Sleep(5000);
            UnityEngine.Debug.Log("Starting update");
            try
            {
                UnityEngine.Debug.Log("Hitting API");
                string Result = new WebClient().DownloadString("http://192.168.4.1/Temp");
                UnityEngine.Debug.Log("Got result as: " + Result);
                TextUI.text = "Temp: " + Result + " C";
                UnityEngine.Debug.Log("Done.");

            }
            catch (Exception e)
            {
                TextUI.text = e.Message;
                UnityEngine.Debug.Log("error:" + e.Message);
            }
            waiter = 0;
        }
    }
    void Update() 
    {

    }
}
