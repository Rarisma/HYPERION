using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.CodeDom;

public class Input : MonoBehaviour
{
    public InputActionReference joystickInput;
    TextMeshProUGUI TextUI; //Ref to the TextMeshPro Text block that we want to show text on
    int waiter = 0;
    Thread thread;
    void Start()
    {
        joystickInput.action.Enable();
        TextUI = GameObject.Find("XYDisp").GetComponent<TextMeshProUGUI>(); //Get ref
        thread = new Thread(UpdateTask);
        thread.Start();
    }

    void UpdateTask()
    {
        while (true)
        {
            try
            {
                var val = joystickInput.action.ReadValue<Vector2>();
                TextUI.text = "X: " + val[0] + " Y: " + val[1];

                if (val[0] > 0.3) // Right
                {
                    if (val[1] > 0.5) //Up Right
                    {
                        new WebClient().DownloadString("http://192.168.4.1/MoveFRT");
                        System.Threading.Thread.Sleep(200);
                    }
                    else //Down right
                    {
                        new WebClient().DownloadString("http://192.168.4.1/MoveRRT");
                        System.Threading.Thread.Sleep(200);
                    }
                }
                else if (val[0] < -0.3) //Left
                {
                    if (val[1] > 0.5) //Up Left
                    {
                        new WebClient().DownloadString("http://192.168.4.1/MoveFLT");
                        System.Threading.Thread.Sleep(200);
                    }
                    else
                    {
                        new WebClient().DownloadString("http://192.168.4.1/MoveRLT");
                        System.Threading.Thread.Sleep(200);
                    }
                }
                else
                {
                    if (val[1] == 0) //stop moving
                    {
                        new WebClient().DownloadString("http://192.168.4.1/DontMove");
                        System.Threading.Thread.Sleep(200);
                    }
                    else if (val[1] > 0.5) //move up
                    {
                        new WebClient().DownloadString("http://192.168.4.1/MoveFOR");
                        System.Threading.Thread.Sleep(200);
                    }
                    else if (val[1] < -0.5)
                    {
                        new WebClient().DownloadString("http://192.168.4.1/MoveREV");
                        System.Threading.Thread.Sleep(200);
                    }
                }
            }
            catch
            {
                
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void started(InputAction.CallbackContext context)
    {
        
    }
    
}
