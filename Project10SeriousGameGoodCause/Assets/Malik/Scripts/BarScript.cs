using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    [SerializeField]private Image Impressionbar;
    [Range(0, 1)]
    [SerializeField]
    private float Impression;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Impressionbar.fillAmount = Impression;
    }
}
