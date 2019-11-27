using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptableObjects : MonoBehaviour
{
    // Variables
    [SerializeField] ObjectPerson[] personArray;
    
    void Start()
    {
        for (int i = 0; i < personArray.Length; i++)
        {
            //Debug.LogFormat("array number: {0} | Intelligence: {1} | Buisiness: {2} | Caringness: {3} | Person's Name: {4}", i, 
            //personArray[i].Intelligence, personArray[i].BuisinessOrientedness, personArray[i].Caringness, personArray[i].PersonName);
        }
    }
    
    void Update()
    {
        
    }
}

