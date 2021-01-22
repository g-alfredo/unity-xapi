using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStatements : MonoBehaviour
{

    public static Text textUI;
    // Start is called before the first frame update
    void Start()
    {
        textUI = this.GetComponent<Text>();
        textUI.text = "";
        Statements.sendStatement("http://activitystrea.ms/schema/1.0/start", "Started game");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setText(string text)
    {
        textUI.text = text;
    }
}
