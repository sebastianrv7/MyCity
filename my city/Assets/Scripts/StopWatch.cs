using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class StopWatch : MonoBehaviour
{

    float currentTime;
    public TMP_Text currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        
        TimeSpan TimeSpan = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = TimeSpan.ToString(@"mm\:ss\:ff");
    }
}
