using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TinCan;
using TinCan.LRSResponses;

public class testSendStatement : MonoBehaviour
{

    public string _actor;
    public string _verb;
    public string _definition;
    public int _value;
    
    private RemoteLRS lrs;
    // Start is called before the first frame update
    void Start()
    {
        lrs = new RemoteLRS("https://demo-xapi.lrs.io/xapi/", "edewis", "efozic");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SendStatement();
        }
    }

    public void SendStatement()
    {

        //Build out Actor details
        Agent actor = new Agent();
        actor.mbox = "mailto:" + _actor.Replace(" ", "") + "@email.com";
        actor.name = _actor;

        //Build out Verb details
        Verb verb = new Verb();
        verb.id = new Uri("http://www.example.com/" + _verb.Replace(" ", ""));
        verb.display = new LanguageMap();
        verb.display.Add("en-US", _verb);

        //Build out Activity details
        Activity activity = new Activity();
        activity.id = new Uri("http://www.example.com/" + _definition.Replace(" ", "")).ToString();

        //Build out Activity Definition details
        ActivityDefinition activityDefinition = new ActivityDefinition();
        activityDefinition.description = new LanguageMap();
        activityDefinition.name = new LanguageMap();
        activityDefinition.name.Add("en-US", (_definition));
        activity.definition = activityDefinition;

        Result result = new Result();
        Score score = new Score();

        score.raw = _value;
        result.score = score;

        //Build out full Statement details
        Statement statement = new Statement();
        statement.actor = actor;
        statement.verb = verb;
        statement.target = activity;
        statement.result = result;

        //Send the statement
        StatementLRSResponse lrsResponse = lrs.SaveStatement(statement);
        if (lrsResponse.success) //Success
        {
            Debug.Log("Saving successful! Statement: " + lrsResponse.content.id);
        }
        else //Failure
        {
            Debug.Log("Saving statement Failed: " + lrsResponse.errMsg);
        }

    }
}
