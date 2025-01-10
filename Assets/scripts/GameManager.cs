using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CandyCoded.HapticFeedback;
using FMODUnity;
using MobileGame;
using FMOD.Studio;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private float maxHealth = 50;
    [SerializeField] private float maxTimer = 3.0f;
    [SerializeField] private GameObject goal;
    [SerializeField] private AdsManager adsManager;
    [SerializeField] private GameObject livesFailedText;
    [SerializeField] private Canvas mainCanvas; 
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip[] hitSounds;
    [SerializeField] private AudioClip music;
    [SerializeField] private AudioSource audio;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text moneyText;
    private AudioManager audioManager;
    private float health;
    private float money = 50;
    public float Money { get {
            return money;
        }
        set {
            money = value;
        } }
    private float gamesPlayed;
    private float timer;
    private float survivalTimer = 0.0f;
    private googlePlayScript googlePlay; 
    private float livesFailedTimer; 
    [SerializeField] private GameObject enemy;
    private GameObject enemyClone;
    private Enemy enemyScript;
    private GameObject[] enemies;
    private bool gameEnded;
    private bool ads = true;
    private bool activeBanner = false;
    [SerializeField] StoreManager storeManager;
    // Start is called before the first frame update
    void Start()
    {
        gameEnded = false;
        money = 50;
        audio.PlayOneShot(gameMusic);
        googlePlay = FindObjectOfType<googlePlayScript>();
        audioManager = FindObjectOfType<AudioManager>();
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
        if (money >= 10)
        {
            money -= 10;
        }
        health -= dmg;
        if (health < 0)
        {
            health = 0;
        }
        Debug.Log(audioManager);
        int random = UnityEngine.Random.Range(0, hitSounds.Length);
        audio.PlayOneShot(hitSounds[random]);
        if (health <= 0)
        {
            gamesPlayed += 1;
            if ((googlePlay != null) && (googlePlay.connectedToGoogle))
            {
                Social.ReportScore((long)survivalTimer, GPGSIds.leaderboard_salesmanslaying_champions, LeaderboardUpdate);
                if(survivalTimer > 180)
                {
                    Social.ReportProgress("CgkIuY-Wtp4KEAIQAg", 100.0, (bool success) =>
                    {
                        if (success) {
                            Debug.Log("Achievement Unlocked: Survivalist");
                        }
                        else
                        {
                            Debug.Log("Achievement Error");
                        }
                    });
                }
            }
            timer = maxTimer;
            survivalTimer = 0.0f;

            if (gamesPlayed % 1 == 0 && ads)
            {
                if((googlePlay!=null ) && (googlePlay.connectedToGoogle) && gamesPlayed>14)
                {
                    Social.ReportProgress("CgkIuY-Wtp4KEAIQBQ", 100.0, (bool success) =>
                    {
                        if (success)
                        {
                            Debug.Log("Achievement Unlocked: Scammed");
                        }
                        else
                        {
                            Debug.Log("Achievement Unlocked: breaking the achievement system");
                        }
                    });
                    if (gamesPlayed > 49)
                    {
                        Social.ReportProgress("CgkIuY-Wtp4KEAIQBA", 100.0, (bool success) =>
                        {
                            if (success)
                            {
                                Debug.Log("Achievement Unlocked: Long term resentment");
                            }
                            else
                            {
                                Debug.Log("Achievement Unlocked: breaking the achievement system");
                            }
                        });
                    }
                }
                StartCoroutine(DisplayInterAd());
                audio.Stop();
            }
            gameEnded = true;
            mainCanvas.gameObject.SetActive(false);
            gameOverCanvas.gameObject.SetActive(true);
        }
    }
    private void LeaderboardUpdate(bool success)
    {
        if (success)
        {
            Debug.Log("updated leaderboard");
        }
        else
        {
            Debug.Log("Failed to update leaderboard");
        }
    }
    public void backToMenu()
    {
        HapticFeedback.LightFeedback();
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
        healthText.text = "Health:" + health;
        timerText.text = "Timer: " + survivalTimer;
        moneyText.text = "Money: " + money;

        survivalTimer += Time.deltaTime;
        if (!ads && activeBanner)
        {
            AdsManager.adInstance.bannerAds.HideBannerAd();
        }
        timer -= Time.deltaTime;
        if ((timer <= 0)&& (!gameEnded))
        {
            money += 3;
            enemyClone = Instantiate (enemy,this.transform.position + new Vector3(0,0,UnityEngine.Random.Range(-300,300)),Quaternion.identity);
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
    public void addKill()
    {
        if ((googlePlay != null) && (googlePlay.connectedToGoogle) && gamesPlayed > 14)
        {
            Social.ReportProgress("CgkIuY-Wtp4KEAIQAQ", 100.0, (bool success) =>
            {
                if (success)
                {
                    Debug.Log("Achievement Unlocked: Rolling Death");
                }
                else
                {
                    Debug.Log("Achievement Unlocked: breaking the achievement system");
                }
            });
        }
    }
    public void knockBack(float amount)
    {
        if (enemyClone != null)
        {
            enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach(GameObject opponent in enemies)
            {
                if (!gameEnded)
                {
                    opponent.transform.Translate(new Vector3(amount, 0, 0));
                }
                else
                {
                    Destroy(opponent);
                }
            }
        }
    }
}

