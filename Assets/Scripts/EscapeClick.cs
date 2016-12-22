using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EscapeClick : MonoBehaviour, IPointerClickHandler {

	public void OnPointerClick(PointerEventData data)
	{
		#if UNITY_EDITOR
		Debug.Log ("I want quit");
		#endif
		// reload the scene
		//SceneManager.LoadScene(SceneManager.GetSceneAt(0).path);
		Application.Quit();
	}

	private void Update()
	{
	}
}