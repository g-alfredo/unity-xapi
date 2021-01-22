using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class JsonBeautifier 
{


    public static string Beautify(string json) {
        int spaceCounter = 0;
        var beautified = new StringBuilder();
        Debug.Log("lunghezza " + json.Length);

        for (int counter = 0; counter < json.Length; counter++){
            Debug.Log("sto nel ciclo");
            char c = json[counter];
            if (c.Equals('{')|| c.Equals(','))
            {
                beautified.Append(c+"\n");
                if (c.Equals('{')){
                    spaceCounter++;
                }
                for (int i = 0; i < spaceCounter; i++)
                {
                    beautified.Append("    ");
                }
            }
            else if (c.Equals('}'))
            {
                if (counter + 1 == json.Length)
                {
                    beautified.AppendLine("\n}\n");
                }
                else
                {
                    beautified.Append("}\n");
                    spaceCounter--;
                    for (int i = 0; i < spaceCounter; i++)
                    {
                        beautified.Append("    ");
                    }
                }
            }
            else
            {
                beautified.Append(c);
            }

        }

        Debug.Log("beautified " + beautified.ToString());

        return beautified.ToString();
    }





}
