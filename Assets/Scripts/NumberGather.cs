using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Runtime.InteropServices;
using System.Text;

public class NumberGather : MonoBehaviour {
	public GameObject One;
	public GameObject Two;
	public GameObject Three;
	public GameObject Four;
	public GameObject Five;
	public GameObject Six;
	public GameObject Seven;
	public GameObject Eight;
	public GameObject Nine;
	public GameObject Zero;

	public GameObject Del;
	public GameObject Confirm;

	public Text roundText;
	public Text notificationText;

	static int[] groupNums = new int[9];
	static int groupIndex = 0;


	#if (UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN)
	[DllImport ("flick")]
	private static extern void magicAllIn(byte[] sb, int v1, int v2, int v3);
	#elif (UNITY_EDITOR_OSX || UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX)
	[DllImport ("flick")]
	private static extern IntPtr magicAllIn(int v1, int v2, int v3);
	#endif



	// Use this for initialization
	void Start () {

	}

	void ShowRoundText () {
		roundText.text = "Round ";
		string temp = "";
		for (int i = 0; i < 9; i++) {
			temp += " "+groupNums[i];
		}
		roundText.text += temp;
	}

	// Update is called once per frame
	void Update () {
		ShowRoundText ();
		if ((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
			|| (Input.GetMouseButtonDown (0))) {

			RaycastHit hit;
			Ray ray;

			#if (UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX)
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
			ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			#endif

			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.gameObject == One) {
					Debug.Log ("one hit");
					groupNums [groupIndex] = 1;
					groupIndex++;

				} else if (hit.collider.gameObject == Two) {
					Debug.Log ("two hit");
					groupNums [groupIndex] = 2;
					groupIndex++;
				} else if (hit.collider.gameObject == Three) {
					Debug.Log ("three hit");
					groupNums [groupIndex] = 3;
					groupIndex++;
				} else if (hit.collider.gameObject == Four) {
					Debug.Log ("four hit");
					groupNums [groupIndex] = 4;
					groupIndex++;
				} else if (hit.collider.gameObject == Five) {
					Debug.Log ("five hit");
					groupNums [groupIndex] = 5;
					groupIndex++;
				} else if (hit.collider.gameObject == Six) {
					Debug.Log ("six hit");
					groupNums [groupIndex] = 6;
					groupIndex++;
				} else if (hit.collider.gameObject == Seven) {
					Debug.Log ("seven hit");
					groupNums [groupIndex] = 7;
					groupIndex++;
				} else if (hit.collider.gameObject == Eight) {
					Debug.Log ("eight hit");
					groupNums [groupIndex] = 8;
					groupIndex++;
				} else if (hit.collider.gameObject == Nine) {
					Debug.Log ("nine hit");
					groupNums [groupIndex] = 9;
					groupIndex++;
				} else if (hit.collider.gameObject == Zero) {
					Debug.Log ("zero hit");
					groupNums [groupIndex] = 0;
					groupIndex++;
				} else if (hit.collider.gameObject == Del) {
					Debug.Log ("del hit");
					if (groupIndex > 0) {
						groupIndex -= 1;
						groupNums [groupIndex] = 0;

					}
				} else if (hit.collider.gameObject == Confirm) {
					
					for (int i = 0; i < 9; i++) {
						//Debug.Log ("group numbers " + i + " : " + groupNums [i]);
					}
					// for test
					//string res = Marshal.PtrToStringAnsi(magicAllIn(200,234,345));

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


					// load next scene
					//SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
					Camera.main.transform.Rotate (new Vector3 (0, 90, 0)); 
				}
				
			}
		}
	
	}
}
