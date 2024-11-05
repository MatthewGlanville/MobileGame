using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour //https://www.youtube.com/watch?v=seTvVkaU2dk&t=494s
{
    public AdLoader adLoader;
    public BannerAds bannerAds;
    public InterstitialAds interstitialAds;
    public RewardAds rewardAds;
    public static AdsManager adInstance {  get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        if (adInstance != null && adInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        adInstance = this;
        DontDestroyOnLoad(gameObject);

        bannerAds.LoadBannerAd();
        interstitialAds.LoadInterstitalAd();
        rewardAds.LoadRewardedAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
