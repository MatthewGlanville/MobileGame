using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFromAudio : MonoBehaviour //also inspired by https://www.youtube.com/watch?v=dzD0qP8viLw
{
    [SerializeField] private AudioSource source;
    [SerializeField] private Vector3 minScale;
    [SerializeField] private Vector3 maxScale;
    [SerializeField] private AudioDetection aD; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = aD.getNoiseFromClip(source.timeSamples, source.clip);
        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
    }
}
