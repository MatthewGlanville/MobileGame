using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RewardAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string androidAdUnitId;
    [SerializeField] private string iosAdUnitId;
    private string adUnitId;
    // Start is called before the first frame update
    private void Awake()
    {
#if UNITY_IOS
adUnitId = iosUnitId;
#elif UNITY_ANDROID
        adUnitId = androidAdUnitId;
#elif UNITY_EDITOR
gameId = androidGameId;
#endif 
    }
    public void LoadRewardedAd()
    {
        Advertisement.Load(adUnitId, this);
    }
    public void ShowRewardedAd()
    {
        Advertisement.Show(adUnitId, this);
        LoadRewardedAd();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    #region LoadCallBacks
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Interstitial Ad Loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {

    }
    #endregion
    #region ShowCallbacks
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {

    }

    public void OnUnityAdsShowStart(string placementId)
    {

    }

    public void OnUnityAdsShowClick(string placementId)
    {

    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId == adUnitId && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Ads Fully watched"); // will handle it later
        }
    }
    #endregion
}
