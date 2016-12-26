using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnkownObject : MonoBehaviour {

	public GameObject spawnN1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnNew () {
		Instantiate (spawnN1, gameObject.transform.position, gameObject.transform.rotation);
	}
}
