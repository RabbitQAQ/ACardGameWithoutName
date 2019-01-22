using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

	private bool isCast = false;
	
	public void OnBeginDrag(PointerEventData eventData)
	{
		//Debug.Log("On Begin Drag");
		this.transform.SetParent(FindObjectOfType<Canvas>().transform);
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	
	public void OnDrag(PointerEventData eventData)
	{
		//Debug.Log("On Drag");
		this.transform.position = eventData.position;
		List<RaycastResult> raycastResults = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventData, raycastResults);
		if (raycastResults.Count == 0)
			isCast = true;
		else
			isCast = false;

	}
	
	public void OnEndDrag(PointerEventData eventData)
	{
		//Debug.Log("On end Drag");
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		if (isCast)
		{
			PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();
			playerController.GetComponent<CardCaster>().cast(Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y)), "FireBall");
			Destroy(this.transform.gameObject);
		}
	}
}
