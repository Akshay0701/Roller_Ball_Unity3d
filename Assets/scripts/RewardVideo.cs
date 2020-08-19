using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class RewardVideo : MonoBehaviour
{
    string adUnitId;
    AdRequest request;
    private RewardBasedVideoAd rewardBasedVideo;
    // Use this for initialization
    void Start()
    {
        // Get singleton reward based video ad reference.
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        // Called when an ad request has successfully loaded.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

        this.RequestRewardBasedVideo();
    }

    private void RequestRewardBasedVideo()
    {
#if UNITY_ANDROID
adUnitId ="ca-app-pub-7610666034599134/8182888101";
#elif UNITY_IPHONE
string adUnitId ="ca-app-pub-7610666034599134/8182888101";
#else
        string adUnitId ="ca-app-pub-7610666034599134/8182888101";
#endif

        // Create an empty ad request.
        request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, adUnitId);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoClosed event received");
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print("HandleRewardBasedVideoRewarded event received for " + amount.ToString() + "" + type);
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoLeftApplication event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("Rewarded video ad failed to load: " + args.Message);
        // Handle the ad failed to load event.
    }

    public void ShowAd()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();

        }
        RequestRewardBasedVideo();

    }
}
