using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TinCan;
using TinCan.LRSResponses;

public class AnimationEventFunctions : MonoBehaviour
{

    public void inizioTraslazione()
    {
        Debug.Log("Inizia la traslazione");
    }

    public void fineTraslazione()
    {

        Debug.Log("Finita la traslazione");
        Statements.sendStatement("http://id.tincanapi.com/verb/viewed", "See the translation");
    }

    public void inizioRotazione()
    {
        Debug.Log("Inizia la rotazione");
    }

    public void fineRotazione()
    {
        Debug.Log("Finita la rotazione");
        Statements.sendStatement("http://id.tincanapi.com/verb/viewed", "See the rotation");

    }

    /*private void sendStatement(string verbID,string verbDisplay)
    {
        Agent actor = new Agent();
        actor.mbox = "mailto:" +UserInfo.mail;
        actor.name = UserInfo.name;

        
        Verb verb = new Verb();
        verb.id = new Uri("http://id.tincanapi.com/verb/viewed");
        verb.display = new LanguageMap();
        verb.display.Add("en","See the end of translation");

       
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
            Debug.Log("Animation statement send: " + lrsResponse.content.id);
        }
        else //Failure
        {
            Debug.Log("Animation statement failed: " + lrsResponse.errMsg);
        }
    }
    */


    /*
    public void StartAnimation()
    {
    
        Statements.sendStatement("http://adlnet.gov/expapi/verbs/interacted", "Clicked animations button");
        Animator anim = GetComponent<Animator>();
            anim.SetTrigger("AnimationStart");

        
    }
    */

}


