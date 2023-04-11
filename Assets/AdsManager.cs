using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
 
public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _AndroidGameId;
    [SerializeField] string _iOSGameId;

    [SerializeField] string _AndroidInterId;
    [SerializeField] string _iOSInterId;

    [SerializeField] string _AndroidRewardedId;
    [SerializeField] string _iOSRewardedId;

    [SerializeField] string _AndroidBannerId;
    [SerializeField] string _iOSBannerId;

    [SerializeField] bool _testMode = true;

    private string _gameId;

    private string _InterId;
    private string _RewardedId;
    private string _BannerId;

    public bool adShowing;

    public int interAdBuffer;

    public iconbuttonmanager iconbuttonmanager;
 
    void Awake()
    {
        interAdBuffer = PlayerPrefs.GetInt("interAdBuffer", 0);
        InitializeAds();
    }
 
    public void InitializeAds()
    {
    #if UNITY_IOS
            _gameId = _iOSGameId;
            _InterId = _iOSInterId;
            _RewardedId = _iOSRewardedId;
            _BannerId = _iOSBannerId;
    #elif UNITY_ANDROID
            _gameId = _AndroidGameId;
            _InterId = _AndroidInterId;
            _RewardedId = _AndroidRewardedId;
            _BannerId = _AndroidBannerId;
    #elif UNITY_EDITOR
            _gameId = _androidGameId;
            _InterId = _AndroidInterId;
            _RewardedId = _AndroidSRewardedId;
            _BannerId = _AndroidBannerId; //Only for testing the functionality in the Editor
    #endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);
        }
        Debug.Log("init ad");
    }

 
    public void OnInitializationComplete(){
        Debug.Log("Unity Ads initialization complete.");
    }
 
    public void OnInitializationFailed(UnityAdsInitializationError error, string message){
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void LoadInterAd() {
        interAdBuffer += 1;

        if (interAdBuffer >= 4) {
            Advertisement.Load(_InterId, this);
            interAdBuffer = 0;
        }
        PlayerPrefs.SetInt("interAdBuffer", interAdBuffer);
    }

    public void LoadRewardedAd() {
        Advertisement.Load(_RewardedId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId) {
        Debug.Log(" OnUnityAdsAdLoaded");
        Advertisement.Show(placementId, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) {
        Debug.Log($"Error showing Ad Unit {placementId} {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) {
        Debug.Log("OnUnityAdsShowFailure");
    }

    public void OnUnityAdsShowStart(string placementId) {
        Debug.Log("OnUnityAdsShowStart");
        Time.timeScale = 0;
        adShowing = true;
        AudioListener.pause = true;
    }

    public void OnUnityAdsShowClick(string placementId) {
        Debug.Log("OnUnityAdsShowClick");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState){
        Debug.Log("OnUnityAdsShowComplete");
        adShowing = false;
        AudioListener.pause = false;

        iconbuttonmanager.Start();
    }
}