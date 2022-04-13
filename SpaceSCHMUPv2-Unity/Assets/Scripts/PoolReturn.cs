/**** 
 * Created by: Ava Fritts
 * Date Created: April 11, 2022
 * 
 * Last Edited by: Ava Fritts
 * Last Edited: April 11 2022
 * 
 * Description: object pool controller
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReturn : MonoBehaviour
{
    private ObjectPool pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = ObjectPool.POOL;
    }

    // Update is called once per frame
    private void OnDisable()
    {
        if(pool!= null)
        {
            pool.ReturnObject(this.gameObject); //return object to pool
        }
        
    }
}
