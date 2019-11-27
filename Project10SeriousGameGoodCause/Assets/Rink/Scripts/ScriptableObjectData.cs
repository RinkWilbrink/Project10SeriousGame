using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectData : MonoBehaviour
{
    // Variables
    [SerializeField] public Object[] people;
    [SerializeField] public Object[] messages;

    void Start()
    {
        people = Resources.LoadAll("DialogSystemObjects", typeof(ObjectPerson));
        messages = Resources.LoadAll("DialogSystemObjects", typeof(ObjectBubble));

        for (int i = 0; i < people.Length; i++)
        {
            Debug.Log(people[i].name);
        }

        for (int i = 0; i < messages.Length; i++)
        {
            Debug.Log(messages[i].name);
        }
    }

    void Update()
    {

    }
}
