/**** 
 * Created by: Ava Fritts
 * Date Created: April 6, 2022
 * 
 * Last Edited by: Ava Fritts
 * Last Edited: April 11 2022
 * 
 * Description: Hero projectile controller
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    static public ObjectPool POOL;
    #region POOL Singleton
    void CheckPoolIsInScene()
    {
        if(POOL == null)
        {
            POOL = this;
        }
        else
        {
            Debug.LogError("POOL.Awake() - Attempted to assign a second ObjectPool.POOL");
        }
    }
    #endregion

    private Queue<GameObject> projectiles = new Queue<GameObject>(); //new queue of projectiles
    [Header("Pool settings")]
    public GameObject projectilePrefab;
    public int poolStartSize = 5;

    /***Methods***/

    private void Awake()
    {
        CheckPoolIsInScene();
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < poolStartSize; i++)
        {
            GameObject projectileGO = Instantiate(projectilePrefab);
            projectiles.Enqueue(projectileGO);
            projectileGO.SetActive(false); //disabled in scene
        }
    }//end Start()

    public GameObject GetObject()
    {
        if(projectiles.Count > 0)
        {
            GameObject gObject = projectiles.Dequeue();
            gObject.SetActive(true);
            return gObject;
        }
        else
        {
            Debug.LogWarning("Out of Objects, reloading...");
            return null;
        }
    }

    public void ReturnObject(GameObject gObject)
    {
        projectiles.Enqueue(gObject); //add to queue
        gObject.SetActive(false); //disable
    }//end ReturnObject
}
