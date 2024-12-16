

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
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void optionsToMain()
    {
        optionMenu.SetActive(false);
        MainMenu.SetActive(true);
        HapticFeedback.LightFeedback();
    }
    public void mainToOptions()
    {
        optionMenu.SetActive(true);
        MainMenu.SetActive(false);
        HapticFeedback.LightFeedback();
    }
    public void StartGame()
    {
        HapticFeedback.LightFeedback();
        pS.Play();
        Debug.Log("WORK");
        pS2.Play();
        StartCoroutine(delay());
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainGame");
    }
    public void Quit()
    {
        Quit();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
