using UnityEngine;

public class ItemsArray : MonoBehaviour
{
    public GameObject ItemHolder;
    public Transform[] items;

    private void Start()
    {
        SetItems();
    }
    private void SetItems()
    {
        items = new Transform[ItemHolder.transform.childCount];

        for (int i = 0; i < items.Length; i++)
        {
            items[i] = ItemHolder.transform.GetChild(i);
        }
    }
}
