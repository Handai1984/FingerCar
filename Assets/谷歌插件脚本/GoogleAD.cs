using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds;


public class GoogleAD : MonoBehaviour {
	public string appIdAll;
	public string appIdBanner;
	public string appIdInterstial;
	public string phoneId;

		private  BannerView bannerView;
		private InterstitialAd interstitial;
		
	public void Awake()
	{
		GoogleInite ();
	}




	private void GoogleInite()
	{
		// These ad units are configured to always serve test ads.
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-3940256099942544/6300978111";
		#elif UNITY_IPHONE
		string adUnitId = appIdAll;
		#else
		string adUnitId = "unexpected_platform";
		#endif



		MobileAds.SetiOSAppPauseOnBackground(true);
		// Initialize the Google Mobile Ads SDK.
		MobileAds.Initialize(adUnitId);
	}

	private AdRequest CreateAdRequest()
	{
		return new AdRequest.Builder()
			.AddTestDevice(AdRequest.TestDeviceSimulator)
			.AddTestDevice(phoneId)
			.Build();


	}

        public void RequestBanner()
		{
		// These ad units are configured to always serve test ads.
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-3940256099942544/6300978111";
		#elif UNITY_IPHONE
		string adUnitId = appIdBanner;
		#else
		string adUnitId = "unexpected_platform";
		#endif
					
		if (this.bannerView != null)
		{
			this.bannerView.Destroy();
		}

		bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);


			// Create an empty ad request.
			//AdRequest request = new AdRequest.Builder().Build();

			// Load the banner with the request.
		this.bannerView.LoadAd(this.CreateAdRequest ());
		print ("横幅加载完毕");
		}

		//隐藏横幅
		public void BannerHide()
	{
		bannerView.Hide ();
		print ("我隐藏了");
	}
		//显示横幅
		public void BannerShow()
	{
		bannerView.Show ();
		print ("我展示了");
	}


	public  void  BannerDestory()
	{
		bannerView.Destroy ();
	}


	public void RequestInterstitial()
	{
		// These ad units are configured to always serve test ads.
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-3940256099942544/6300978111";
		#elif UNITY_IPHONE
		string adUnitId = appIdInterstial;
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Clean up interstitial ad before creating a new one.
		if (this.interstitial != null)
		{
			this.interstitial.Destroy();
			print ("我来啦");
		}

		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);
		// Create an empty ad request.
		//AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		this.interstitial.LoadAd(this.CreateAdRequest ());
		print ("加载插屏");

	}

		//显示插屏
	public void ShowInterstitial()
	{
		if (this.interstitial.IsLoaded())
		{
			this.interstitial.Show();
			print("插屏显示");
		}
		else
		{
			MonoBehaviour.print("Interstitial is not ready yet");

		}
	}

//		//谷歌广告
//		private GoogleAD google1;
//		private GoogleAD google2;
//		private List<GoogleAD> gad;
//		private int countInter;
//		//计数器
//		private int countBanner;
//
//		gad = new List<GoogleAD> ();
//
//		//查找广告脚本
//		google1 = GameObject.Find ("GoogleADOne").GetComponent<GoogleAD> ();
//		google2 = GameObject.Find ("GoogleADTwo").GetComponent<GoogleAD> ();
//
//		gad.Add (google1);
//		gad.Add (google2);
//		print ("我装了几个进去？" + gad.Count);
//		//初始化广告脚本
//		GADInitInterstitial ();
//		GADInitBanner ();
//		GADBannerShow ();	
//
//		//初始化插屏和横幅广告
//		void GADInitInterstitial ()
//		{
//		for (int i = 0; i < gad.Count; i++) {
//		gad [i].RequestInterstitial ();
//
//		}
//		}
//		//初始化横幅广告
//		void GADInitBanner ()
//		{
//		for (int i = 0; i < gad.Count; i++) {
//
//		gad [i].RequestBanner ();
//		gad [i].BannerHide ();
//		}
//		}
//
//
//		//轮流显示插屏
//		public void GADInterstitalShow ()
//		{
//		if (countInter >= gad.Count) {
//		GADInitInterstitial ();
//		countInter = 0;
//
//
//		} else {
//
//		gad [countInter].ShowInterstitial ();
//		print ("显示插屏" + countInter);
//		countInter++;
//		}
//		}
//
//		public void GADBannerShow ()
//		{
//		//轮流播放
//		StartCoroutine (TurnBannerShow ());
//		}
//
//		IEnumerator TurnBannerShow ()
//		{
//		for (int i = 0; i < gad.Count; i++) {
//
//		yield return new WaitForSeconds (1f);
//		gad [i].BannerShow ();
//		yield return new WaitForSeconds (10f);
//		gad [i].BannerHide ();
//		if (i == gad.Count - 1) {
//		i = -1;
//		}
//		print ("i=" + i);
//
//		}
//		}
//		}

}

