using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Pick up objects
 * The Object should be in the hand of the player
 * Sparrow 6/21/2019
 */
public class Hold_Object : MonoBehaviour
{
    public Transform hand;
    private Collider2D col = null;

    private bool if_object = false;
    private bool if_hold = false;
    
    void Update()
    {
        if(if_object && Input.GetKeyDown(KeyCode.Q) && if_hold == false)
        {
            if_hold = true;
        }
        else if(if_object && Input.GetKeyDown(KeyCode.Q) && if_hold == true)
        {
            if_hold = false;
        }
        if(if_hold)
        {
            col.GetComponent<Transform>().position = hand.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Object" && if_hold == false)
        {
            if_object = true;
            this.col = col;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Object" && if_hold == false && this.col.Equals(col))
        {
            if_object = false;
            this.col = null;
        }
    }
}
