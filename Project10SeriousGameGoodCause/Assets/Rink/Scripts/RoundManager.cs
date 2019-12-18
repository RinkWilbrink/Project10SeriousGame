using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Check list
 * 
 * 
 */

public class RoundManager : MonoBehaviour
{
    // Variables
    [Header("Round attributes")]
    [SerializeField] public byte Round;
    [SerializeField] public float AffectionCount = 0;

    [Header("Scriptable Object attributes")]
    [SerializeField] public PersonManager personManager;
    [SerializeField] public Person personInDoor;

    // References to other scripts and Components
    private ScriptableObjectData soData;

    // private variables
    //private float counter;
    
    void Start()
    {
        // Set the ScriptableObjectData variables.
        soData = gameObject.GetComponent<ScriptableObjectData>();

        personInDoor = personManager.GetComponent<PersonManager>().person.GetComponent<Person>();

        // Set a new person
        InitNewRound(0);
    }

    void Update()
    {
        /* Test if the person can switch
        if(counter > 5 && counter < 6) {
            InitNewRound(1);

            counter = 10;
        }
        else {
            counter += Time.deltaTime;
        }
        //*/
    }

    /// <summary>Start a new round, This will set a new person and should also reset some other stats</summary>
    /// <param name="PersonIncrement">The number that dictates which index in the Person array will get assigned this time, could be changed to the SO itself later</param>
    private void InitNewRound(int PersonIncrement)
    {
        personInDoor.setPersonAttributes((ObjectPerson)soData.people[PersonIncrement]);
        // TODO:    set all attributes and stats under her for the current person. (Maybe. the person should have all information already
        //          because the Person.cs script contains an ObjectPerson SO variable.
    }
}

