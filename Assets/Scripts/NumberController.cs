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

	static TouchNumber[] groupNums = new TouchNumber[9];
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
			if (groupNums [i] != null) {
				temp += " " + groupNums [i].number;
			}
		}
		roundText.text += temp;
	}

	bool hasTouched(int n, int pad) {
		for (int i = 0; i < 9; i++) {
			if (groupNums [i] != null) {
				if (groupNums [i].number == n && groupNums [i].belongPad == pad) {
					return true;
				}
			}
		}
		return false;
	}

	public void ClickNumberEvent(BaseEventData data) {
		PointerEventData temp = (PointerEventData)data;
		#if UNITY_EDITOR
		Debug.Log ("hit object: "+temp.pointerCurrentRaycast);
		Debug.Log ("parent of hit object: "+temp.pointerPressRaycast.gameObject.transform.parent.gameObject);
		#endif
		if (temp.pointerCurrentRaycast.gameObject.name == "One") {
			int touchPad = 1;
			if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 1") {
				touchPad = 1;
			} else if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 2") {
				touchPad = 2;
			} else if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 3") {
				touchPad = 3;
			}
			if(hasTouched(1, touchPad)) {
				Debug.Log ("has touched!");
				
			} else {
				TouchNumber tn = new TouchNumber (1, touchPad, groupIndex);
				groupNums [groupIndex] = tn;
				groupIndex++;
			}
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Two") {
			groupNums [groupIndex].number = 2;
			if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 1") {
				groupNums [groupIndex].belongPad = 1;
			} else if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 2") {
				groupNums [groupIndex].belongPad = 2;
			} else if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 3") {
				groupNums [groupIndex].belongPad = 3;
			}
			groupNums [groupIndex].index = groupIndex;
			groupIndex++;
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Three") {
			groupNums [groupIndex].number = 3;
			if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 1") {
				groupNums [groupIndex].belongPad = 1;
			} else if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 2") {
				groupNums [groupIndex].belongPad = 2;
			} else if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 3") {
				groupNums [groupIndex].belongPad = 3;
			} 
			groupNums [groupIndex].index = groupIndex;
			groupIndex++;
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Four") {
			groupNums [groupIndex].number = 4;
			if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 1") {
				groupNums [groupIndex].belongPad = 1;
			} else if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 2") {
				groupNums [groupIndex].belongPad = 2;
			} else if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 3") {
				groupNums [groupIndex].belongPad = 3;
			} 
			groupNums [groupIndex].index = groupIndex;
			groupIndex++;
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Five") {
			groupNums [groupIndex].number = 5;
			if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 1") {
				groupNums [groupIndex].belongPad = 1;
			} else if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 2") {
				groupNums [groupIndex].belongPad = 2;
			} else if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 3") {
				groupNums [groupIndex].belongPad = 3;
			} 
			groupNums [groupIndex].index = groupIndex;
			groupIndex++;
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Six") {
			groupNums [groupIndex].number = 6;
			if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 1") {
				groupNums [groupIndex].belongPad = 1;
			} else if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 2") {
				groupNums [groupIndex].belongPad = 2;
			} else if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 3") {
				groupNums [groupIndex].belongPad = 3;
			} 
			groupNums [groupIndex].index = groupIndex;
			groupIndex++;
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Seven") {
			groupNums [groupIndex].number = 7;
			if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 1") {
				groupNums [groupIndex].belongPad = 1;
			} else if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 2") {
				groupNums [groupIndex].belongPad = 2;
			} else if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 3") {
				groupNums [groupIndex].belongPad = 3;
			} 
			groupNums [groupIndex].index = groupIndex;
			groupIndex++;
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Eight") {
			groupNums [groupIndex].number = 8;
			if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 1") {
				groupNums [groupIndex].belongPad = 1;
			} else if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 2") {
				groupNums [groupIndex].belongPad = 2;
			} else if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 3") {
				groupNums [groupIndex].belongPad = 3;
			} 
			groupNums [groupIndex].index = groupIndex;
			groupIndex++;
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Nine") {
			groupNums [groupIndex].number = 9;
			if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 1") {
				groupNums [groupIndex].belongPad = 1;
			} else if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 2") {
				groupNums [groupIndex].belongPad = 2;
			} else if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 3") {
				groupNums [groupIndex].belongPad = 3;
			} 
			groupNums [groupIndex].index = groupIndex;
			groupIndex++;
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Zero") {
			groupNums [groupIndex].number = 0;
			if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 1") {
				groupNums [groupIndex].belongPad = 1;
			} else if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 2") {
				groupNums [groupIndex].belongPad = 2;
			} else if (temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name == "Touch Pad 3") {
				groupNums [groupIndex].belongPad = 3;
			} 
			groupNums [groupIndex].index = groupIndex;
			groupIndex++;
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Back") {
			Camera.main.transform.Rotate (new Vector3 (0, -90, 0));
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Forward") {
			Camera.main.transform.Rotate (new Vector3 (0, 90, 0));
		}
	}
}
