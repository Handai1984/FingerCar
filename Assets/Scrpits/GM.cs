using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{

	public static  GM instante;
	public bool isGameOver;
	public SpriteRenderer mapColor;
	//获取地图的render
	private Color mcolor;
	public Transform car;
	public GameObject start;
	public GameObject reStart;
	private  Text scoreText;
	public Text highScoreText;
	public GameObject win;
	private int score = 0;
	private int hightScore;
	//谷歌广告
	private GoogleAD google1;
	private GoogleAD google2;
	private List<GoogleAD> gad;
	private int countInter;
	//计数器
	private int countBanner;

	private void Awake ()
	{
		instante = this;
		isGameOver = true;
	}

	private void Start ()
	{
		car.gameObject.SetActive (true);
		car.position = this.transform.position;
		scoreText = GameObject.Find ("Score").GetComponent<Text> ();
		hightScore = PlayerPrefs.GetInt ("High", 0);

		gad = new List<GoogleAD> ();
		 
		//查找广告脚本
		google1 = GameObject.Find ("GoogleADOne").GetComponent<GoogleAD> ();
		google2 = GameObject.Find ("GoogleADTwo").GetComponent<GoogleAD> ();

		gad.Add (google1);
		gad.Add (google2);
		print ("我装了几个进去？" + gad.Count);
		//初始化广告脚本
		GADInitInterstitial ();
		GADInitBanner ();
		GADBannerShow ();	
		StartColor ();
		ShowScore ();
	}
	//初始化插屏和横幅广告
	void GADInitInterstitial ()
	{
		for (int i = 0; i < gad.Count; i++) {
			gad [i].RequestInterstitial ();

		}
	}
	//初始化横幅广告
	void GADInitBanner ()
	{
		for (int i = 0; i < gad.Count; i++) {
			
			gad [i].RequestBanner ();
			gad [i].BannerHide ();
		}
	}

	/// <summary>
	/// 改变游戏地图和背景颜色
	/// </summary>
	private void StartColor ()
	{
		mcolor = new Color (Random.Range (0, 256) / 255f, Random.Range (0, 256) / 255f, Random.Range (0, 256) / 255f);
		mapColor.color = mcolor;

		mcolor = new Color (Random.Range (0, 256) / 255f, Random.Range (0, 256) / 255f, Random.Range (0, 256) / 255f);
		Camera.main.backgroundColor = mcolor;

        
	}


	public void GameStart ()
	{
		//游戏开始
		car.position = this.transform.position;
		isGameOver = false;
		win.SetActive (false);
		start.SetActive (false);

	}

	public void ReStart ()
	{
		car.gameObject.SetActive (true);
		StartColor ();//游戏开始地图和背景颜色
		car.position = this.transform.position;
		car.rotation = this.transform.rotation;
		isGameOver = false;
		score = 0;
		highScoreText.gameObject.SetActive (false);
		reStart.SetActive (false);
	}

	public void AddScore ()
	{
		score += 1;
	}

	public void ShowScore ()
	{
		int temp = score / 5;
		scoreText.text = temp + "";
		if (temp > hightScore) {
			hightScore = temp;
			PlayerPrefs.SetInt ("High", hightScore);
		}
	}

	public void ShowHihgScore ()
	{
		hightScore = PlayerPrefs.GetInt ("High", hightScore);
		highScoreText.text = "最高分：" + hightScore + "";
	}

   
	//轮流显示插屏
	public void GADInterstitalShow ()
	{
		if (countInter >= gad.Count) {
			GADInitInterstitial ();
			countInter = 0;


		} else {

			gad [countInter].ShowInterstitial ();
			print ("显示插屏" + countInter);
			countInter++;
		}
	}

	public void GADBannerShow ()
	{
		//轮流播放
		StartCoroutine (TurnBannerShow ());
	}

	IEnumerator TurnBannerShow ()
	{
		for (int i = 0; i < gad.Count; i++) {
			
			yield return new WaitForSeconds (1f);
			gad [i].BannerShow ();
			yield return new WaitForSeconds (10f);
			gad [i].BannerHide ();
			if (i == gad.Count - 1) {
				i = -1;
			}
			print ("i=" + i);

		}
	}
}
