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

	SortedDictionary<string, int> numDict = new SortedDictionary<string, int> ();
	SortedDictionary<string, int> padDict = new SortedDictionary<string, int> ();

	List<TouchNumber> listNum = new List<TouchNumber> ();
	static int groupIndex = 0;
	static bool isCameraRotate = false;
	static bool isRevertCond = false;

	#if (UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN)
	[DllImport ("flick")]
	private static extern void magicAllIn(byte[] sb, int v1, int v2, int v3);
	#elif (UNITY_EDITOR_OSX || UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX)
	[DllImport ("flick")]
	private static extern IntPtr magicAllIn(int v1, int v2, int v3);
	#endif

	// Use this for initialization
	void Start () {
		#if UNITY_EDITOR
		Debug.Log ("number controller");
		#endif
		numDict.Add ("One", 1);
		numDict.Add ("Two", 2);
		numDict.Add ("Three", 3);
		numDict.Add ("Four", 4);
		numDict.Add ("Five", 5);
		numDict.Add ("Six", 6);
		numDict.Add ("Seven", 7);
		numDict.Add ("Eight", 8);
		numDict.Add ("Nine", 9);
		numDict.Add ("Zero", 0);

		padDict.Add ("Touch Pad 1", 1);
		padDict.Add ("Touch Pad 2", 2);
		padDict.Add ("Touch Pad 3", 3);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate() {
		ShowRoundText ();
		if (groupIndex > 0 && (groupIndex % 3 == 0)) {
			if (!isCameraRotate && !isRevertCond) {
				Camera.main.transform.Rotate (new Vector3 (0, 90, 0));
			}
			isCameraRotate = true;
		} else {
			isCameraRotate = false;
		}

		if (groupIndex == 9) {
			
			#if (UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN)
			byte[] sb = new byte[256];
			magicAllIn (sb, 200, 234, 345);
			string screenStr="";
			screenStr=System.Text.Encoding.Default.GetString(sb);
			Debug.Log ("sb result:  " + screenStr);
			notificationText.text = screenStr;
			#elif (UNITY_EDITOR_OSX || UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX)
			IntPtr pStr = magicAllIn (200, 234, 345);
			string res = Marshal.PtrToStringAnsi (pStr);
			//Marshal.FreeHGlobal (pStr);
			notificationText.text = res;
			#endif

		}
	}

	void ShowRoundText () {
		roundText.text = "Round ";
		string temp = "";
		for (int i = 0; i < listNum.Count; i++) {
			if (listNum[i] != null) {
				temp += " " + listNum [i].number;
			}
		}
		roundText.text += temp;
	}

	TouchNumber getTouchedNum(int n, int pad) {
		for (int i = 0; i < listNum.Count; i++) {
			if (listNum [i] != null) {
				if (listNum [i].number == n && listNum [i].belongPad == pad) {
					return listNum [i];
				}
			}
		}
		return null;
	}

	void recordNumber(int num, int pad) {

		TouchNumber touched = getTouchedNum (num, pad);
		if(touched != null) {
			Debug.Log ("has touched!");
			listNum.Remove (touched);
			groupIndex -= 1;
			isRevertCond = true;

		} else {
			TouchNumber tn = new TouchNumber (num, pad);
			listNum.Add (tn);
			groupIndex++;
			isRevertCond = false;
		}
	}

	public void ClickNumberEvent(BaseEventData data) {
		PointerEventData temp = (PointerEventData)data;
		#if UNITY_EDITOR
		Debug.Log ("hit object: "+temp.pointerCurrentRaycast);
		Debug.Log ("parent of hit object: "+temp.pointerPressRaycast.gameObject.transform.parent.gameObject);
		#endif

		if (temp.pointerCurrentRaycast.gameObject.name == "Back") {
			Camera.main.transform.Rotate (new Vector3 (0, -90, 0));
		} else if (temp.pointerCurrentRaycast.gameObject.name == "Forward") {
			Camera.main.transform.Rotate (new Vector3 (0, 90, 0));
		} else {

			recordNumber (numDict [temp.pointerCurrentRaycast.gameObject.name], 
				padDict [temp.pointerPressRaycast.gameObject.transform.parent.gameObject.name]);
		}


	}
}
