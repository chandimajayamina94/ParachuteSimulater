using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercamrotate : MonoBehaviour {
	//public Transform CubeR;
	//public Transform BrakePositionR;
	//public Transform CubeL;
	//public Transform BrakePositionL;
	public Transform target;
	private bool forwardRotateEnable=false;
	Quaternion OriginalRotate;
	public float speed=10f;
	private Player playerrotate;

	// Use this for initialization
	void Start () {
		//OriginalRotate = transform.rotation;
		 playerrotate=transform.parent.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerrotate.RightBrakeApplied) {
			this.transform.Rotate (-Vector3.forward * speed * Time.deltaTime);
			forwardRotateEnable = true;
		} else if (playerrotate.LeftBrakeApplied) {
			this.transform.Rotate (Vector3.forward * speed * Time.deltaTime);
			forwardRotateEnable = true;
		} else if (!playerrotate.RightBrakeApplied) {
			Debug.Log ("came");
			forwardRotateEnable = false;
		} else if (!playerrotate.LeftBrakeApplied) {
			Debug.Log ("Came");
			forwardRotateEnable = false;
		} 
		if (!forwardRotateEnable) {	
			transform.rotation = Quaternion.RotateTowards (transform.rotation, target.rotation, speed * Time.deltaTime);
		}
		/*
		if(Input.GetKey(KeyCode.A)){
			this.transform.Rotate (Vector3.forward*speed*Time.deltaTime);
			forwardRotateEnable = true;
		}
		if(Input.GetKeyUp(KeyCode.A)){
			forwardRotateEnable = false;
		}
		if(Input.GetKey(KeyCode.D)){
			this.transform.Rotate (-Vector3.forward*speed*Time.deltaTime);
			forwardRotateEnable = true;
		}
		if(Input.GetKeyUp(KeyCode.D)){
			forwardRotateEnable = false;
		}
	/*
		if (playerrotate.LeftBrakeApplied) {
			this.transform.Rotate (Vector3.forward*speed*Time.deltaTime);
			forwardRotateEnable = true;


		}
        
		if (!playerrotate.LeftBrakeApplied) {
			forwardRotateEnable = false;
		}

   
		if (playerrotate.RightBrakeApplied) {
			
			forwardRotateEnable = true;	
			this.transform.Rotate (-Vector3.forward*speed*Time.deltaTime);

		}

		if (!playerrotate.RightBrakeApplied) {
			forwardRotateEnable = false;
		}

           
		if(forwardRotateEnable==false){
			transform.rotation = Quaternion.RotateTowards (transform.rotation, target.rotation, speed * Time.deltaTime);
		}
		*/
        
	}
}
