// 代码生成时间: 2025-09-23 12:24:26
using System;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class RestfulApiExample : MonoBehaviour
{
    // Define the base URL for the RESTful API
    private string baseUrl = "http://localhost:5000/api/";

    // Method to handle GET request to fetch data
    public void GetData(string endPoint, Action<string> onSuccess, Action<string> onError)
    {
        // Construct the full URL with the endpoint
        string url = baseUrl + endPoint;

        // Send a GET request to the server
        UnityWebRequest request = UnityWebRequest.Get(url);

        // Start the request and wait for it to complete
        request.SendWebRequest().completed += operation =>
        {
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                // Handle connection or protocol errors
                onError?.Invoke("Error: " + request.error);
            }
            else
            {
                // Handle successful request
                onSuccess?.Invoke(request.downloadHandler.text);
            }
        };
    }

    // Method to handle POST request to send data
    public void PostData(string endPoint, string jsonData, Action<string> onSuccess, Action<string> onError)
    {
        // Construct the full URL with the endpoint
        string url = baseUrl + endPoint;

        // Create a new UnityWebRequest object for a POST request
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.SetRequestHeader("Content-Type", "application/json");

        // Add the JSON data to the request body
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);

        // Send the request and wait for it to complete
        request.SendWebRequest().completed += operation =>
        {
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                // Handle connection or protocol errors
                onError?.Invoke("Error: " + request.error);
            }
            else
            {
                // Handle successful request
                onSuccess?.Invoke(request.downloadHandler.text);
            }
        };
    }

    // Example of using the GetData method
    void Start()
    {
        // Fetch data from the server
        GetData("data",
            onSuccess: (data) => {
                Debug.Log("Data received: " + data);
            },
            onError: (error) => {
                Debug.LogError("Error fetching data: " + error);
            }
        );
    }

    // Example of using the PostData method
    public void SendData()
    {
        // Prepare JSON data to send
        string jsonData = "{"key": "value"}";

        // Send data to the server
        PostData("data",
            jsonData,
            onSuccess: (data) => {
                Debug.Log("Data sent successfully: " + data);
            },
            onError: (error) => {
                Debug.LogError("Error sending data: " + error);
            }
        );
    }
}
