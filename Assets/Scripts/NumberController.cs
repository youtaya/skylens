using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NumberController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		#if UNITY_EDITOR
		Debug.Log ("number controller");
		#endif
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ClickNumberEvent(BaseEventData data) {
		PointerEventData temp = (PointerEventData)data;
		#if UNITY_EDITOR
		Debug.Log ("I am trigger: "+temp.pointerCurrentRaycast);
		#endif
	}
}
