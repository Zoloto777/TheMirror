using System.Linq;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public PickUpItems items;
    public GameObject TheEnd;
    public GameObject TheEndScreen;

    private void Update()
    {
        if (!items.strings.Any(i => i != items.strings[0]))
        {
            TheEnd.SetActive(true);
        }
    }

    private void OnTriggerEnter()
    {
        TheEndScreen.SetActive(true);
    }
}
