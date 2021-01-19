using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jsonFormatter : MonoBehaviour
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
        
    }

    public struct statement {
        public string id;
        public struct actor
        {
            public string name;
            public string mbox;
        }

        public struct verb
        {
            public string id;
        }

        public struct Object {
            public string id;
            public struct definition
            {
                public string name;
                public string description;
            }
        }
    }
}
