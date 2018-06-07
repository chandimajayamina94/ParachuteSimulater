using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControll : MonoBehaviour {
	public Transform CubeL;
	public Transform BrakeL;
	public Transform CubeR;
	public Transform BrakeR;
	private bool RightBrakeApplied=false;
	private bool LeftBrakeApplied=false;


	public bool movement;
	private Vector3 standRotation;
	private bool camControllisOver;
	private float standRotate=0f;
	//take the player rigidbody
	private Rigidbody _rigidbody;
	healthbar _health;
	// Use this for initialization
	void Start () {
		//apply player rigidbody 
		_rigidbody=GetComponent<Rigidbody>();
		_health = GetComponent<healthbar> ();
		movement = true;
		standRotation = new Vector3 (0,0,0);
		camControllisOver = false;
	   
	}
	
	// Update is called once per frame
	void Update () {
		if (CubeL.transform.position.y <= BrakeL.transform.position.y) {
			
			LeftBrakeApplied = true;
		} else {
			LeftBrakeApplied = false;
		}

		if (CubeR.transform.position.y <= BrakeR.transform.position.y) {
			
			RightBrakeApplied = true;	
		} else {
			RightBrakeApplied = false;
		}

		_rigidbody.constraints = RigidbodyConstraints.None;
		if (movement) {
			moveForward ();
		}
		if(this.transform.position.y<=-52f){
			movement = false;
		}
		//left rotation
		if (Input.GetKey(KeyCode.D)||RightBrakeApplied) {
			camControllisOver = false;
			leftRotation ();
		}
		//right rotation
		if (Input.GetKey (KeyCode.A)||LeftBrakeApplied) {
			camControllisOver = false;
			rightRotation ();
		}
		if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D)) {
			camControllisOver = true;
		}
		/*if (camControllisOver|| !RightBrakeApplied || !LeftBrakeApplied) {
			if (this.transform.rotation.z < 0) {
				transform.Rotate (Vector3.forward * Time.deltaTime *10f); 
				if (this.transform.rotation.z <1f ||this.transform.rotation.z >-1f) {
					_rigidbody.constraints = RigidbodyConstraints.FreezeRotationZ|RigidbodyConstraints.FreezeRotationY|RigidbodyConstraints.FreezeRotationX;
				}
			} else if (this.transform.rotation.z > 0) {
				transform.Rotate (-Vector3.forward * Time.deltaTime *10f); 
				if (this.transform.rotation.z <1f ||this.transform.rotation.z >-1f) {
					_rigidbody.constraints = RigidbodyConstraints.FreezeRotationZ|RigidbodyConstraints.FreezeRotationY|RigidbodyConstraints.FreezeRotationX;
				}
			}
		} */
	}
	//damage the health on collision to the terrain
	void OnCollisionEnter(Collision other){
		if(other.gameObject.name=="Terrain"){
			Debug.Log ("hit the terrain");
			_health.takeDamage (10f);
		}
	}

	void moveForward(){
		//move forward always 
		transform.Translate (new Vector3 (0, 0, 1) * Time.deltaTime);
	}
	void leftRotation(){
		Debug.Log ("left rotation");
		//leftRotate
		transform.Rotate (Vector3.up * Time.deltaTime*50f);
		//rotate according to the brake
		transform.Rotate (-Vector3.forward * Time.deltaTime*50f);
	}
	void rightRotation(){
		Debug.Log ("right rotation");
		//rightRoatate
		this.transform.Rotate (-Vector3.up * Time.deltaTime*50f);
		//rotate according to the brake
		this.transform.Rotate (Vector3.forward * Time.deltaTime*50f);
	}

}
