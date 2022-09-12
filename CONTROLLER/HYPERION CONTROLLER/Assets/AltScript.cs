using System.Collections.Generic;
using System.Net;
using System.Net.Cache;
using UnityEngine;
using TMPro;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

public class AltScript : MonoBehaviour
{
    int waiter = 0;
    TextMeshProUGUI TextUI; //Ref to the TextMeshPro Text block that we want to show text on
    Thread thread;
    void Start()
    {
        TextUI = GameObject.Find("Alt").GetComponent<TextMeshProUGUI>(); //Get ref
        thread = new Thread(UpdateTask);
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
                string Result = new WebClient().DownloadString("http://192.168.4.1/Altitude");
                UnityEngine.Debug.Log("Got result as: " + Result);
                TextUI.text = "Altitude: " + Result + " M";
                UnityEngine.Debug.Log("Done.");

            }
            catch (Exception e)
            {
                TextUI.text = e.Message;
                UnityEngine.Debug.Log("error:" + e.Message);
            }
            waiter = 0;
            thread.Abort();
        }
    }

    void Update()
    {
        //if (waiter == 700 && thread.ThreadState != System.Threading.ThreadState.Running) { thread.Start(); }
        //else { waiter++; }
    }
}