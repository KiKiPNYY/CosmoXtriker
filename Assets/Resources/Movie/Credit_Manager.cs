using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit_Manager : MonoBehaviour
{
    [SerializeField] private GameObject Credit1;
    [SerializeField] private GameObject Credit2;
    [SerializeField] private GameObject Credit3;
    [SerializeField] private GameObject Credit4;
    [SerializeField] private GameObject Credit5;
    [SerializeField] private GameObject Credit6;
    [SerializeField] private GameObject Credit7;
    [SerializeField] private GameObject Credit8;
    [SerializeField] private GameObject Credit9;
    [SerializeField] private GameObject Credit10;
    [SerializeField] private GameObject Credit11;

    float seconds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if(seconds >= 3)
        {
            Credit1.SetActive(true);
        }
        if(seconds >= 5)
        {
            Credit2.SetActive(true);
        }
        if(seconds >= 7)
        {
            Credit3.SetActive(true);
        }
        if(seconds >= 10)
        {
            Credit4.SetActive(true);
        }
        if (seconds >= 10)
        {
            Credit5.SetActive(true);
        }
        if (seconds >= 11)
        {
            Credit6.SetActive(true);
        }
        if (seconds >= 13)
        {
            Credit7.SetActive(true);
        }
        if (seconds >= 14)
        {
            Credit8.SetActive(true);
        }
        if (seconds >= 16)
        {
            Credit9.SetActive(true);
        }
        if (seconds >= 8)
        {
            Credit10.SetActive(true);
        }
        if (seconds >= 17)
        {
            Credit11.SetActive(true);
        }
    }
}
