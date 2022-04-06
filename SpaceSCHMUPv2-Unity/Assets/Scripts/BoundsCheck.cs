/**** 
 * Created by: Akram Taghavi-Burris
 * Date Created: March 16, 2022
 * 
 * Last Edited by: Ava Fritts
 * Last Edited: April 5 2022
 * 
 * Description: Checks if object is in bounds of camera
****/

/*** Using Namespaces ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    /*** VARIABLES ***/
    [Header("Bounds Settings")]
    public float radius = 1f;//the radius around the object to keep on screen
    public bool keepOnScreen = true; //does the object need to stay on screen

    [HideInInspector]
    public bool isOnScreen = true; //is the object on screen 
    [HideInInspector]
    public bool offLeft, offRight, offUp, offDown; //checks for where the object is off screen
    [HideInInspector]
    public float camWidth; //gets the width of the camera
    [HideInInspector]
    public float camHeight; //gets the height of the camera


    /*** MEHTODS ***/

    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        camHeight = Camera.main.orthographicSize; 
        //Height is the orthographic size of the main camera
        camWidth = camHeight * Camera.main.aspect; 
        //Aspect ratio is defined in the game view, multipling by the height will give the distance from the orging to the left of right edge of the scene.

    }//end Awake()


    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        Vector3 pos = transform.position; //vector 3 position 
        isOnScreen = true;

        //Right bound check
        if(pos.x > camWidth - radius)
        {   pos.x = camWidth - radius;
            offRight = true;
        }

        //Left bound check
        if (pos.x < -camWidth + radius) 
        {   pos.x = -camWidth + radius;
            offLeft = true;
        }

        //Top bound check
        if (pos.y > camHeight - radius) 
        {   pos.y = camHeight - radius;
            offUp = true;
        }

        //Bottom bound check
        if (pos.y < -camHeight + radius) 
        {   pos.y = -camHeight + radius;
            offDown = true;
        }

        //is the object on screen, depends if any one of the off bools are true, there by making isOnScreen false
        isOnScreen = !(offRight || offLeft || offUp || offDown);

        //if the object is to stay on screen but has moved off screen, move it back
        if(keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            isOnScreen = true;
            offRight = offLeft = offUp = offDown = false; // reset the off bools to false, when object is meant to stay on screen
        }

    }//end LateUpdate


    //Draw the bounds in the scene pane
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return; //if not playing, leave this alone!

        Vector3 boundsize = new Vector3(camWidth * 2, camHeight * 2, 0.1f); //set boundary size
        Gizmos.color = Color.yellow; //change color to yellow
        Gizmos.DrawWireCube(Vector3.zero, boundsize); //set wire cube to bounds
    } //end OnDrawGizmos()




}
