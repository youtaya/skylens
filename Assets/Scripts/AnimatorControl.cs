﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimatorControl : MonoBehaviour, IPointerClickHandler {
	Animator anima;
	AudioSource source;
	// Use this for initialization
	void Start () {
		anima = GetComponent<Animator> ();
		source = GetComponent<AudioSource> ();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerClick(PointerEventData data)
	{
		#if UNITY_EDITOR
		Debug.Log ("squiz trigger");
		#endif
		anima.SetTrigger ("squizTrigger");
		source.Play ();
	}
		
}
