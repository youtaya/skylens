using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour {

	private bool flag = false;
	private Vector3 origin;
	private Vector3 endPoint;
	public float duration = 50.0f;
	private float zAxis;

	// Use this for initialization
	void Start () {
		zAxis = gameObject.transform.position.z;
		origin = gameObject.transform.position;
		//Debug.Log ("origin: " + origin);
	}
	
	// Update is called once per frame
	void Update () {
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
				if (hit.collider.gameObject == gameObject) { 
					flag = true;
					endPoint = origin;
					endPoint.z += 2;
					endPoint.y += 1;
					Debug.Log (endPoint);
				}
			}
		}
		if (flag && !Mathf.Approximately (gameObject.transform.position.magnitude, endPoint.magnitude)) {
			gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, endPoint, 
				1 / (duration * (Vector3.Distance (gameObject.transform.position, endPoint))));
			if (Mathf.Approximately (gameObject.transform.position.magnitude, endPoint.magnitude)) {
				endPoint = origin;
			}
		} 
		/*
		if (flag && !Mathf.Approximately (gameObject.transform.position.magnitude, endPoint.magnitude)) {
			gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, endPoint, 
				1 / (duration * (Vector3.Distance (gameObject.transform.position, endPoint))));
		} else if (flag && Mathf.Approximately (gameObject.transform.position.magnitude, endPoint.magnitude)) {
			flag = false;
			endPoint = origin;
			Debug.Log ("after origin: " + origin);
			gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, origin, 
				1 / (duration * (Vector3.Distance (gameObject.transform.position, origin))));
			Debug.Log ("I am here");
		}
		*/
	}
}
