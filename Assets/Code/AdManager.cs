using admob;
using UnityEngine;

public class AdManager : MonoBehaviour {

	public static AdManager Instance { set; get; }

	private static readonly string TOP_BANNER_ID = "";
	private static readonly string VIDEO_ID = "ca-app-pub-7267736941458952/1180908028";

	void Start () {
		Instance = this;
		DontDestroyOnLoad(gameObject);

		#if UNITY_EDITOR
		Debug.Log("Unable to play ads from editor");
		#elif UNITY_ANDROID        
		Admob.Instance().initAdmob(TOP_BANNER_ID, VIDEO_ID);
		Admob.Instance().loadInterstitial();
		#endif
	}

	public void ShowTopBanner()
	{        
		#if UNITY_EDITOR
		Debug.Log("Unable to play ads from editor");
		#elif UNITY_ANDROID
		Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.TOP_CENTER, 5);        
		#endif
	}

	public void ShowVideo()
	{
		#if UNITY_EDITOR
		Debug.Log("Unable to play ads from editor22");
		#elif UNITY_ANDROID
		if (Admob.Instance().isInterstitialReady())
		{
		Admob.Instance().showInterstitial();
		}
		#endif
	}
}
