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

        Context context = new Context();
        ContextActivities contActivities = new ContextActivities();
        context.contextActivities = contActivities;
        Activity parentActivity = new Activity();
        parentActivity.id = UserInfo.parentActivityID;
        ActivityDefinition parentActivityDef = new ActivityDefinition();
        LanguageMap language = new LanguageMap();
        language.Add("en", "Grafica ed Interattività");
        parentActivityDef.name = language;
        parentActivity.definition = parentActivityDef;
        List<Activity> activitiesParent = new List<Activity>();
        activitiesParent.Add(parentActivity);
        contActivities.parent = activitiesParent;


        Statement statement = new Statement();
        statement.actor = actor;
        statement.verb = verb;
        statement.target = activity;
        statement.context = context;


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

        score.scaled = scoreValue/100;
        score.raw = scoreValue;
        result.score = score;


        Context context = new Context();
        ContextActivities contActivities = new ContextActivities();
        context.contextActivities = contActivities;
        Activity parentActivity = new Activity();
        parentActivity.id = UserInfo.parentActivityID;
        ActivityDefinition parentActivityDef = new ActivityDefinition();
        LanguageMap language = new LanguageMap();
        language.Add("en", "Grafica ed Interattività");
        parentActivityDef.name = language;
        parentActivity.definition = parentActivityDef;
        List<Activity> activitiesParent = new List<Activity>();
        activitiesParent.Add(parentActivity);
        contActivities.parent = activitiesParent;

        Statement statement = new Statement();
        statement.actor = actor;
        statement.verb = verb;
        statement.target = activity;
        statement.result = result;
        statement.context = context;


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
