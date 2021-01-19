using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Converters;
using UnityEngine.Networking;

public class xAPI_Parameters : MonoBehaviour
{
    public string actor;
    public string mbox;
    public string verb;
    public string objectID;
    public string objectName;
    public string objectDescription;

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }

    // Start is called before the first frame update
    void Start()
    {

        Statement stat = new Statement();
        stat.actor = new ActorClass();
        stat.verb = new VerbClass();
        stat.@object = new ObjectClass();
        stat.actor.name = actor;
        stat.actor.mbox = "mailto:"+mbox;
        stat.verb.id = this.verb;
        stat.@object.id = objectID;
        stat.@object.definition = new DefinitionClass();
        stat.@object.definition.name = new NameClass();
        stat.@object.definition.name.en_GB=objectName;
        stat.@object.definition.description = new DescriptionClass();
        stat.@object.definition.description.en_GB = objectDescription;

        //fix underscore problem with hyphen in parameter name
        string statementJson = Newtonsoft.Json.JsonConvert.SerializeObject(stat).Replace("en_GB", "en-GB");


        Debug.Log("JSON statement: " + statementJson);

        StartCoroutine(JSONSender.Login(statementJson));


    }


    // Update is called once per frame
    void Update()
    {
        
    }








    public class Statement
    {
        public ActorClass actor;
        public VerbClass verb;
        public ObjectClass @object;
    }

    public class ActorClass
    {
        public string name;
        public string mbox;
    }

    public class VerbClass
    {
        public string id;
    }

    public class ObjectClass
    {
        public string id;
        public DefinitionClass definition;
    }
    public class DefinitionClass
    {
        public NameClass name;
        public DescriptionClass description;

    }

    public class NameClass
    {
        public string @en_GB;
    }

    public class DescriptionClass
    {
        public string en_GB;
    }







}
