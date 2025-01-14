﻿using System.Collections;
using System.Collections.Generic;
//using NaughtyAttributes;
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class AudioTinker : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip outAudioClip;
    private int frequency;
    public System.Random randomized = new System.Random();
    public int freq;
    public int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        freq = Convert.ToInt32(randomized.Next(50, 500));
        outAudioClip = CreateToneAudioClip(freq);

        PlayOutAudio();
        // frequency = 120;
    }

    void Update()
    {

        //outAudioClip = CreateToneAudioClip(freq);
        //frequency = -frequency + 10;
        // PlayOutAudio();
        if (timer % 19 == 0)
            soundy();
        timer++;
    }


    void soundy()
    {
        outAudioClip = CreateToneAudioClip(freq);
        PlayOutAudio();
    }

    // Public APIs
    public void PlayOutAudio()
    {
        audioSource.PlayOneShot(outAudioClip);
    }


    public void StopAudio()
    {
        audioSource.Stop();
    }


    // Private
    private AudioClip CreateToneAudioClip(int frequency)
    {
        int sampleDurationSecs = 2;
        int sampleRate = 44100;
        int sampleLength = sampleRate * sampleDurationSecs;
        float maxValue = 1f / 4f;

        var audioClip = AudioClip.Create("tone", sampleLength, 1, sampleRate, false);

        float[] samples = new float[sampleLength];
        for (var i = 0; i < sampleLength; i++)
        {
            float s = Mathf.Sin(2.0f * Mathf.PI * frequency * ((float)i / (float)sampleRate));
            float v = s * maxValue;
            samples[i] = v;
        }

        audioClip.SetData(samples, 0);
        return audioClip;
    }


#if UNITY_EDITOR
    // [Button("Save Wav file")]
    private void SaveWavFile()
    {
        string path = EditorUtility.SaveFilePanel("Where do you want the wav file to go?", "", "", "wav");
        var audioClip = CreateToneAudioClip(1500);
        //SaveWavUtil.Save(path, audioClip);
    }
#endif
}