using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class JSONSender 
{


    public static IEnumerator Login(string bodyJsonString)
    {
        Debug.Log("Coroutine started");

        //UnityWebRequest req = UnityWebRequest.Post("http://ugezag:fakwah@local.veracity.it:3005/demo-xapi/xapi/statements", bodyJsonString);
        var req = new UnityWebRequest("http://"+ConnectionParameters.username+":"+ConnectionParameters.password+"@"+ConnectionParameters.url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(bodyJsonString);
        req.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");
        req.SetRequestHeader("X-Experience-API-Version", "1.0.3");
        yield return req.SendWebRequest();
        if (req.result == UnityWebRequest.Result.ConnectionError || req.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("xAPI send failed");
            Debug.Log(req.error);
        }
        else
        {
            Debug.Log("xAPI send successful");
        }

    }
}
