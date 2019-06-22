using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Transform item from one mirror to the another
 * Sparrow 6/21/2019
 */
public class Send_Item : MonoBehaviour
{
    public Transform real_mirror;
    Collider2D col;

    bool is_trig = false;

    private void Update()
    {
        if(is_trig && Input.GetKeyDown(KeyCode.O))
        {
            col.GetComponent<Transform>().position = real_mirror.position;
            col.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    /*
     * Change the position of SpecialObject from mirror_world to real_world
     */
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "SpecialObject")
        {
            col = collider;
            is_trig = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "SpecialObject")
        {
            col = null;
            is_trig = false;
        }
    }
}
