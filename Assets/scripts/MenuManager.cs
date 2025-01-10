using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CandyCoded.HapticFeedback;
public class MenuManager : MonoBehaviour
{
    [SerializeField] ParticleSystem pS; //buttons from https://loading.io/button/generator#top
    [SerializeField] ParticleSystem pS2; //background from https://www.freepik.com/free-vector/red-laser-grid-cyber-newretrowave-3d-background_50065485.htm
    [SerializeField] private GameObject optionMenu;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip iconPress;
    [SerializeField] private AudioClip laserFire;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        audio.PlayOneShot(menuMusic);
    }
    public void optionsToMain()
    {
        optionMenu.SetActive(false);
        MainMenu.SetActive(true);
        audio.PlayOneShot(iconPress);
        HapticFeedback.LightFeedback();
    }
    public void mainToOptions()
    {
        optionMenu.SetActive(true);
        MainMenu.SetActive(false);
        audio.PlayOneShot(iconPress);
        HapticFeedback.LightFeedback();
    }
    public void StartGame()
    {
        HapticFeedback.LightFeedback();
        audio.PlayOneShot(iconPress);
        audio.PlayOneShot(laserFire);
        pS.Play();
        pS2.Play();
        StartCoroutine(delay());
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainGame");
        audio.Stop();
    }
    public void Quit()
    {
        audio.PlayOneShot(iconPress);
        Quit();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
