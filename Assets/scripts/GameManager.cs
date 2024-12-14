using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private float maxHealth = 50;
    [SerializeField] private float maxTimer = 3.0f;
    [SerializeField] private GameObject goal;
    [SerializeField] private AdsManager adsManager;
    [SerializeField] private GameObject livesFailedText;
    [SerializeField] private Canvas mainCanvas; 
    [SerializeField] private Canvas gameOverCanvas;
    private float health;
    private float gamesPlayed;
    private float timer;
    private float livesFailedTimer; 
    [SerializeField] private GameObject enemy;
    private GameObject enemyClone;
    private Enemy enemyScript;
    private GameObject[] enemies;
    private bool ads = true;
    private bool activeBanner = false;
    [SerializeField] StoreManager storeManager;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        mainCanvas.gameObject.SetActive(true);
        gameOverCanvas.gameObject.SetActive(false);
        storeManager = FindAnyObjectByType<StoreManager>();
        timer = maxTimer;
        ads = storeManager.Ads;
        Debug.Log(ads + " dfibifsdchbifdsbuiwdehbidshbi");
    }
    public static GameManager Instance { get; private set; }
    public void buyExtraHealth (int amount)
    {
        health += amount;
        Time.timeScale = 1.0f; 
    }
    public void Pause()
    {
        Time.timeScale = 0.0f;
    }
    public void OnLifeFailed()
    {
        Time.timeScale = 1.0f;
        livesFailedText.SetActive(true);
        livesFailedTimer = 3.0f; 

    }
    public void takeDmg( int dmg)
    {
        health -= dmg; 
        if (health <= 0)
        {
            gamesPlayed += 1;
            timer = maxTimer;
            if (gamesPlayed % 1 == 0 && ads)
            {
                StartCoroutine(DisplayInterAd());
            }
            mainCanvas.gameObject.SetActive(false);
            gameOverCanvas.gameObject.SetActive(true);
        }
    }
    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(gameObject);
        if (ads)
        {
            StartCoroutine(DisplayBannerWithDelay());
        }
    }
    private IEnumerator DisplayInterAd()
    {
        yield return new WaitForSeconds(2f);
        AdsManager.adInstance.interstitialAds.ShowInterstitialAd(adsManager.getAdId(1));
        
    }
    private IEnumerator DisplayBannerWithDelay()
    {
        yield return new WaitForSeconds(2f);
        AdsManager.adInstance.bannerAds.ShowBannerAd(adsManager.getAdId(0));
        activeBanner = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!ads && activeBanner)
        {
            AdsManager.adInstance.bannerAds.HideBannerAd();
            activeBanner = false;
            Debug.Log("wauwauwauwauw");
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            enemyClone = Instantiate (enemy,this.transform.position,Quaternion.identity);
            enemyScript = enemyClone.GetComponent<Enemy>();
            enemyScript.transform.Rotate(new Vector3(0, 180, 0));
            enemyScript.goal = goal;
            timer = maxTimer;
        }
        if (livesFailedTimer > 0)
        {
            livesFailedTimer-= Time.deltaTime;
            if (livesFailedTimer <= 0)
            {
                livesFailedText.SetActive(false);
            }
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
    private void OnGUI()
    {
        GUI.Box(new Rect(10, 200, 300, 100), "Health:" + health);
    }
}

