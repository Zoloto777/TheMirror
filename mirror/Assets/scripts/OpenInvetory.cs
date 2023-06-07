using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject Crosshair;
    private bool inventoryIsClosed;

    void Start()
    {
       inventoryIsClosed = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(inventoryIsClosed == true)
            {
                Cursor.lockState = CursorLockMode.Confined;
                inventory.SetActive(true);
                Crosshair.SetActive(false);
                inventoryIsClosed = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                inventory.SetActive(false);
                Crosshair.SetActive(true);
                inventoryIsClosed = true;
            }
        }
        
    }
}
