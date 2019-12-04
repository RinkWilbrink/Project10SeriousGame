using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    private ScriptableObjectData objectData;

    void Start()
    {
        // set the object data to the correct script instance.
        objectData = GameObject.Find("Game Manager").GetComponent<ScriptableObjectData>();
    }
    
    public void OnBubbleClick(GameObject bubbleObject){
        bubbleHoldData bubbleData = bubbleObject.GetComponent<bubbleHoldData>();

        bubbleData.Bubble = (ObjectBubble)objectData.messages[0];
    }
}
