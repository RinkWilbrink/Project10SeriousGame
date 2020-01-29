using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    [SerializeField]private Image Impressionbar;  
    
    private float _impression;

    public float MaxImpression;

    void Update()
    {
        ClampTheValues();
        Impressionbar.fillAmount = 1 / MaxImpression * _impression;
    }

    void ClampTheValues()
    {
        _impression = Mathf.Clamp(_impression,0,100);
    }

    public void AddImpression(float value)
    {
        _impression = _impression + value;
    }

    public void MinImpression(float value)
    {
        _impression = _impression - value;
    }
}
