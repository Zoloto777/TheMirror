using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    public PickUpItems items;
    public GameObject TheEndTrigger;

    private void Update()
    {
        if (!items.strings.Any(i => i != items.strings[0]))
        {
            TheEndTrigger.SetActive(true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EndTrigger")
        {
            SceneManager.LoadScene(1);
        }
    }
}

