    using System.Collections.Generic;
using System.Net;
using System.Net.Cache;
using UnityEngine;
using TMPro;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

public class PresScript : MonoBehaviour
{
    TextMeshProUGUI TextUI; //Ref to the TextMeshPro Text block that we want to show text on
    Thread thread;
    void Start()
    {
        TextUI = GameObject.Find("Pres").GetComponent<TextMeshProUGUI>(); //Get ref
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
                string Result = new WebClient().DownloadString("http://192.168.4.1/Presure");
                UnityEngine.Debug.Log("Got result as: " + Result);
                TextUI.text = "Pressure: " + Result + " HPa";
                UnityEngine.Debug.Log("Done.");

            }
            catch (Exception e)
            {
                TextUI.text = e.Message;
                UnityEngine.Debug.Log("error:" + e.Message);
            }
        }
    }
    void Update()
    {
        //if (waiter == 700 && thread.ThreadState != System.Threading.ThreadState.Running) { thread.Start(); }
        //else { waiter++; }
    }
}
