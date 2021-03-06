/**** 
 * Created by: Ava Fritts
 * Date Created: April 12, 2022
 * 
 * Last Edited by: Ava Fritts
 * Last Edited: April 12 2022
 * 
 * Description: object pool controller
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScroller : MonoBehaviour
{
    /***VARIABLES***/
    public Vector2 scrollSpeed = new Vector2(0, 0f); //x and y speed for scroll
    private Renderer goRenderer; //game object's renderer component
    private Material goMat; //the game object's material
    private Vector2 offset; //the offset of scroll

    // Start is called before the first frame update
    void Start()
    {
        goRenderer = GetComponent<Renderer>();
        goMat = goRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        offset = (scrollSpeed * Time.deltaTime); //set offset value over time
        goMat.mainTextureOffset += offset; //set texture offeset
    }
}
