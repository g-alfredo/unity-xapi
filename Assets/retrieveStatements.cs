using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TinCan;
using TinCan.LRSResponses;

public class retrieveStatements : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var lrs = new RemoteLRS(
    ConnectionParameters.uri,
    ConnectionParameters.username,
    ConnectionParameters.password
);
        Debug.Log(this.GetType().Name + " started");
        var query = new StatementsQuery();
        query.since = DateTime.Parse("2020-12-31 00:00:00Z");

        Agent actor = new Agent();
        actor.mbox = "mailto:" + "mail@esempio.com";
        query.agent = actor;

        
        query.limit = 10;

        StatementsResultLRSResponse lrsResponse = lrs.QueryStatements(query);
        Debug.Log(lrsResponse.success);
        Debug.Log(lrsResponse.success);

        if (lrsResponse.success)
        {
            // List of statements available
            Debug.Log("Count of statements: " + lrsResponse.content.statements.Count);
            List<Statement> statements = lrsResponse.content.statements;
            foreach(Statement s in statements)
            {
                Debug.Log(s.ToJSON());
            }
        }
        else
        {
            // Do something with failure
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }








}
