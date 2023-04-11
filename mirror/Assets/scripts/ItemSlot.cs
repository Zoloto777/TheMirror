using UnityEngine.EventSystems;
using UnityEngine;
using Unity.VisualScripting;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public int ID;
    public int HandID;

    public void OnDrop(PointerEventData eventData)
    {      
            if (eventData.pointerDrag.GetComponent<DragDrop>().ID == ID)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.GetComponent<DragDrop>().CurrentSlot = transform.position;
            }
            else if (eventData.pointerDrag.GetComponent<ItemSlot>().ID == ID) 
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;            
                GetComponent<DragDrop>().CurrentSlot = eventData.pointerDrag.GetComponent<DragDrop>().CurrentSlot;
                eventData.pointerDrag.GetComponent<DragDrop>().CurrentSlot = transform.position;
                transform.position = GetComponent<DragDrop>().CurrentSlot;
        }
            else
            {
                eventData.pointerDrag.GetComponent<DragDrop>().ResetPosition();
            }
    }
}
