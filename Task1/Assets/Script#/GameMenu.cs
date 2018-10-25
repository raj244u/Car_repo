using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {
	
//	public AudioSource audioSource;
	public GameObject  soundPanel,menuPanel;
	public Toggle audioCheck;
	public float mVolume;
	public Slider mSlider;

	// Use this for initialization
	void Start () {
		
//		audioCheck = GameObject.FindWithTag ("toggle").GetComponent<Toggle>();
//		audioSource = GetComponent<AudioSource> ();
		menuPanel.SetActive (true);
		soundPanel.SetActive (false);


	}
	
	// Update is called once per frame
	void Update () {
		if(mSlider!=null) {
		mVolume = mSlider.value;
		PlayerPrefs.SetFloat ("volumeValue",mVolume);
		Debug.Log (mVolume);


		}
	}


	public void Play() {
		Debug.Log ("play run....");
		SceneManager.LoadScene (1);


	}


	public void Control() {
		
		menuPanel.SetActive (false);
		soundPanel.SetActive (true);
		PlayerPrefs.SetInt ("audioKey",0);

		Debug.Log (audioCheck.isOn);
		if (audioCheck.isOn) {
			Debug.Log ("on....");
			PlayerPrefs.SetInt ("audioKey", 1);


		} else {
			Debug.Log ("off.....");
			PlayerPrefs.SetInt ("audioKey",0);
		}




	}
	public void  backArrow() {
		Debug.Log ("back arrow..");
		soundPanel.SetActive (false);
		menuPanel.SetActive (true);

	}

	public void toggleAudio() {




	}
	public void Quit() {

		Application.Quit();

	}



}
