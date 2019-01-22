using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler {
	
	public void OnDrop(PointerEventData eventData)
	{
		// Reset parent to make card drop to hand
		eventData.pointerDrag.transform.SetParent(this.transform);
	}
}
