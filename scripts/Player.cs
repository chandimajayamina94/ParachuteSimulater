using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	//public bool upRotateEnable=false;
	public bool RightBrakeApplied=false;
	public bool LeftBrakeApplied=false;
	//Quaternion OriginalRotate;
	public Transform CubeR;
	public Transform BrakePositionR;
	public Transform CubeL;
	public Transform BrakePositionL;
	public float Rotatespeed=10f;
	public float MoveForwardSpeed=10f;
	healthbar _health;
	// Use this for initialization
	void Start () {
		_health = GetComponent<healthbar> ();
		//OriginalRotate = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * Time.deltaTime * MoveForwardSpeed;
		//Leap hand Controlls
		if (CubeR.transform.position.y <= BrakePositionR.transform.position.y||Input.GetKey (KeyCode.D)) {
			//this.transform.Rotate (Vector3.up * Rotatespeed * Time.deltaTime);
			RightBrakeApplied = true;
		} else {
			RightBrakeApplied = false;
		}

		if (CubeL.transform.position.y <= BrakePositionL.transform.position.y||Input.GetKey (KeyCode.A)) {
			LeftBrakeApplied = true;
		} else {
			LeftBrakeApplied = false;
		}
		/*
		if (Input.GetKey (KeyCode.D)) {
			RightBrakeApplied = true;
		} else {
			RightBrakeApplied = false;
		}
		//Keyboard controlls
		if (Input.GetKey (KeyCode.A)) {
			LeftBrakeApplied = true;
		} else {
			LeftBrakeApplied = false;
		}

         */

		if (LeftBrakeApplied) {
			//upRotateEnable = true;
			this.transform.Rotate (-Vector3.up*Rotatespeed*Time.deltaTime);
		}
	    
		if (RightBrakeApplied) {		
			//upRotateEnable = true;	
			this.transform.Rotate (Vector3.up * Rotatespeed * Time.deltaTime);
		} 
		
		/*if (Input.GetKeyUp (KeyCode.D)) {
			upRotateEnable = false;
		}
		if(upRotateEnable==false){
		    if(transform.rotation.x!=0||transform.rotation.y!=0||transform.rotation.z!=0){
				transform.rotation = Quaternion.Lerp (transform.rotation, OriginalRotate, Time.deltaTime * speed);
		     }
		}

        */
       



    }

	void OnCollisionEnter(Collision other){
		if(other.gameObject.name=="Terrain"){
			Debug.Log ("hit the terrain");
			_health.takeDamage (10f);
		}
	}
}
