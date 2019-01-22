using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private bool _isCast = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Remove current card from hand
        this.transform.SetParent(FindObjectOfType<Canvas>().transform);
        // Disable blocksRaycasts. Or cards cannot do raycast related operations
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
        // Card dealer shouldn't count when dragging a card
        CardDealer.shouldCount = false;
        // Judge whether the card has been moved out of hand area
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        // No UI element under current position, do casting
        if (raycastResults.Count == 0)
            _isCast = true;
        else
            _isCast = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Card dealer can count now
        CardDealer.shouldCount = true;
        // Enable blocksRaycast. Or cards cannot be interacted.
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        // Card cast
        if (_isCast)
        {
            // Call player's cast(). All card casting logic should process in cast()
            // Card is UI element, it's position is originally represented in screen coordinate and need to convert to world coordinate
            PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();
            playerController.GetComponent<CardCaster>()
                .cast(Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y)),
                    GetComponent<CardProperty>().cardName);

            // Card number in hand should decrease
            CardDealer.currCardNum--;
            
            Destroy(this.transform.gameObject);
        }
    }
}