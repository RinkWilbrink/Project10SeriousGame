using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalityTraits : ScriptableObject
{
    // The amount of impact the question will have on certain personality traits
    [Header("Personality Trait Values")]
    // Defines how much a person values Inteligence and science.
    [Range(1, 100)] public byte Intelligence;
    // Defines how much a person cares about buisiness and work
    [Range(1, 100)] public byte BuisinessOrientedness;
    // Defines how much a person cares about others and their health
    [Range(1, 100)] public byte Caringness;
    // Defines how much a person cares about health and muscles
    [Range(1, 100)] public byte HealthandStrength;
}
