using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Person", menuName = "DialogSystem/Person", order = 1)]
public class ObjectPerson : PersonalityTraits
{
    [Header("Person specific values and settings")]
    // Input some Person Scriptable Object specific items here
    public string PersonName;
}
