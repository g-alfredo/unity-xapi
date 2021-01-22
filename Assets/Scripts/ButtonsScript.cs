using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsScript : MonoBehaviour
{
    public Text textUI;
    public Text yourScoreTextUI;
    public GameObject objectAnimated;
    // Start is called before the first frame update
    void Start()
    {
        textUI.text = "";
        yourScoreTextUI.text="";

}

// Update is called once per frame
void Update()
    {

    }

    public void startAnimation()
    {

        Statements.sendStatement("http://adlnet.gov/expapi/verbs/interacted", "Clicked animations button");
        Animator anim =objectAnimated.GetComponent<Animator>();
        anim.SetTrigger("AnimationStart");
    }


    public void GetScore()
    {
        int score = Random.Range(0, 100);
        Debug.Log("Punteggio random: "+score);
        Statements.sendStatement("http://adlnet.gov/expapi/verbs/scored", "Received score", score);
        List<string> bestScoreList = retrieveBestScores.retrieveScoreList();
        yourScoreTextUI.text = "Your points: " + score;
        string text = "";
        for(int i = 0; i < 5; i++)
        {
            text += bestScoreList[i] + "\n";
        }
        textUI.text = text;
        
    }

}
