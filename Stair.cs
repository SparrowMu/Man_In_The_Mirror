using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Let the stair on or off the path of the player
 * Sparrow 6/22/2019
 */
public class Stair : MonoBehaviour
{
    public GameObject stair;
    public GameObject hide_ground;

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "P1")
        {
            stair.layer = 11;
            hide_ground.layer = 11; //Also need to make the floor upstairs disabled
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "P1" && Input.GetKey(KeyCode.E))
        {
            stair.layer = 0;
        }
    }
}
