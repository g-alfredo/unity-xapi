using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TinCan;
using TinCan.LRSResponses;

public class retrieveBestScoreRaw : MonoBehaviour
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
        /*Agent actor = new Agent();
        actor.mbox = "mailto:" + "mail@esempio.com";
        query.agent = actor;
        */
        query.activityId = new Uri("http://www.example.com/" + this.gameObject.GetInstanceID()).ToString();

        query.limit = 10;

        StatementsResultLRSResponse lrsResponse = lrs.QueryStatements(query);
        Debug.Log(lrsResponse.success);
        Debug.Log(lrsResponse.success);


        if (lrsResponse.success)
        {
            // List of statements available
            Debug.Log("BestScoreRaw statements: " + lrsResponse.content.statements.Count);
            List<Statement> statements = lrsResponse.content.statements;
            statements.RemoveAll(item => item.result.score.raw == null);
            //statements.Sort((x, y) => x.result.score.raw.CompareTo(y.result.score.raw));
            //objListOrder.Sort((x, y) => x.OrderDate.CompareTo(y.OrderDate));
            //statements.Sort((x, y) =>  x.result.score.raw.CompareTo(y.result.score.raw));
            statements.Sort((x, y) => CompareByScoreDesc(x.result.score.raw, y.result.score.raw));
            
            //statements.OrderBy(c => c.obj != null ? c.obj.Name : "");
            foreach (Statement s in statements)

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

    public static int CompareByScoreDesc(double? a, double? b)
    {
        double num1 = a.GetValueOrDefault();
        double num2 = b.GetValueOrDefault();
        if (num1 < num2)
            return 1;
        else if (num1 > num2)
            return -1;
        else return 0;
    }


    /*
    private class sortByScoreAscending : IComparer
    {
        int IComparer.Compare(double? a, double? b)
        {
            double a1 = a.GetValueOrDefault();
            double b1= b.GetValueOrDefault();
            car c2 = (car)b;
            if (c1.year > c2.year)
                return 1;
            if (c1.year < c2.year)
                return -1;
            else
                return 0;
        }
    }
    */



}
