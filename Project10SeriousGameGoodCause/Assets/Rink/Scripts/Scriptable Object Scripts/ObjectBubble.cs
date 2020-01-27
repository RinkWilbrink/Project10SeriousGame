using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextBubble", menuName = "DialogSystem/TextBubble SO", order = 1)]
///<summary>TextMessage</summary>
public class ObjectBubble : PersonalityTraits
{    
    [Header("Text bubble specific items")]
    // Add your variables here.
    public string TextMessage;
}