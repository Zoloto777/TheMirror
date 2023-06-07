using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Directions : MonoBehaviour
{   
    public FollowPlayer Follow;

    // We use delay in order to emulate how compass works
    // for a player it looks like compass predicts where the next side is going to be
    // in reality it's just wall appearing with delay.

    // The rest of the code is just changing position of the wall depending on which side it's on
    // and we also change the offset. On X axis if the wall on the left or right side. On Z axis if the wall behind or infront of a player

    // code needs to be updated
    public IEnumerator FrontSideDelay()
    {
     //   FindObjectOfType<AudioManager>().Play("Beep");
        yield return new WaitForSeconds(5);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        Follow.offset.z += -Follow.offset.z + 10;
        Follow.offset.x = 0;
    }

    public IEnumerator BackSideDelay()
    {
    //    FindObjectOfType<AudioManager>().Play("Beep");
        yield return new WaitForSeconds(5);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        Follow.offset.z -= Follow.offset.z + 10;
        Follow.offset.x = 0;
    }

    public IEnumerator RightSideDelay()
    {
   //     FindObjectOfType<AudioManager>().Play("Beep");
        yield return new WaitForSeconds(5);
        transform.localRotation = Quaternion.Euler(0, 90, 0);
        Follow.offset.x += -Follow.offset.x + 10;
        Follow.offset.z = 0;
    }

    public IEnumerator LeftSideDelay()
    {
    //    FindObjectOfType<AudioManager>().Play("Beep");
        yield return new WaitForSeconds(5);
        transform.localRotation = Quaternion.Euler(0, 90, 0);
        Follow.offset.x -= Follow.offset.x + 10;
        Follow.offset.z = 0;
    }
    
}
