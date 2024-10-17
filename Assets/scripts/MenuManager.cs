

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class MenuManager : MonoBehaviour
{
    [SerializeField] ParticleSystem pS;
    [SerializeField] ParticleSystem pS2;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartGame()
    {
        //pS.Play();
        Debug.Log("WORK");
        //pS2.Play();
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
