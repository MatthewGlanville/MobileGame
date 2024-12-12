using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private float health = 50;
    [SerializeField] private float maxTimer = 3.0f;
    [SerializeField] private GameObject goal;
    [SerializeField] private AdsManager adsManager;
    private float gamesPlayed;
    private float timer;
    [SerializeField] private GameObject enemy;
    private GameObject enemyClone;
    private Enemy enemyScript;
    private GameObject[] enemies;
    private bool ads = true;
    // Start is called before the first frame update
    void Start()
    {
        timer = maxTimer;
    }
    public void NoAds()
    {
        ads = false; 
    }
    public static GameManager Instance { get; private set; }
    public void takeDmg( int dmg)
    {
        health -= dmg; 
        if (health <= 0)
        {
            gamesPlayed += 1;
            if (gamesPlayed % 1 == 0)
            {
                StartCoroutine(DisplayInterAd());
            }
            SceneManager.LoadScene("MainMenu");
        }
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(DisplayBannerWithDelay());
    }
    private IEnumerator DisplayInterAd()
    {
        yield return new WaitForSeconds(2f);
        AdsManager.adInstance.interstitialAds.ShowInterstitialAd(adsManager.getAdId(1));
    }
    private IEnumerator DisplayBannerWithDelay()
    {
        yield return new WaitForSeconds(5f);
        AdsManager.adInstance.bannerAds.ShowBannerAd(adsManager.getAdId(0));
    }
    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //AdsManager.adInstance.bannerAds.HideBannerAd();
            enemyClone = Instantiate (enemy,this.transform.position,Quaternion.identity);
            enemyScript = enemyClone.GetComponent<Enemy>();
            enemyScript.transform.Rotate(new Vector3(0, 180, 0));
            enemyScript.goal = goal;
            timer = maxTimer;
        }
    }
    public void knockBack(float amount)
    {
        if (enemyClone != null)
        {
            Debug.Log("this is happening");
            enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach(GameObject opponent in enemies)
            {

                opponent.transform.Translate(new Vector3(amount, 0, 0));
            }
        }
    }
}

