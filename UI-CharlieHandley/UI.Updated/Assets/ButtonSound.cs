﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource myFX;
    public AudioClip hoverFx;
    public AudioClip clickFx;


    public void HoverSound()
    {
        myFX.PlayOneShot(hoverFx);
    }
    public void Clicksound()
    {
        myFX.PlayOneShot(clickFx);
    }

}

