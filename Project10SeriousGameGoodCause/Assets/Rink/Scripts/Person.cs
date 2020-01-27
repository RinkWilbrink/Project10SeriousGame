using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    // Variables
    [Header("Person Infomation")]
    [SerializeField] public ObjectPerson objectPerson;

    [Header("Asset information")]
    [SerializeField] private SpriteRenderer Face;
    [SerializeField] private SpriteRenderer Body;

    [Header("Gameplay stats")]
    // The amount the person has been confinced that he should help/donate.
    [SerializeField] public float affectionMeter;

    public void setPersonAttributes(ObjectPerson newPerson)
    {
        objectPerson = newPerson;

        // Set all the values and sprites of this person from the SO here.
        Face.sprite = objectPerson.Face;
        //Body.sprite = objectPerson.Body;
    }
}

