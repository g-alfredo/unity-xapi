using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorTextScript : MonoBehaviour
{

    private static Text textUI;
    private float timer = 0.0f;
    private static bool show = false;
    private float showTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        textUI = GameObject.Find("ErrorText").GetComponent<Text>();
        textUI.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (show == true)
        {
            timer += Time.deltaTime;
            if (timer > showTime)
            {
                hideError();
                timer = 0.0f;
            }
        }
    }

    public static void showError()
    {
        textUI.text = "Errore: email inserita non presente nell'LRS";
        show = true;
    }

    public static void hideError()
    {
        textUI.text = "";
        show = false;
    }
}
