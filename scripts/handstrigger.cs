using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handstrigger : MonoBehaviour {
	private bool handcontrollalow;
	public Transform hands;

	void Start(){
		handcontrollalow = false;
	}

	void Update(){
		if (handcontrollalow) {
			transform.position = new Vector3 (transform.position.x, hands.transform.position.y, transform.position.z);
		}	
	}

	void OnTriggerStay(Collider player){
		handcontrollalow = true;
	}

}
