using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public int maxHealth = 4000;
    public int currentHealth;
    public HealthBar HealthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        // float interactionRayLenght = 5.0f;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out _, Mathf.Infinity, LayerMask.GetMask("darkness")))
        {
            //    Vector3 endpoint = Camera.main.transform.forward * interactionRayLenght;
            //    Debug.Log("Game over");
            //    Debug.DrawLine(Camera.main.transform.position, endpoint);

            TakeDamage(2);

        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
 //       Debug.Log(currentHealth);
        HealthBar.SetMeter(currentHealth);
    }
}
