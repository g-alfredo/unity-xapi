using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversionJson : MonoBehaviour
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

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            createJSON();
        }
    }


    public void createJSON()
    {
        string JSONString;
        actor actor = new actor();
        actor.name = _actorName;
        actor.mbox = _actorMbox;
        JSONString ="{ \"actor\":"+ JsonUtility.ToJson(actor);
        verb verb = new verb();
        verb.id = _verbId;
        JSONString+= ",\"verb\":"+ JsonUtility.ToJson(verb);
        definition definition = new definition();
        definition.name = _definitionName;
        definition.description = _definitionDescription;
        JSONString += ",\"object\":{ \"id\": \""+_objectId+ "\",\"definition\": "+ JsonUtility.ToJson(definition);

        Debug.Log("JSON text: " + JSONString);
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


        public class definition
        {
            public string name;
            public string description;
        }
    
}
