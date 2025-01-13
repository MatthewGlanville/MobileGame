using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;
public class AudioManager : MonoBehaviour
{
    //inspired by https://www.youtube.com/watch?v=yWCHaTwVblk
    public static AudioManager instance {get; private set; } //FMOD unity setup inspired by https://www.youtube.com/watch?v=rcBHIOjZDpk&t=1341s

    [SerializeField] private Slider volumeSlider;
    private Bus audioBus;
    //[SerializeField] private AudioClip[] gameSounds;
    //[SerializeField] private AudioSource audioSource;
    // Start is called before the first frame update
    // Music by https://pixabay.com/users/darknightmares-41814886/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=206176 Jack Cartier from https://pixabay.com//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=206176
    //Laser Sound Effect by https://pixabay.com/users/thefealdoproject-4574887/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=250480">Peter Barbaix</a> from <a href="https://pixabay.com//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=250480">Pixabay</a>
    //Sound Effect from<a href="https://pixabay.com/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=14792"> Pixabay</a>
    //Music by<a href="https://pixabay.com/users/nickpanek620-38266323/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=227035">Nicholas Panek</a> from<a href="https://pixabay.com//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=227035"> Pixabay</a>
    // Sound Effect from <a href="https://pixabay.com/sound-effects/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=103800">Pixabay</a>
    //voice lines created using https://www.narakeet.com/create/robot-voice-text-to-speech.html
    //Sound Effect by<a href="https://pixabay.com/users/phoenix_connection_brazil-6017471/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=108400"> Sandro Lima</a> from<a href="https://pixabay.com/sound-effects//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=108400">Pixabay</a>
    void Start()
    {
        Slider volumeSlider = FindObjectOfType<Slider>();
        if (instance != null)
        {
            Debug.Log("There are multiple AudoManagers, get rid of one of them");
        }
        instance = this;
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
            ChangeSound();
        }
    }
    private void Awake()
    {
        audioBus = RuntimeManager.GetBus("bus:/");
        DontDestroyOnLoad(gameObject);
    }
    void playSound(int soundNum)
    {
        // audioSource.PlayOneShot(gameSounds[soundNum]);
    }
    public void playSound(EventReference soundEvent)
    {
        
         RuntimeManager.PlayOneShot(soundEvent);

     }
    public EventInstance createEventInstance(EventReference soundEvent)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(soundEvent);
        return eventInstance;
    }
    // Update is called once per frame
    void Update()
    {
        Save();
        ChangeSound();

    }
    public void ChangeSound()
    {
        AudioListener.volume = volumeSlider.value; 
    }
    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
