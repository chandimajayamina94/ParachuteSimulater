using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour {
	//taking the halth bar image on the canvas
	public Image _currenthealthbar;
	//we have to change the text also is the health is 100% like wise
	public Text _ratiotext;

	private float hitpoints=100f;
	private float maxhitpoints = 100f;

	// Use this for initialization
	private void Start () {
		updateHealthBar ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void updateHealthBar(){
		//what is the percentage of the health
		float ratio = hitpoints / maxhitpoints;
		//update the health bar current health bar recttransform(graphics) localscale(according to the parent)
		_currenthealthbar.rectTransform.localScale = new Vector3 (ratio,1,1);
		//updating the text
		_ratiotext.text=(ratio*100).ToString() +'%';
	}

	public void takeDamage(float damage){
		hitpoints -= damage;
		if (hitpoints < 0) {
			Debug.Log ("death");
			hitpoints = 0;
		}
		updateHealthBar ();
	}

	private void healDamage(float heal){
		hitpoints += heal;
		if (hitpoints >maxhitpoints) {
			Debug.Log ("over health");
			hitpoints = maxhitpoints;
		}
		updateHealthBar ();
	}
}
