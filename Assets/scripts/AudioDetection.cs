using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDetection : MonoBehaviour //inspired by https://www.youtube.com/watch?v=dzD0qP8viLw 
{
    public int sampleWindow;
    private AudioClip micClip;
    // Start is called before the first frame update
    private int startPosition;
    void Start()
    {
        MicToAudio();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MicToAudio()
    {
        string micName = Microphone.devices[0];
        micClip = Microphone.Start(micName, true, 20, AudioSettings.outputSampleRate);
    }
    public float GetNoiseFromMic()
    {
        return getNoiseFromClip(Microphone.GetPosition(Microphone.devices[0]), micClip);
    }
    public float getNoiseFromClip(int clipPosition, AudioClip clip)
        
    {
        startPosition = clipPosition - sampleWindow;
        if (startPosition < 0)
        {
            return 0;
        }
        
        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);
        float totalLoudness = 0;
        for (int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }
        return totalLoudness / sampleWindow;
    }
}
