using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class AdLoader : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string androidGameId; //inspired by https://www.youtube.com/watch?v=seTvVkaU2dk&t=494s 
    [SerializeField] private string iosGameId;
    [SerializeField] private bool isTesting;
    private string gameId;

    public void OnInitializationComplete()
    {
        Debug.Log("Ads initialised"); 
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        
    }

    // Start is called before the first frame update
    private void Awake()
    {
#if UNITY_IOS
gameId = iosGameId;
#elif UNITY_ANDROID
        gameId = androidGameId;
#elif UNITY_EDITOR
gameId = androidGameId;
#endif 
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, isTesting, this);
        }
    }

    // Update is called once per frame

}
