using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TinCan;
using TinCan.LRSResponses;
using UnityEngine.SceneManagement;

public class RetrieveName
{

    public static string getName(string email) {
    Debug.Log("retrieveName started");
        var query = new StatementsQuery();
        Agent actor = new Agent();
        actor.mbox = "mailto:" + email;
        query.agent = actor;
        query.limit = 100;

        StatementsResultLRSResponse lrsResponse = LRSConnectionInitializer.lrs.QueryStatements(query);
    Debug.Log(lrsResponse.success);
        string name = "";
        Debug.Log("name " + name);


        if (lrsResponse.success)
        {
            // List of statements available
            Debug.Log("RetrieveName statements: " + lrsResponse.content.statements.Count);
            List<Statement> statements = lrsResponse.content.statements;
            statements.RemoveAll(item => item.actor.name == null);
            if (statements.Count > 0) {
                name = statements[0].actor.name;

                //Cambia scena
                SceneManager.LoadScene("MainScene");
            }

        }
        else
        {
            Debug.Log("RetrieveName failed");
            // Do something with failure

        }
        Debug.Log("name " + name);
        return name;
    }
}
