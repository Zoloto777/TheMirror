using UnityEngine;

public class MoveItemToSide : MonoBehaviour
{
    public void Update()
    {
            MoveItem();
    }
    public void MoveItem()
    {
        if (transform.childCount == 0) return;

        if (transform.name == "RightHand")
        {
            transform.GetChild(0).localPosition = new Vector3(1, transform.GetChild(0).localPosition.y, transform.GetChild(0).localPosition.z);
        }
        else
        {
            transform.GetChild(0).localPosition = new Vector3(-1, transform.GetChild(0).localPosition.y, transform.GetChild(0).localPosition.z);
        }

    }

}
