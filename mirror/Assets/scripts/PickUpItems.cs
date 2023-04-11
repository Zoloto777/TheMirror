using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{

    [SerializeField] Transform cam;
    [SerializeField] float ActiveDistance;

    [Header("Lists")]
    [Space(5)]
    [SerializeField] List<TextMeshProUGUI> Texts = new();
    [SerializeField] List<GameObject> items = new();
    public List<string> strings = new();

    public void Update()
    {
        for (int i = 0; i < strings.Count; ++i)
        {
            Texts[i].text = strings[i];
        }

        bool active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out RaycastHit hit, ActiveDistance);

        if (!Input.GetKeyDown(KeyCode.E) || !active)
        {
            return;
        }
        
        if (!hit.transform.CompareTag("item"))
        {
            if (hit.transform.CompareTag("Item-usable"))
            {
                hit.transform.gameObject.SetActive(false);
                if (hit.transform.name == "Key") 
                {

                }
            }
            return;
        }

        for (int i = 0; i < strings.Count; ++i)
        {
            if (strings[i] == hit.transform.name && hit.transform.name == items[i].name)
            {
                strings[i] = "done";
                items[i].SetActive(false);
            }
        }
    }
}

