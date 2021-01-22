using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupScript : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    private bool cam1active;
    // Start is called before the first frame update
    void Start()
    {
        string[] args = System.Environment.GetCommandLineArgs();
        string allString = "";
        foreach(string s in args)
        {
            allString += s + " ";
        }
        /*
         cam1active = true;
        camera1.SetActive(true);
        camera2.SetActive(false);
        */

        Debug.Log("Stringhe ricevute tramite command line "+ allString);







    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Cambio camera");
            if (cam1active)
            {
                camera1.SetActive(false);
                camera2.SetActive(true);
            }
            else
            {
                camera1.SetActive(true);
                camera2.SetActive(false);
            }
            cam1active = !cam1active;
            Debug.Log("Cambio camera finito");

        }
        */


    }
}
