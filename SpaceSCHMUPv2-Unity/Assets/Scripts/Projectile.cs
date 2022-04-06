/**** 
 * Created by: Ava Fritts
 * Date Created: April 6, 2022
 * 
 * Last Edited by: Ava Fritts
 * Last Edited: April 6 2022
 * 
 * Description: Hero projectile controller
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    /*** VARIABLES ***/
    private BoundsCheck bndCheck;

    // Start is called before the first frame update
    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>(); //get the boundary component
    }

    // Update is called once per frame
    void Update()
    {
        if (bndCheck.offUp)
        {
            Destroy(gameObject);
        }//end if
    }
}
