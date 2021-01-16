using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] args = System.Environment.GetCommandLineArgs();
        string allString = "";
        foreach(string s in args)
        {
            allString += s + " ";
        }
        Debug.Log("Stringhe ricevute tramite command line "+ allString);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
