using System;
using UnityEngine;
using GoogleMobileAds.Api;


public class AdMobManager : MonoBehaviour
{
    private InterstitialAd interstitial;

    void Start() {
        RequestInterstitial();
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);

        // Called when the ad is closed.
        interstitial.OnAdClosed += HandleOnAdClosed;
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        print("HandleAdClosed event received");

        interstitial.Destroy();

        RequestInterstitial();
    }

    public void ShowInterstitial() {
        if(!interstitial.IsLoaded())
        {
            RequestInterstitial();
            return;
        }

        interstitial.Show();

    }

}
