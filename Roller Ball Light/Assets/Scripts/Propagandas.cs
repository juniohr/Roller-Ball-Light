//using UnityEngine.Events;
//using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Propagandas : MonoBehaviour, IUnityAdsListener
{

    public static Propagandas instancia;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
            Advertisement.AddListener(this);
            Advertisement.Initialize("4003231");
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    void Start()
    {
       // StartCoroutine(ShowBannerWhenInitialized());
    }

    public void Teste()
    { 

        Advertisement.Show("rewardedVideo");

    }

     public void ShowRewardedVideo() {
        // Check if UnityAds ready before calling Show method:

        if (Advertisement.IsReady("video")) {
            Advertisement.Show("video");
  
        } 
        else {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
        // Define conditional logic for each ad completion status:

        if (showResult == ShowResult.Finished)
        {
           // UI.inst.video.SetActive(false);
            //UI.inst.botoesInterativos[1].interactable = true;
        }
        else if (showResult == ShowResult.Skipped)
        {
           // UI.inst.video.SetActive(true);
            //UI.inst.botoesInterativos[1].interactable = false;
        }

    }

    IEnumerator ShowBannerWhenInitialized () {
        while (!Advertisement.isInitialized) {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition (BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show("Bannerr");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("");
    }






    /* private BannerView bannerView;
     private InterstitialAd interstitial;
     private RewardedAd rewardedAd;
     public static Propagandas instancia;

     public void Start()
     {
         instancia = this;
         // Initialize the Google Mobile Ads SDK.
         MobileAds.Initialize(initStatus => { });

         this.RequestBanner();
         this.RequestInterstitial();
         this.Watch();
     }
     private void LateUpdate()
     {
         Teste();
     }
     private void RequestBanner()
     {
         #if UNITY_ANDROID
             string adUnitId = "ca-app-pub-5049293979883644/6544877806";
 #elif UNITY_IPHONE
             string adUnitId = "a-app-pub-5049293979883644/7982082557";
 #else
             string adUnitId = "unexpected_platform";
 #endif

         // Create a 320x50 banner at the top of the screen.
         this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

     AdRequest request = new AdRequest.Builder().Build();

     bannerView.LoadAd(request);
     }

     private void RequestInterstitial()
     {
 #if UNITY_ANDROID
         string adUnitId = "ca-app-pub-5049293979883644/7770329566";
 #elif UNITY_IPHONE
         string adUnitId = "ca-app-pub-5049293979883644/3128376978";
 #else
         string adUnitId = "unexpected_platform";
 #endif

         // Initialize an InterstitialAd.
         this.interstitial = new InterstitialAd(adUnitId);

         // Create an empty ad request.
         AdRequest request = new AdRequest.Builder().Build();
         // Load the interstitial with the request.
         this.interstitial.LoadAd(request);
     }

     public void GameOver()
     {
         if (this.interstitial.IsLoaded())
         {
             this.interstitial.Show();
         }
     }

     public void Watch()
     {
         string adUnitId;
 #if UNITY_ANDROID
         adUnitId = "ca-app-pub-5049293979883644/5666076257";
 #elif UNITY_IPHONE
             adUnitId = "ca-app-pub-3940256099942544/1712485313";
 #else
             adUnitId = "unexpected_platform";
 #endif

         this.rewardedAd = new RewardedAd(adUnitId);

         this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
         this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
         this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

         // Create an empty ad request.
         AdRequest request = new AdRequest.Builder().Build();
         // Load the rewarded ad with the request.
         this.rewardedAd.LoadAd(request);
     }

         public void UserChoseToWatchAd()
     {
         if (this.rewardedAd.IsLoaded())
         {
             this.rewardedAd.Show();
         }
     }

     public void HandleRewardedAdClosed(object sender, EventArgs args)
     {
         MonoBehaviour.print("HandleRewardedAdClosed event received");

         this.Watch();
     }

     public void HandleRewardedAdLoaded(object sender, EventArgs args)
     {
         MonoBehaviour.print("HandleRewardedAdLoaded event received");
     }

     public void HandleUserEarnedReward(object sender, Reward args)
     {
         string type = args.Type;
         double amount = args.Amount;
         MonoBehaviour.print(
             "HandleRewardedAdRewarded event received for "
                         + amount.ToString() + " " + type);

         UI.inst.botoesInterativos[1].interactable = true;
     }

     public void Teste()
     {
         if (UI.inst.botoesInterativos[1].interactable == false && UI.inst.objsNaCena[3] != null && UI.inst.fecharUI.activeInHierarchy == false)
         {
             UI.inst.video.SetActive(true);
         }
         else
         {
             UI.inst.video.SetActive(false);
         }
     }*/
}
