using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames.BasicApi;
using GooglePlayGames;
using TMPro;
public class googlePlayScript : MonoBehaviour
{
    public bool connectedToGoogle = false; //set up code from https://www.youtube.com/watch?v=lCZd_URHVK8&t=453s
    [SerializeField] private GameObject manualAuthenticationButton;
    [SerializeField] private GameObject pointlessButton;
    [SerializeField] private TMP_Text text;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        text.text = "platform is activating";
        LogInToGooglePlay();
    }
    private void LogInToGooglePlay()
    { 
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }
    private void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            connectedToGoogle = true;
            Debug.Log("successfully connected");
            manualAuthenticationButton.SetActive(false);
            text.text = "auto succeeded";
            pointlessButton.SetActive(true);
        }
        else
        {
            connectedToGoogle = false;
            Debug.Log("connection failed");
            text.text = "login is failing but the authentication button isnt showing up?";
            manualAuthenticationButton.SetActive(true);
        }
    }
    public void manuallyAuthenticate()
    {
        PlayGamesPlatform.Instance.ManuallyAuthenticate(ProcessAuthentication);
    }
    public void showLeaderboard()
    {
        if (!connectedToGoogle)
        {
            LogInToGooglePlay();
        }
        text.text = "should show achievements";
        Social.ShowLeaderboardUI();
    }
    public void showAchievements()
    {
        if (!connectedToGoogle)
        {
            text.text = "should show leaderboards";
            LogInToGooglePlay();
        }
        Social.ShowAchievementsUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
