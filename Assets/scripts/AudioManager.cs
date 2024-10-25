using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    //inspired by https://www.youtube.com/watch?v=yWCHaTwVblk
    
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioClip[] gameSounds;
    [SerializeField] private AudioSource audioSource;
    // Start is called before the first frame update
    // Music by https://pixabay.com/users/darknightmares-41814886/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=206176 Jack Cartier from https://pixabay.com//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=206176
    //Sound Effect by https://pixabay.com/users/thefealdoproject-4574887/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=250480">Peter Barbaix</a> from <a href="https://pixabay.com//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=250480">Pixabay</a>
    //Sound Effect from<a href="https://pixabay.com/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=14792"> Pixabay</a>
    //Music by<a href="https://pixabay.com/users/nickpanek620-38266323/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=227035">Nicholas Panek</a> from<a href="https://pixabay.com//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=227035"> Pixabay</a>
    // Sound Effect from <a href="https://pixabay.com/sound-effects/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=103800">Pixabay</a>
    //
    //Sound Effect by<a href="https://pixabay.com/users/phoenix_connection_brazil-6017471/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=108400"> Sandro Lima</a> from<a href="https://pixabay.com/sound-effects//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=108400">Pixabay</a>
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
    }
    void playSound(int soundNum)
    {
        audioSource.PlayOneShot(gameSounds[soundNum]);
    }
    // Update is called once per frame
    void Update()
    {
        Save();

    }
    public void ChangeSound()
    {
        AudioListener.volume = volumeSlider.value; 
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
