using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushOnAudio : MonoBehaviour //also inspired by https://www.youtube.com/watch?v=dzD0qP8viLw
{
    [SerializeField] private AudioSource source;
    [SerializeField] private Vector3 minScale;
    [SerializeField] private Vector3 maxScale;
    [SerializeField] private AudioDetection aD;
    [SerializeField] private float loudnessSens = 100;
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private GameManager gM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float loudness = aD.GetNoiseFromMic() * loudnessSens;
        if (loudness < threshold)
        {
            loudness = 0;
        }
        gM.knockBack(Vector3.Lerp(minScale, maxScale, loudness).x);
    }
}
