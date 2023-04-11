using UnityEngine;
using UnityEngine.EventSystems;
public class DragDrop : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler, IDragHandler 
{
    [SerializeField] private Canvas canvas;     
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    [Header("Variables")]
    public Vector2 CurrentSlot;
    [Space(5)]
    public int ID;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        CurrentSlot = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin");
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
        rectTransform.anchoredPosition += eventData.delta/ canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End");
        canvasGroup.blocksRaycasts = true;

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
    }

    public void ResetPosition()
    {
        transform.position = CurrentSlot;
    }
}
