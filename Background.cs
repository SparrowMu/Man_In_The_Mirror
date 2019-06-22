using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is for all enironment (background)
 */
public class Background : MonoBehaviour
{
    public Transform player;

    public Material default_material;
    public Material light_effect;

    Vector3[] corners = new Vector3[4];
    

    void Start()
    {
        gameObject.GetComponent<RectTransform>().GetWorldCorners(corners);
    }
    
    void Update()
    {
        Change_Material();
    }
    
    /*
     * Check if player is in the environment
     * Sparrow 6/20/2019
     */
    bool If_In()
    {
        bool if_in = false;
        if((player.position.x >= corners[0].x && player.position.x <= corners[2].x) && (player.position.y >= corners[0].y && player.position.y <= corners[2].y))
        {
            if_in = true;
        }
        else
        {
            if_in = false;
        }
        return if_in;
    }

    /*
     * Change environment's metarial to:
     *     1) Sprite default
     *     2) Light Effect
     * Sparrow 6/20/2019
     */
    void Change_Material()
    {
        if(If_In())
        {
            gameObject.GetComponent<Renderer>().material = light_effect;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = default_material;
        }
    }
}
