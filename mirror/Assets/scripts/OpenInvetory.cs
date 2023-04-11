using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject inventory;
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
                inventoryIsClosed = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                inventory.SetActive(false);
                inventoryIsClosed = true;
            }
        }
        
    }
}
