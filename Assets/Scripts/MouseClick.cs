using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MouseClick : MonoBehaviour , IPointerClickHandler {

	private bool flag = false;
	private Vector3 origin;
	private Vector3 endPoint;
	public float duration = 50.0f;

	// Use this for initialization
	void Start () {

    }

    void resetPosition()
    {
        origin = gameObject.transform.localPosition;
        endPoint = origin;
        endPoint.z += 3;
    }

	public void OnPointerClick(PointerEventData data)
	{
        resetPosition();
        flag = true;
	}

    // Update is called once per frame
    void Update()
    {

        if (flag && !Mathf.Approximately(gameObject.transform.localPosition.magnitude, endPoint.magnitude))
        {
            gameObject.transform.localPosition = Vector3.Lerp(gameObject.transform.localPosition, endPoint,
                100 / (duration * (Vector3.Distance(gameObject.transform.position, endPoint))));

            if (Mathf.Approximately(gameObject.transform.localPosition.magnitude, endPoint.magnitude))
            {
                endPoint = origin;
            }
        }
    }
}