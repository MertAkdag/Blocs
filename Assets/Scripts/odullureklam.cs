using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using System;

public class odullureklam : MonoBehaviour
{
    private RewardedAd rewardedAd;
    string reklamAdi;
    public GameObject canlanmabuton;
    bool izlendi;
    public PlayerController playerController;
    public GameController gameController;

    public void Start()
    {
        string adUnitId;
        #if UNITY_ANDROID
            adUnitId = "ca-app-pub-3940256099942544/5224354917";
        #elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
            adUnitId = "unexpected_platform";
        #endif

        izlendi = false;

        MobileAds.Initialize(initStatus => { });

        this.rewardedAd = new RewardedAd(adUnitId);

        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);
    }



    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        if (reklamAdi == "canlandirma")
        {
            playerController.isDead = false;
            Destroy(playerController.carptigimizobje.gameObject);
            gameController.gameOverPanel.SetActive(false);
            playerController.rb.isKinematic = false;
        }
    }

    public void UserChoseToWatchAd(string reklamAdis)
    {
        reklamAdi = reklamAdis;
        if (this.rewardedAd.IsLoaded() && !izlendi) {
            canlanmabuton.SetActive(false);
            Destroy(GetComponent<Rigidbody>());
            this.rewardedAd.Show();
        }
    }

    
}
