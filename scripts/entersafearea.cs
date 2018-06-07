using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entersafearea : MonoBehaviour {

	public GameObject videoPlayer;
	public AudioClip otherClip;
	public int timeToStop;
	AudioSource audio;
	void Start(){
		videoPlayer.SetActive (false);
		audio = GetComponent<AudioSource> ();

	}


	 void OnTriggerEnter(Collider player){
		
		if(player.gameObject.tag=="Player"){
			Debug.Log ("Entered");
			videoPlayer.SetActive (true);
			audio.Play ();
		
		}

	}
}
