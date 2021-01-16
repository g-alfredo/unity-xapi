using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibileInCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Renderer>().isVisible)
        {
            //Visible code here
            Debug.Log("Visibile");
        }
        else
        {
            //Not visible code here
            Debug.Log("Non visibile");

        }


    }
}


