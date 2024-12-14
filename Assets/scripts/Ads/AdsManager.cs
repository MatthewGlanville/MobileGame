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
    [SerializeField] private string bIosAdUnitId;
    [SerializeField] private string bAndroidAdUnitId;
    [SerializeField] private string iIosAdUnitId;
    [SerializeField] private string iAndroidAdUnitId;
    [SerializeField] private string rIosAdUnitId;
    [SerializeField] private string rAndroidAdUnitId;
    private string bannerAdUnitId;
    private string interAdUnitId;
    private string rewardAdUnitId;

    public static AdsManager adInstance {  get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
#if UNITY_IOS
bannerAdUnitId = bIosAdUnitId;
interAdUnitId = iIosAdUnitId;
rewardAdUnitId = rIosAdUnitId;
#elif UNITY_ANDROID
        bannerAdUnitId = bAndroidAdUnitId;
        interAdUnitId = iAndroidAdUnitId;
        rewardAdUnitId = rAndroidAdUnitId;
#elif UNITY_EDITOR
        bannerAdUnitId = bAndroidAdUnitId;
        interAdUnitId = iAndroidAdUnitId;
        rewardAdUnitId = rAndroidAdUnitId;
#endif
        if (adInstance != null && adInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        adInstance = this;
        DontDestroyOnLoad(gameObject);

        bannerAds.LoadBannerAd(bannerAdUnitId);
        interstitialAds.LoadInterstitalAd(interAdUnitId);
        rewardAds.LoadRewardedAd(rewardAdUnitId);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string getAdId(int type)
    {
        switch (type)
        {
            case 0:
                return bannerAdUnitId;
            case 1:
                return interAdUnitId;
            case 2:
                return rewardAdUnitId;
            
        }
        return null;
    }
}
