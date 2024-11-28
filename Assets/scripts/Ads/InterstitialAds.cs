using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour , IUnityAdsLoadListener, IUnityAdsShowListener
{
    // Start is called before the first frame update
    [SerializeField] private string androidAdUnitId;
    [SerializeField] private string iosAdUnitId;
    private string adUnitId;
    private void Awake()
    {

    }
    public void LoadInterstitalAd(string adUnitId)
    {
        Advertisement.Load(adUnitId, this);
    }
    public void ShowInterstitialAd(string adUnitId)
    {
        Advertisement.Show(adUnitId, this);
        LoadInterstitalAd(adUnitId);
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

    }
    #endregion
}
