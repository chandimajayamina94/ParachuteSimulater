using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;
public class graspBeginL : MonoBehaviour {
	Rigidbody _rigidbody;
	public bool gripIsReleased;
	public Transform PositionL;
	public Transform BrakePositionL;
	public Transform targetHandL;
	public Transform Onreleaseparent;
	public float speed=10f;
	private InteractionBehaviour _intObj;
	// Use this for initialization
	void Start () {
		gripIsReleased = true;
		_intObj = GetComponent<InteractionBehaviour> ();
		_intObj.OnGraspBegin += OnGraspBegin;
		_intObj.OnGraspEnd += OnGraspEnd;
		_rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		// Debug.Log (this.transform.position.y +"Left");
		if(gripIsReleased){
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, PositionL.position, step);
		} 
	
	}

	private void OnGraspBegin(){
		Debug.Log ("Grasp Begin");
		gripIsReleased = false;
	//	this.transform.parent = targetHandL.transform;
	}

	private void OnGraspEnd(){
		Debug.Log ("Grasp End");
		gripIsReleased = true;
	//	this.transform.parent = Onreleaseparent.transform;
	}
}
