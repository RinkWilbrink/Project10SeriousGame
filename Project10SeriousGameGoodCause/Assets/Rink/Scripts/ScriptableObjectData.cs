using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectData : MonoBehaviour
{
    // Variables
    [SerializeField] public Object[] people;
    [SerializeField] public Object[] messages;

    /* What to do with List with all scriptable objects and how to sort all of it.
     * 
     * Make a list of list's that contain all the Text Bubble scriptable objects.
     * 
    */
    [SerializeField] public List<List<Object>> messageList = new List<List<Object>>();

    public byte RoundNumber = 1;

    void Awake()
    {
        people = Resources.LoadAll("DialogSystemObjects", typeof(ObjectPerson));
        messages = Resources.LoadAll("DialogSystemObjects", typeof(ObjectBubble));

        /*
        for (int i = 0; i < messages.Length; i++)
        {
            Debug.Log(messages[i].name);
        }*/

        for (int i = 0; i < messages.Length; i++)
        {
            List<Object> round = new List<Object>();
            for (int j = 0; j < messages.Length; j++)
            {
                if(messages[i].name == string.Format("{0}.{1}", i, j)) {
                    round.Add(messages[i]);
                    Debug.LogFormat("Added: {0}", messages[i]);
                }
            }

            // Add the new list into the List<List<Object>>.
            messageList.Add(round);
            round = null;
        }

        for (int i = 0; i < messageList.Count; i++)
        {
            Debug.Log("List Count: " + messageList.ToArray()[i].Count);
        }
    }
}
