using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class EventControl : MonoBehaviour
{

	private NumberController nc;

	void Awake() {
	}
	// Use this for initialization
	void Start ()
	{
		
		GameObject numberController = GameObject.Find("NumberController");
		nc = (NumberController) numberController.GetComponent(typeof(NumberController));


		AddEventTriggerListener(
			GetComponent<EventTrigger>(),
			EventTriggerType.PointerClick,
			nc.ClickNumberEvent);
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public static void AddEventTriggerListener(EventTrigger trigger,
		EventTriggerType eventType,
		System.Action<BaseEventData> callback)
	{
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = eventType;
		entry.callback = new EventTrigger.TriggerEvent();
		entry.callback.AddListener(new UnityEngine.Events.UnityAction<BaseEventData>(callback));
		trigger.triggers.Add(entry);
	}
}

