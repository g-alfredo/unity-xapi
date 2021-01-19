using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TinCan;
using TinCan.LRSResponses;

public class Statements 
{
    public static void sendStatement(string verbID, string verbDisplay)
    {
        Agent actor = new Agent();
        actor.mbox = "mailto:" + UserInfo.mail;
        actor.name = UserInfo.name;


        Verb verb = new Verb();
        verb.id = new Uri(verbID);
        verb.display = new LanguageMap();
        verb.display.Add("en", verbDisplay);


        Activity activity = new Activity();
        activity.id = UserInfo.activityID;

        //activity.id = new Uri("http://www.example.com/" + this.gameObject.GetInstanceID()).ToString();



        ActivityDefinition activityDefinition = new ActivityDefinition();
        activityDefinition.description = new LanguageMap();
        activityDefinition.name = new LanguageMap();
        activityDefinition.name.Add("en", UserInfo.activityDefinition);
        activity.definition = activityDefinition;


        Statement statement = new Statement();
        statement.actor = actor;
        statement.verb = verb;
        statement.target = activity;


        StatementLRSResponse lrsResponse = LRSConnectionInitializer.lrs.SaveStatement(statement);
        if (lrsResponse.success) //Success
        {
            updateText(statement);
            Debug.Log(verbDisplay + " statement send: " + lrsResponse.content.id);
        }
        else //Failure
        {
            Debug.Log(verbDisplay + "Animation statement failed: " + lrsResponse.errMsg);
        }
    }


    //con punteggio
    public static void sendStatement(string verbID, string verbDisplay, int scoreValue)
    {
        Agent actor = new Agent();
        actor.mbox = "mailto:" + UserInfo.mail;
        actor.name = UserInfo.name;


        Verb verb = new Verb();
        verb.id = new Uri(verbID);
        verb.display = new LanguageMap();
        verb.display.Add("en", verbDisplay);


        Activity activity = new Activity();
        activity.id = UserInfo.activityID;

        //activity.id = new Uri("http://www.example.com/" + this.gameObject.GetInstanceID()).ToString();



        ActivityDefinition activityDefinition = new ActivityDefinition();
        activityDefinition.description = new LanguageMap();
        activityDefinition.name = new LanguageMap();
        activityDefinition.name.Add("en", UserInfo.activityDefinition);
        activity.definition = activityDefinition;
        Result result = new Result();
        Score score = new Score();

        score.raw = scoreValue;
        result.score = score;
        

        Statement statement = new Statement();
        statement.actor = actor;
        statement.verb = verb;
        statement.target = activity;
        statement.result = result;


        StatementLRSResponse lrsResponse = LRSConnectionInitializer.lrs.SaveStatement(statement);
        if (lrsResponse.success) //Success
        {
            updateText(statement);
            Debug.Log(verbDisplay + " statement send: " + lrsResponse.content.id);
        }
        else //Failure
        {
            Debug.Log(verbDisplay + "Animation statement failed: " + lrsResponse.errMsg);
        }
    }

    private static void updateText(Statement statement)
    {
        TextStatements textStatUI = new TextStatements();
        textStatUI.setText(JsonBeautifier.Beautify(statement.ToJSON()));
        Debug.Log("STATEMENT JSON UTIL: " + JsonBeautifier.Beautify(statement.ToJSON()));

    }
}
