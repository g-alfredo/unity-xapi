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
    
    // Start is called before the first frame update
    void Start()
    {
        
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

        Agent actor = new Agent();
        actor.mbox = "mailto:" + _actor.Replace(" ", "") + "@email.com";
        actor.name = _actor;

        Verb verb = new Verb();
        verb.id = new Uri("http://www.example.com/verbs/"+"attempted");
        verb.display = new LanguageMap();
        verb.display.Add("en-US", _verb);

        Activity activity = new Activity();
        activity.id = new Uri("http://www.example.com/" + _definition.Replace(" ", "")).ToString();

        //activity.id = new Uri("http://www.example.com/" + this.gameObject.GetInstanceID()).ToString();


        ActivityDefinition activityDefinition = new ActivityDefinition();
        activityDefinition.description = new LanguageMap();
        activityDefinition.name = new LanguageMap();
        activityDefinition.name.Add("en-US", (_definition));
        activity.definition = activityDefinition;

        Result result = new Result();
        Score score = new Score();

        score.raw = _value;
        result.score = score;
        Context context = new Context();
        ContextActivities contActivities = new ContextActivities();
        List<Activity> activitiesParent = new List<Activity>();
        Activity actParent = new Activity();
        ActivityDefinition actDefinition = new ActivityDefinition();
        LanguageMap actDefMap = new LanguageMap();
        actDefMap.Add("en", "Attività su unity");
        actDefinition.name = actDefMap;
        actParent.definition = actDefinition;
        actParent.id=new Uri("http://localhost/mod/lti/view.php?id=2").ToString();
        activitiesParent.Add(actParent);
        contActivities.parent = activitiesParent;
        context.contextActivities = contActivities;

        Statement statement = new Statement();
        statement.actor = actor;
        statement.verb = verb;
        statement.target = activity;
        statement.result = result;
        statement.context = context;


        StatementLRSResponse lrsResponse = LRSConnectionInitializer.lrs.SaveStatement(statement);
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
