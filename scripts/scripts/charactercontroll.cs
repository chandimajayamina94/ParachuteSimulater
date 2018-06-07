using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontroll : MonoBehaviour {
	//how fast your chareacter want to respond
	public float speed=10.0f;
	// Use this for initialization
	void Start () {
		//disapear the curser in game window
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		//z axis changement
		float translation = Input.GetAxis ("Vertical") * speed;
		//x axis changment
		float straffe = Input.GetAxis ("Horizontal") * speed;
		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;
		//position change
		transform.Translate (straffe, 0, translation);
		if(Input.GetKeyDown("escape")){
			//if we enter the escape button it shows the cursor again
			Cursor.lockState = CursorLockMode.None;
		}
		//there is no parachute when pull the parachute open arm parachute open and slow down the drag speed
		if(Input.GetKey(KeyCode.Space)){
               			
		}
		if(Input.GetKey(KeyCode.W)){
			Debug.Log ("w pressed");
		}
		if(Input.GetKey(KeyCode.S)){
			Debug.Log ("s pressed");
		}
		if(Input.GetKey(KeyCode.A)){
			Debug.Log ("a pressed");
		}
		if(Input.GetKey(KeyCode.D)){
			Debug.Log ("d pressed");
		}

	}
}
