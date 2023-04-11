using Unity.VisualScripting;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public GameObject[] sides;
    public Material[] material;
    public RandomSideDecider randomSide;
    
    void Update ()
    { 
        OnSideChange();
    }
    void OnSideChange()
    {
        ////////////////////////////////
        if (randomSide.east)
        {
            MaterialChange(sides[0], material[1]);
        }
        else 
        {
            MaterialChange(sides[0], material[0]);  
        }

        ////////////////////////////////
        if (randomSide.west)
        {
            MaterialChange(sides[1], material[1]);
        }
        else 
        {
            MaterialChange(sides[1], material[0]);
        }

        ////////////////////////////////
       if (randomSide.south)
       {
            MaterialChange(sides[2], material[1]);
       }
       else 
       {
            MaterialChange(sides[2], material[0]);
       }

        ////////////////////////////////
        if (randomSide.north)
        {
            MaterialChange(sides[3], material[1]);
        }
        else 
        {
            MaterialChange(sides[3], material[0]);
        }
    }

    void MaterialChange(Object SideIndex, Material MaterialIndex)
    {
        SideIndex.GetComponent<Renderer>().material = MaterialIndex;
    }
}
