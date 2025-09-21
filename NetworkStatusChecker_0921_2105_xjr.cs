// 代码生成时间: 2025-09-21 21:05:14
using System;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkStatusChecker : MonoBehaviour
{
    // Call this method to check the network status
    public void CheckNetworkStatus()
    {
        try
        {
            // Use UnityWebRequest to ping a default URL to check for internet connectivity
            UnityWebRequest request = UnityWebRequest.Get("https://www.googleapis.com/generate_204");
            request.timeout = 10;
            request.SendWebRequest();

            // Wait for the request to complete
            while (!request.isDone)
            {
                // You can update your UI or perform other tasks here while waiting
            }

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                // Handle connection error
                Debug.LogError("Network connection error: " + request.error);
            }
            else
            {
                // Network is connected
                Debug.Log("Network is connected.");
            }
        }
        catch (Exception e)
        {
            // Handle any unexpected exceptions
            Debug.LogError("An exception occurred while checking network status: " + e.Message);
        }
    }

    // This method is called by Unity when the component is started
    private void Start()
    {
        // Check the network status on start
        CheckNetworkStatus();
    }
}
