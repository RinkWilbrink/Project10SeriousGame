using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] RoundManager roundManager;
    private ScriptableObjectData objectData;

    void Start()
    {
        // set the object data to the correct script instance.
        objectData = GameObject.Find("Round Manager").GetComponent<ScriptableObjectData>();
    }
    
    public void OnBubbleClick(GameObject bubbleObject){
        // Give data
        roundManager.buttonHasBeenClicked(bubbleObject.GetComponent<bubbleHoldData>().Bubble);
    }
}
