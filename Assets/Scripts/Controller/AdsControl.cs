﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.SocialPlatforms;
using GoogleMobileAds.Api;
using UnityEngine.Advertisements;

public class AdsControl : MonoBehaviour
{
	
	
	protected AdsControl ()
	{
	}

	private static AdsControl _instance;

	ShowOptions options;
	InterstitialAd interstitial;

	public string AdmobID_Android, AdmobID_IOS, UnityID_Android, UnityID_IOS, UnityZoneID;

	public static AdsControl Instance { get { return _instance; } }

	void Awake ()
	{
		
		if (FindObjectsOfType (typeof(AdsControl)).Length > 1) {
			Destroy (gameObject);
			return;
		}
		
		_instance = this;
		MakeNewInterstial ();

		
		DontDestroyOnLoad (gameObject); //Already done by CBManager


		if (Advertisement.isSupported) { // If the platform is supported,
			#if UNITY_IOS
			Advertisement.Initialize (UnityID_IOS); // initialize Unity Ads.
			#endif

			#if UNITY_ANDROID
			Advertisement.Initialize (UnityID_Android); // initialize Unity Ads.
			#endif
		}
		options = new ShowOptions ();
		options.resultCallback = HandleShowResult;

	

	}


	public void HandleInterstialAdClosed (object sender, EventArgs args)
	{
	
		#if ADS_PLUGIN

		if (interstitial != null)
			interstitial.Destroy ();
		MakeNewInterstial ();
	
		#endif
		
	}

	void MakeNewInterstial ()
	{


#if UNITY_ANDROID
		interstitial = new InterstitialAd (AdmobID_Android);
#endif
#if UNITY_IPHONE
		interstitial = new InterstitialAd (AdmobID_IOS);
#endif
		interstitial.OnAdClosed += HandleInterstialAdClosed;
		AdRequest request = new AdRequest.Builder ().Build ();
		interstitial.LoadAd (request);


	}


	public void showAds ()
	{
		
	
		interstitial.Show ();
	
	

	}


	public bool GetRewardAvailable ()
	{
		bool avaiable = false;

		return avaiable;
	}

	public void ShowRewardVideo ()
	{

		Advertisement.Show (UnityZoneID, options);
	
		Debug.Log ("Show RW");
		
	}

	public void HideBannerAds ()
	{
	}

	public void ShowBannerAds ()
	{
	}

	private void HandleShowResult (ShowResult result)
	{
		switch (result) {
		case ShowResult.Finished:
			//GameData.AddCash (1);
			FindObjectOfType<GetItem> ().GetItemFree ();
			break;
		case ShowResult.Skipped:
			break;
		case ShowResult.Failed:
			break;
		}
	}

}

