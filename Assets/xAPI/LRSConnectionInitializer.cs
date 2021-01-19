using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinCan;

public class LRSConnectionInitializer : MonoBehaviour
{
    public static RemoteLRS lrs;

    // Start is called before the first frame update
    void Start()
    {
        lrs = new RemoteLRS(ConnectionParameters.uri, ConnectionParameters.username, ConnectionParameters.password);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
