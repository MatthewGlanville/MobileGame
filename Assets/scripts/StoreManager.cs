using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    private bool ads = true;
    [SerializeField] private GameObject adFailedText;
    [SerializeField] private GameObject adSuccessText;
    [SerializeField] private float popupTime = 3.0f;
    private float timer; 
    public bool Ads
    {
        get {return ads;}
    }
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void NoAds()
    {
        Debug.Log("there should be no ads");
        ads = false;
    }
    public void OnFailedPurchase()
    {
        Debug.Log("this is working");
        adFailedText.SetActive(true);
        timer = popupTime; 
    }
    public void OnSuccessfulPurchase()
    {
        adSuccessText.SetActive(true);
        timer = popupTime;
    }
    public void PurchaseFailEvent()
    {
        Debug.Log("there was a problem with the purchase");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime; 
            if (timer <= 0)
            {
                if (adFailedText.activeSelf)
                {
                    adFailedText.SetActive(false);
                }
                if (adSuccessText.activeSelf)
                {
                    adSuccessText.SetActive(false);
                }
            }
        }
    }
}