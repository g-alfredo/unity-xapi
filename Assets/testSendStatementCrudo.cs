using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSendStatementCrudo : MonoBehaviour
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
        }
    }

    public string SaveToString(Object obj)
    {
        return JsonUtility.ToJson(obj);
    }

    private void CreateJSON()
    {
        statement statement = new statement();
        statement.actor attore = new statement.actor();
        attore.name = _actor;
        attore.mbox = "mail@testing.com";
        statement.verb verb = new statement.verb();
        verb.id = _verb;
        statement.Object oggetto = new statement.Object();
        oggetto.id = "id oggetto";
        statement.Object.definition definition = new statement.Object.definition();
        definition.name = _definition;
        definition.description = "descrizione della definizione";


    }

    private class statement { 
        public class actor
        {
            public string name;
            public string mbox;
        }

        public class verb
        {
            public string id;
        }

        public class Object
        {
            public string id;
         public class definition
         {
                public string name;
                public string description;

            }
        }
    }

}
