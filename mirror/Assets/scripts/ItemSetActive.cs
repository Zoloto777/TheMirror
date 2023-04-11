using UnityEngine.EventSystems;
using UnityEngine;

public class ItemSetActive : MonoBehaviour, IDropHandler
{
    [Header("ItemHolders")]
    [Space(2)]
    [SerializeField] private Transform ItemHolder;
    [SerializeField] private Transform LeftHand;
    [SerializeField] private Transform RightHand;

    [Header("ItemsArray")]
    [Space(2)]
    [SerializeField] private ItemsArray ItemsArray;

    private string ExTag;

    public void OnDrop(PointerEventData eventData)
    {
        
        ExTag = eventData.pointerDrag.tag;

        if (GetComponent<ItemSlot>().CompareTag("LeftHand")) 
        {
            SetItemInHandActive("LeftHandItem", LeftHand, eventData);
        }

        if (GetComponent<ItemSlot>().CompareTag("RightHand"))
        {
            SetItemInHandActive("RightHandItem", RightHand, eventData);
        }

        if (GetComponent<ItemSlot>().CompareTag("Slot"))
        {

            for (int i = 0; i < ItemsArray.items.Length; i++)
            {

                if (ItemsArray.items[i].name == eventData.pointerDrag.name)
                {
                    SetItemInSlot(i);
                    eventData.pointerDrag.tag = "item";
                }
            }
        }

        if (GetComponent<ItemSlot>().CompareTag("item") || GetComponent<ItemSlot>().CompareTag("RightHandItem") || GetComponent<ItemSlot>().CompareTag("LeftHandItem"))
        {
            eventData.pointerDrag.tag = GetComponent<ItemSlot>().tag;
            GetComponent<ItemSlot>().tag = ExTag;
            
            if (GetComponent<ItemSlot>().CompareTag("item"))
            {
                for(int i =0; i < ItemsArray.items.Length; ++i)
                {
                    if(GetComponent<ItemSlot>().name == ItemsArray.items[i].name)
                    {
                        SetItemInSlot(i);
                    }
                    if (eventData.pointerDrag.CompareTag("RightHandItem"))
                    {
                        SetItemInHandActive("RightHandItem", RightHand, eventData);
                    }
                    else if (eventData.pointerDrag.CompareTag("LeftHandItem"))
                    {
                        SetItemInHandActive("LeftHandItem", LeftHand, eventData);
                    }
                }
            }

            if (GetComponent<ItemSlot>().CompareTag("RightHandItem") && eventData.pointerDrag.CompareTag("LeftHandItem"))
            {
                SetSwitchedItemsActive(RightHand, LeftHand, eventData);
            }

            if (GetComponent<ItemSlot>().CompareTag("LeftHandItem") && eventData.pointerDrag.CompareTag("RightHandItem"))
            {
                SetSwitchedItemsActive(LeftHand, RightHand, eventData);
            }

        }
    }

    private void SetItemInHandActive( string tag, Transform parent, PointerEventData eventData)
    {
        for (int i = 0; i < ItemsArray.items.Length; i++)
        {
            if (eventData.pointerDrag.CompareTag("LeftHandItem") && eventData.pointerDrag.CompareTag("RightHandItem"))
            {
                ItemsArray.items[i].gameObject.SetActive(false);
            }
            if (ItemsArray.items[i].name == eventData.pointerDrag.name)
            {
                ItemsArray.items[i].parent = parent;
                ItemsArray.items[i].gameObject.SetActive(true);
                eventData.pointerDrag.tag = tag;
            }           
        }
    }

    private void SetSwitchedItemsActive(Transform HandOne, Transform HandTwo, PointerEventData eventData)
    {
        for (int i = 0; i < ItemsArray.items.Length; ++i)
        {
            if (GetComponent<ItemSlot>().name == ItemsArray.items[i].name)
            {
                ItemsArray.items[i].parent = HandOne;
            }
            if (eventData.pointerDrag.name == ItemsArray.items[i].name)
            {
                ItemsArray.items[i].parent = HandTwo;
            }
        }
    }

    private void SetItemInSlot(int i)
    {
        ItemsArray.items[i].parent = ItemHolder;
        ItemsArray.items[i].gameObject.SetActive(false);
    }
}
