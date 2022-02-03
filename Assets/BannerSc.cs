using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
public class BannerSc : MonoBehaviour
{
    private BannerView bannerView;
    void Start()
    {
        PlayerPrefs.SetInt("Checkpoint", 0);
        MobileAds.Initialize(InitializationStatus => { });
        RequestBanner();

    }

    private void RequestBanner()
    {
        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-9695160848081800/4501870728";
        #elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
        string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
        
    }


    public void DestroyBanner()
    {
        bannerView.Destroy();
    }

}
