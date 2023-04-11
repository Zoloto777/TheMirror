using UnityEngine;

public class ItemSwitch : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform[] items;

    [Header("Keys")]
    [SerializeField] private KeyCode[] keys;

    [Header("Settings")]
    [SerializeField] private float switchTime;

    private int selectedItem;

    private float lastSwitchTime;

    private void Start()
    {
        SetItems();
        Select(selectedItem);
    }

    private void SetItems()
    {
        items = new Transform[transform.childCount];

        for (int i= 0 ; i < items.Length ; i++)
        {
            items[i] = transform.GetChild(i);
        }
        if (keys == null) { 
            keys = new KeyCode[items.Length]; 
        }
    }


    private void Update()
    {
        int PreviousSelectedItem = selectedItem;

        for (int i = 0; i < keys.Length; i++)
        {
            if (Input.GetKeyDown(keys[i]) && lastSwitchTime >= switchTime)
            {
                selectedItem = i;
            }

            if (PreviousSelectedItem != selectedItem)
            {
                Select(selectedItem);
            }  
            
        }
        lastSwitchTime += Time.deltaTime;
    }

    private void Select(int itemIndex)
    {

        for (int i = 0; i < items.Length; i++)
        { 
            items[i].gameObject.SetActive(i == itemIndex);
        }        
        lastSwitchTime = 0f;
    }

    
}
