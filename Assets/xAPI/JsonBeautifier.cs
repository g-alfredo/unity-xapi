using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class JsonBeautifier 
{


    public static string Beautify(string json) {
        int spaceCounter = 0;
        string text = "";
        var beautified = new StringBuilder();
        Debug.Log("lunghezza " + json.Length);

        for (int counter = 0; counter < json.Length; counter++){
            Debug.Log("sto nel ciclo");
            char c = json[counter];
            if (c.Equals('{')|| c.Equals(','))
            {
                beautified.Append(c+"\n");
                text = text+ c+"\n";
                if (c.Equals('{')){
                    spaceCounter++;
                }
                for (int i = 0; i < spaceCounter; i++)
                {
                    beautified.Append("    ");
                    text =text+ "    ";
                }
            }
            else if (c.Equals('}'))
            {
                beautified.Append("}\n");
                text =text+ "}\n";
                spaceCounter--;
                for (int i = 0; i < spaceCounter; i++)
                {
                    beautified.Append("    ");
                    text =text+ "    ";
                }
            }
            else
            {
                beautified.Append(c);
                text = text + c;
            }

        }
        Debug.Log("beautified " + beautified.ToString());
        Debug.Log("testo: " + text);

        return text;
    }





}
