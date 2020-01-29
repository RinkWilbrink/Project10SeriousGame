using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleHoldData : MonoBehaviour
{
    // Variables
    [SerializeField] private ObjectBubble bubbleData_ObjectBubble;

    void Update()
    {
        SetTextBubbleData();
    }

    void SetTextBubbleData(){
        gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = bubbleData_ObjectBubble.TextMessage;
    }

    // Get / Set the bubbleData_ObjectBubble value;
    public ObjectBubble Bubble
    {
        get => bubbleData_ObjectBubble;
        set => bubbleData_ObjectBubble = value;
    }
}

