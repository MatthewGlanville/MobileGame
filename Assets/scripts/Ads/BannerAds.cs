using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System;

public class BannerAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    // Start is called before the first frame update
    [SerializeField] private string androidAdUnitId;
    [SerializeField] private string iosAdUnitId;
    private string adUnitId;
    private void Awake()
    {
#if UNITY_IOS
adUnitId = iosUnitId;
#elif UNITY_ANDROID
        adUnitId = androidAdUnitId;
#elif UNITY_EDITOR
gameId = androidGameId;
#endif 
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
    }
    public void LoadBannerAd()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = BannerLoaded,
            errorCallbck = BannerLoadedError
        };
        Debug.Log(adUnitId);
        Advertisement.Banner.Load(adUnitId, options);
    }

    private void BannerLoaded()
    {
        
    }

    private void BannerLoadedError(string message)
    {
        
    }
    public void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            showCallback = BannerShown,
            clickCallback = BannerClicked,
            hideCallback = BannerHidden
        };
        Advertisement.Banner.Show(adUnitId,options);

    }

    private void BannerHidden()
    {
  
    }

    private void BannerClicked()
    {

    }

    private void BannerShown()
    {
     
    }
    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
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
