using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables
    private byte roundNumber;

    void Update()
    {
        
    }

    void newRound(ObjectBubble newBubble)
    {
        if(newBubble.name == string.Format("{0}.1", roundNumber)) {
            
        }
        else if(newBubble.name == string.Format("{0}.2", roundNumber)) {
            
        }
        else if(newBubble.name == string.Format("{0}.3", roundNumber)) {
            
        }
        else if(newBubble.name == string.Format("{0}.4", roundNumber)) {
            
        }
        else{
            Debug.LogFormat("{0} does not have the proper name for this round or is supposed to be in another round!", newBubble.name);
        }
    }
}