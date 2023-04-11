using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class RandomSideDecider : MonoBehaviour
{
    public FollowPlayer Follow;
    public Directions Directions;

    [Header("SidesList")]
    private readonly List<string> sides = new() { "east", "west", "south", "north" };
    
    [Header("Timer settings")]
    [Space(5)]
    [SerializeField] private float timeRemaining = 10;
    [SerializeField] private bool timerIsRunning = false;
    
    [Header("Sides-bool")]
    [Space(5)]
    public bool west = false;
    public bool east = false;
    public bool south = false;
    public bool north = false;
        
    void Start()
    {
        StartingSide();

        timerIsRunning = true;

        ThisSide("south");

        south = false;
        

            //Debug.Log(east);
            //Debug.Log(west);
            //Debug.Log(south);
            //Debug.Log(north);
    }

    void Update()
    {
        // simple Timer, when it runs Remaining time starts to subtract deltatime until it hits zero 
        // after that that it trigger "if else" statement and resumes
        if (!timerIsRunning)
        {
            return;
        }
        
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else 
             {
                if (east)
                {
                    ThisSide("east");
                    east = false;
                }

                else if (west)
                {
                    ThisSide("west");
                    west = false;
                }

                else if (south)
                {
                    ThisSide("south");
                    south = false;  
                }

                else if (north)
                {
                    ThisSide("north");
                    north = false;
                }

           //     Debug.Log(east);
           //     Debug.Log(west);
            //    Debug.Log(south);
           //     Debug.Log(north);

                timeRemaining = 0;
                timerIsRunning = false;

            }

        if (timeRemaining == 0)
        {
            timeRemaining = 10;
            timerIsRunning = true;
        }
    }

    // Main function which randomly decides next side. We set bools on "true" depending what side we get, 
    // The side that is now "true" will trigger "if else" statement and "ThisSide" function (look down the code to see what this function does)
    public void RandomSides(int maxNumber)
    {
        
        int randomNumber = Random.Range(0, maxNumber);
        Debug.Log(sides[randomNumber]);


        if (sides[randomNumber] == "east")
        {
            east = true;
            StartCoroutine(Directions.LeftSideDelay());
        }
        else if (sides[randomNumber] == "west")
        {
            west = true;
            StartCoroutine(Directions.RightSideDelay());
        }

        else if (sides[randomNumber] == "south")
        {
            south = true;
            StartCoroutine(Directions.BackSideDelay());
        }

        else if (sides[randomNumber] == "north")
        {
            north = true;
            StartCoroutine(Directions.FrontSideDelay());
        }


    }

    // Function that starts the entire process, we have to make sure for wall to always appears behind the player at the start of the game
    public void StartingSide()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        Follow.offset.z -= Follow.offset.z + 10;
        Follow.offset.x = 0;
    }

    //In order to avoid one side appearing two or more times in arrow we temporarily remove it from the list
    //after that we run "RandomSides" function with and put removed side back in to the list.
    public void ThisSide(string location)
    {
        sides.Remove(location);
        RandomSides(sides.Count);
        sides.Add(location);
    }

}

