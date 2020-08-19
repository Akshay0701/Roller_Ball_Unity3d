using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AdScript : MonoBehaviour
{

    bool hasShownAdOneTime;

    // Use this for initialization
    void Start()
    {
        hasShownAdOneTime = false;
        //Request Ad
        RequestInterstitialAds();
    }

   public void Update()
    {
        if (fadeout.isGameOver)
        {
            if (!hasShownAdOneTime)
            {
                hasShownAdOneTime = true;
                Invoke("showInterstitialAd", 3.0f);
            }
        }
    }

    public void showInterstitialAd()
    {
        //Show Ad
        if (interstitial.IsLoaded())
        {
            interstitial.Show();

            //Stop Sound
            //

            Debug.Log("SHOW AD XXX");
        }

    }

    InterstitialAd interstitial;
    private void RequestInterstitialAds()
    {
        string adID = "ca-app-pub-7610666034599134/5767913103";

#if UNITY_ANDROID
        string adUnitId = adID;
#elif UNITY_IOS
        string adUnitId = adID;
#else
        string adUnitId = adID;
#endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);

        //***Test***
        AdRequest request = new AdRequest.Builder()
       .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
       .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")  // My test device.
       .Build();
       
        //***Production***
       // AdRequest request = new AdRequest.Builder().Build();

        //Register Ad Close Event
        interstitial.OnAdClosed += Interstitial_OnAdClosed;

        // Load the interstitial with the request.
        interstitial.LoadAd(request);

        Debug.Log("AD LOADED XXX");

    }

    //Ad Close Event
    private void Interstitial_OnAdClosed(object sender, System.EventArgs e)
    {
        //Resume Play Sound

    }
}