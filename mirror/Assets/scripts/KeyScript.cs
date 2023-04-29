using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] float ActiveDistance;
    [SerializeField] List<GameObject> Keys = new();
    [SerializeField] GameObject KeyHolder;
    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        bool active = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out RaycastHit hit, ActiveDistance);

        if (!Input.GetKeyDown(KeyCode.E) || !active)
        {
            return;
        }

        if (!hit.transform.CompareTag("item"))
        {
            if (hit.transform.CompareTag("Item-usable"))
            {
                hit.transform.gameObject.SetActive(false);
                for(int i = 0; i < Keys.Count; i++)
                {
                    if(hit.transform.gameObject.name == Keys[i].name)
                    {
                        Debug.Log(Keys[i].name);
                    }
                }
            }
            return;
        }


    }
}
