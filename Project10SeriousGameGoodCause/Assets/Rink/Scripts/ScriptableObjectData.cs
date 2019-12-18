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
    [SerializeField] public List<List<Object>> messageList = new List<List<Object>>();

    void Awake()
    {
        people = Resources.LoadAll("DialogSystemObjects", typeof(ObjectPerson));
        messages = Resources.LoadAll("DialogSystemObjects", typeof(ObjectBubble));

        /*
         * Global List,
         * 
         * Check alleen het getal voor de _ en stop alle objecten die met dat getal beginnen
         * in een list en .Add die list dan in de List<List<Object>>.
         * 
         */

        // Go through all objects and
        for (int round = 1; round <= messages.Length; round++)
        {
            List<Object> roundList = new List<Object>();
            for (int i = 0; i < messages.Length; i++)
            {
                string[] name = messages[i].name.Split('_');
                if (name[0] == round.ToString())
                {
                    //Debug.LogFormat("name is {0}!", round);
                    roundList.Add(messages[i]);
                }
                // Cleanup memory from local variables
                name = null;
            }

            // Check if the list has any content, if so add it to the global list
            if(roundList.Count > 0) {
                messageList.Add(roundList);
            }
            else {
                //Debug.LogFormat("round list count: {0} | {1}", roundList.Count, round);
            }

            // Cleanup local variable
            roundList = null;
        }

        //LogListContentAndInfo();
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