using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camcontroll : MonoBehaviour {

	//real mouse point
	Vector2 mouseLook;
	//change of mouselook holder
	Vector2 smoothV;

	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;
	private GameObject character;
	// Use this for initialization
	void Start () {
		//initializing parent
		character = this.transform.parent.gameObject;
	}	
	
	// Update is called once per frame
	void Update () {
	     var md = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));
		 
		md=Vector2.Scale(md, new Vector2(sensitivity*smoothing, sensitivity*smoothing));
		smoothV.x=Mathf.Lerp(smoothV.x, md.x, 1f/smoothing);
		smoothV.y=Mathf.Lerp(smoothV.y, md.y, 1f/smoothing);
		mouseLook+=smoothV;
		//user is only able to look at the neck position bella harena tharamata witarai balanna puluwan
		if(mouseLook.y<29f && mouseLook.y>-45)
		transform.localRotation=Quaternion.AngleAxis(-mouseLook.y, Vector3.right);	
		character.transform.localRotation=Quaternion.AngleAxis(mouseLook.x, character.transform.up);


	}
}
