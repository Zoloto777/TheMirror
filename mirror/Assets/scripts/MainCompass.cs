using System.Collections.Generic;
using UnityEngine;

public class MainCompass : MonoBehaviour
{
    [SerializeField] RandomSideDecider randomSide;
    [SerializeField] Transform Player;
    [SerializeField] List<GameObject> Sides = new();

    void Update()
    {
        float AxisY = Player.eulerAngles.y;

        //Haram code, needs to be updated
        if (randomSide.east)
        {
            if (AxisY < 310 && AxisY > 240)
            {
                DirectionChoice(Sides[2]);
            }
            else if (AxisY > 50 && AxisY < 170)
            {
                DirectionChoice(Sides[3]);
            }
            else if (AxisY < 170 || AxisY > 310)
            {
                DirectionChoice(Sides[0]);
            }
            else if (AxisY > 80 || AxisY < 310)
            {
                DirectionChoice(Sides[1]);
            }
        }

        /////////////////////////////////////////////////
        if (randomSide.west)
        {
            if (AxisY < 310 && AxisY > 240)
            {
                DirectionChoice(Sides[3]);
            }
            else if (AxisY > 70 && AxisY < 150)
            {
                DirectionChoice(Sides[2]);
            }
            else if (AxisY < 150 || AxisY > 310)
            {
                DirectionChoice(Sides[1]);
            }
            else if (AxisY > 80 || AxisY < 310)
            {
                DirectionChoice(Sides[0]);
            }
        }

        ///////////////////////////////////////////////
        if (randomSide.north)
        {
            if (AxisY < 310 && AxisY > 240)
            {
                DirectionChoice(Sides[1]);
            }
            else if (AxisY > 70 && AxisY < 150)
            {
                DirectionChoice(Sides[0]);
            }
            else if (AxisY < 150 || AxisY > 310)
            {
                DirectionChoice(Sides[2]);
            }
            else if (AxisY > 80 || AxisY < 310)
            {
                DirectionChoice(Sides[3]);
            }
        }

        //////////////////////////////////////////////////////
        if (randomSide.south)
        {
            if (AxisY < 310 && AxisY > 240)
            {
                DirectionChoice(Sides[0]);
            }
            else if (AxisY > 70 && AxisY < 150)
            {
                DirectionChoice(Sides[1]);
            }
            else if (AxisY < 150 || AxisY > 310)
            {
                DirectionChoice(Sides[3]);
            }
            else if (AxisY > 80 || AxisY < 310)
            {
                DirectionChoice(Sides[2]);
            }
        }
    }

         public void DirectionChoice(GameObject direction)
         {
            for(int i = 0; i < Sides.Count; i++)
            {
               Sides[i].SetActive(false);
                 if (direction.name == Sides[i].name)
                 {
                    Sides[i].SetActive(true);
                 }
            }
         } 
}
