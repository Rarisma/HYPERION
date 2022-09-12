using System;
using System.Net.Http;
using System.Text;
using UnityEngine;

public class DoThing : MonoBehaviour
{
    private string host = "http://192.168.0.170:5000/";

    public async void OnClick(int directionID) {
        try
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(host);

                // method address would be like api/callUber:SomePort for example
                var result = await client.PostAsync("Move", new StringContent("{\"Id\":" + directionID + "}", Encoding.UTF8, "application/json"));
                string resultContent = await result.Content.ReadAsStringAsync();
            }
        }
        catch
        {

        }
    }
  
}
