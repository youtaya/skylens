using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NumberController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("number controller");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ClickNumberEvent(BaseEventData data) {
		PointerEventData temp = (PointerEventData)data;
		Debug.Log ("I am trigger: "+temp.pointerCurrentRaycast);
	}
}
