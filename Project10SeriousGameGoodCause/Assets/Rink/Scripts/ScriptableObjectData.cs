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
    [Space(5)]
    [Header("List of with all objects")]
    [SerializeField] public List<List<ObjectBubble>> messageList = new List<List<ObjectBubble>>();

    void Awake()
    {
         people = Resources.LoadAll("DialogSystemObjects", typeof(ObjectPerson));
         messages = Resources.LoadAll("DialogSystemObjects", typeof(ObjectBubble));

        // Go through all objects and at them to their appropriate List in the Global List
        for (int round = 1; round <= messages.Length; round++)
        {
            List<ObjectBubble> roundList = new List<ObjectBubble>();
            for (int i = 0; i < messages.Length; i++)
            {
                string[] name = messages[i].name.Split('_');
                // Check current message object if it should be added to this round
                if (name[0] == round.ToString())
                {
                    roundList.Add((ObjectBubble)messages[i]);
                }

                // Cleanup memory from local variables
                name = null;
            }

            // Check if the list has any content, if so add it to the global list
            if(roundList.Count > 0) {
                messageList.Add(roundList);
            }

            // Cleanup local variable
            roundList = null;
        }
    }

    private void LogListContentAndInfo()
    {
        Debug.LogFormat("messageList.Count {0}", messageList.Count);
        // Check whats inside the shit

        for (int i = 0; i < messageList.Count; i++)
        {
            for (int j = 0; j < messageList.ToArray()[i].Count; j++)
            {
                Debug.LogFormat("name in List {0}: {1}", i, messageList.ToArray()[i].ToArray()[j].name);
            }
        }
    }
}