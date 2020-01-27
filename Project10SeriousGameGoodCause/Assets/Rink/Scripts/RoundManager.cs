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

    [Header("UI Text Bubble Buttons")]
    [SerializeField] private GameObject[] buttons;

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
        initNewPerson(0);
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

        // TODO: make a function that can start a new round

        // Change the person manually for testing.
        if(Input.GetKeyDown(KeyCode.L))
        {
            try
            {
                initNewPerson(1);
            } catch { }
        }

        // Create 4 new ObjectBubble's to test the Text bubbles
        if (Input.GetKeyDown(KeyCode.K))
        {
            ObjectBubble bubble1 = new ObjectBubble()
            {
                BuisinessOrientedness = 11,
                Intelligence = 12,
                Caringness = 13,
                HealthandStrength = 14,
                TextMessage = "Left"
            };
            ObjectBubble bubble2 = new ObjectBubble()
            {
                BuisinessOrientedness = 21,
                Intelligence = 22,
                Caringness = 23,
                HealthandStrength = 24,
                TextMessage = "Right"
            };
            ObjectBubble bubble3 = new ObjectBubble()
            {
                BuisinessOrientedness = 31,
                Intelligence = 32,
                Caringness = 33,
                HealthandStrength = 34,
                TextMessage = "Top"
            };
            ObjectBubble bubble4 = new ObjectBubble()
            {
                BuisinessOrientedness = 41,
                Intelligence = 42,
                Caringness = 43,
                HealthandStrength = 44,
                TextMessage = "Bottom"
            };

            // Set the data for the new buttons
            SetButtonData(bubble1, bubble2, bubble3, bubble4);
        }
    }

    /// <summary>Start a new round, This will set a new person and should also reset some other stats</summary>
    /// <param name="PersonIncrement">The number that dictates which index in the Person array will get assigned this time, could be changed to the SO itself later</param>
    private void initNewPerson(int PersonIncrement)
    {
        personInDoor.setPersonAttributes((ObjectPerson)soData.people[PersonIncrement]);
        // TODO:    set all attributes and stats under her for the current person. (Maybe. the person should have all information already
        //          because the Person.cs script contains an ObjectPerson SO variable.
    }

    /// <summary>This function will set all the data for the buttons, this needs to be called when a new round is initiated and the buttons need to be reset.</summary>
    /// <param name="leftButtonData"    >Give an object with all the data for the Left Button.  </param>
    /// <param name="rightButtonData"   >Give an object with all the data for the Right Button. </param>
    /// <param name="topButtonData"     >Give an object with all the data for the Top Button.   </param>
    /// <param name="bottomButtonData"  >Give an object with all the data for the Bottom Button.</param>
    public void SetButtonData(ObjectBubble leftButtonData, ObjectBubble rightButtonData, ObjectBubble topButtonData, ObjectBubble bottomButtonData)
    {
        for (int i = 0; i < 4; i++)
        {
            // set the current Button that needs to be changed.
            ObjectBubble currentButton;

            // Check the current button and set currentButton to the correct version.
            ObjectBubble newButtonValue = new ObjectBubble();
            switch (buttons[i].name)
            {
                case "Left Button":
                    newButtonValue = leftButtonData;
                    break;
                case "Right Button":
                    newButtonValue = rightButtonData;
                    break;
                case "Top Button":
                    newButtonValue = topButtonData;
                    break;
                case "Bottom Button":
                    newButtonValue = bottomButtonData;
                    break;
            }

            // set all the values and data for the current ObjectBubble.
            buttons[i].GetComponent<bubbleHoldData>().Bubble = newButtonValue;

            // clear local variables.
            currentButton = null;
            newButtonValue = null;
        }

        // clear local variables.
        leftButtonData = null;
        rightButtonData = null;
        topButtonData = null;
        bottomButtonData = null;
    }

    public void buttonHasBeenClicked(ObjectBubble ClickedObjectBubble)
    {
        //Debug.Log(ClickedObjectBubble.name);

        //float intelligence = ((ClickedObjectBubble.Intelligence / personInDoor.objectPerson.Intelligence) * 0.001f) + 1f;
        //float buisiness = ((ClickedObjectBubble.BuisinessOrientedness / personInDoor.objectPerson.BuisinessOrientedness) * 0.001f) + 1f;
        //float care = ((ClickedObjectBubble.Caringness / personInDoor.objectPerson.Caringness) * 0.001f) + 0.5f;
        //float health = ((ClickedObjectBubble.HealthandStrength / personInDoor.objectPerson.HealthandStrength) * 0.001f) + 1f;

        float intelligence =    (ClickedObjectBubble.Intelligence             / (personInDoor.objectPerson.Intelligence));
        float buisiness =       (ClickedObjectBubble.BuisinessOrientedness    / (personInDoor.objectPerson.BuisinessOrientedness));
        float care =            (ClickedObjectBubble.Caringness               / (personInDoor.objectPerson.Caringness));
        float health =          (ClickedObjectBubble.HealthandStrength        / (personInDoor.objectPerson.HealthandStrength));

        Debug.LogFormat("I {0} / B {1} / C {2} / H {3}", intelligence, buisiness, care, health);

        //Debug.Log(AffectionCount);

        float lastAffectioCount = AffectionCount;

        AffectionCount += (intelligence * buisiness * care * health);

        Debug.LogFormat("name: {0} | AffectionCount: {1} | added AffectionCount: {2}", ClickedObjectBubble.name, AffectionCount, AffectionCount - lastAffectioCount);
    }
}

