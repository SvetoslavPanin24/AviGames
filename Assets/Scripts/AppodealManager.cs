using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using UnityEngine;

public class AppodealManager : MonoBehaviour, IRewardedVideoAdListener
{
    public static AppodealManager instance;
    private const string APP_KEY = "fee50c333ff3825fd6ad6d38cff78154de3025546d47a84f";

    [SerializeField] private bool isTestingMode;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Initialized();
    }

    private void Initialized()
    {
        Appodeal.setTesting(isTestingMode);

        Appodeal.disableLocationPermissionCheck();

        Appodeal.muteVideosIfCallsMuted(true);

        Appodeal.initialize(APP_KEY, Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO);

        Appodeal.setRewardedVideoCallbacks(this);
    }

    public void ShowInterAds()
    {
        if(Appodeal.canShow(Appodeal.INTERSTITIAL))
        {
            Appodeal.show(Appodeal.INTERSTITIAL);
        }       
    }

    public void ShowRewardedAds()
    {
        if (Appodeal.canShow(Appodeal.REWARDED_VIDEO))
        {
            Appodeal.show(Appodeal.REWARDED_VIDEO);
        }
    }

    public void onRewardedVideoShowFailed()
    {

    }

    public void onRewardedVideoLoaded(bool precache)
    {
 
    }

    public void onRewardedVideoFailedToLoad()
    {
         
    }

    public void onRewardedVideoShown()
    {
      
    }

    public void onRewardedVideoFinished(double amount, string name)
    {
 
    }

    public void onRewardedVideoClosed(bool finished)
    {
   
    }

    public void onRewardedVideoExpired()
    {
      
    }

    public void onRewardedVideoClicked()
    {
   
    }
}

