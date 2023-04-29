using System.Linq;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public PickUpItems items;
    public GameObject TheEnd;
   public GameObject TheEndScreen;
    public DoorScript selectorScript;

    private void Update()
    {
        if (!items.strings.Any(i => i != items.strings[0]))
        {
           TheEnd.SetActive(true);
        }
    }

    //private void OnTriggerStay()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        string GameobjectName = selectorScript.BoxCollider.name;
    //        selectorScript.FindDoor(GameobjectName);
    //    }
    //}
}
