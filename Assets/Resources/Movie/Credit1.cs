﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Credit1 : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private RawImage rawImage;
    private bool check = false;
    float seconds;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 0.3)
        {
            videoPlayer.Play();
        }
        if (seconds >= 5.3)
        {
            videoPlayer.Pause();
        }
    }
}
