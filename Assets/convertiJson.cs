using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;

public class convertiJson : MonoBehaviour
{
    public string _actorName;
    public string _actorMbox;
    public string _verbId;
    public string _objectId;
    public string _definitionName;
    public string _definitionDescription;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Debug attivo");
        actor actor = new actor();
        actor.name = _actorName;
        actor.mbox = _actorMbox;

        string jsonActor = JsonUtility.ToJson(actor);
        Debug.Log("JSON attore: " + jsonActor);


        definition defi = new definition();
        defi.name = _definitionName;
        defi.description = _definitionDescription;

        @object obj = new @object();
        obj.id = _objectId;
        obj.definition= JsonUtility.ToJson(defi);

        verb verb = new verb();
        verb.id = _verbId;

        statement statement = new statement();
        statement.actor= JsonUtility.ToJson(actor);
        statement.verb= JsonUtility.ToJson(verb);
        statement.Object = JsonUtility.ToJson(obj);

        Debug.Log("JSON statement: " + JsonUtility.ToJson(statement));
        Debug.Log("JSON statement con newtonsoft: " + Newtonsoft.Json.JsonConvert.SerializeObject(statement));



        string jsonObject = JsonUtility.ToJson(obj);
        string jsonDefinition = JsonUtility.ToJson(defi);
        string jsonObjDefinition = JsonUtility.ToJson(obj.definition);


        Debug.Log("JSON oggetto: " + jsonObject);
        Debug.Log("JSON definizione: " + jsonDefinition);
        Debug.Log("JSON obj.definizione: " + jsonObjDefinition);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class statement
    {
        public string actor;
        public string verb;
        public string Object;
    }

    public class actor
    {
        public string name;
        public string mbox;
    }

    public class verb
    {
        public string id;
    }

    public class @object
    {
        public string id;
        public string definition;
    }
    public class definition
    {
        public string name;
        public string description;

    }
}
