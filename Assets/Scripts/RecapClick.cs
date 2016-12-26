using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RecapClick : MonoBehaviour {

    private Button btn;
	private NumberController nc;

	private void Start()
	{
		#if UNITY_EDITOR
		Debug.Log("clean this touch pad");
		#endif


		GameObject numberController = GameObject.Find("NumberController");
		nc = (NumberController) numberController.GetComponent(typeof(NumberController));

        btn = GetComponent<Button>();
		btn.onClick.AddListener(() => { nc.RecapNumber(); });
    }
		
}