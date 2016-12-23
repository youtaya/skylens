using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Runtime.InteropServices;
using System.Text;

public class NumberController : MonoBehaviour {

	public Text roundText;
	public Text notificationText;

	static int[] groupNums = new int[9];
	static int groupIndex = 0;
	static bool isCameraRotate = false;

	// Use this for initialization
	void Start () {
		#if UNITY_EDITOR
		Debug.Log ("number controller");
		#endif
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate() {
		ShowRoundText ();
		if (groupIndex > 0 && (groupIndex % 3 == 0)) {
			if (!isCameraRotate) {
				Camera.main.transform.Rotate (new Vector3 (0, 90, 0));
			}
			isCameraRotate = true;
		} else {
			isCameraRotate = false;
		}
	}

	void ShowRoundText () {
		roundText.text = "Round ";
		string temp = "";
		for (int i = 0; i < 9; i++) {
			temp += " "+groupNums[i];
		}
		roundText.text += temp;
	}

	public void ClickNumberEvent(BaseEventData data) {
		PointerEventData temp = (PointerEventData)data;
		#if UNITY_EDITOR
		Debug.Log ("I am trigger: "+temp.pointerCurrentRaycast);
		#endif
		if (temp.pointerCurrentRaycast.gameObject.name == "One") {
			groupNums [groupIndex] = 1;
			groupIndex++;
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Two") {
			groupNums [groupIndex] = 2;
			groupIndex++;
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Three") {
			groupNums [groupIndex] = 3;
			groupIndex++;
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Four") {
			groupNums [groupIndex] = 4;
			groupIndex++;
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Five") {
			groupNums [groupIndex] = 5;
			groupIndex++;
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Six") {
			groupNums [groupIndex] = 6;
			groupIndex++;
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Seven") {
			groupNums [groupIndex] = 7;
			groupIndex++;
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Eight") {
			groupNums [groupIndex] = 8;
			groupIndex++;
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Nine") {
			groupNums [groupIndex] = 9;
			groupIndex++;
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Zero") {
			groupNums [groupIndex] = 0;
			groupIndex++;
		}
	}
}
