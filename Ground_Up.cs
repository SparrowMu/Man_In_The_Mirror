using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Let the ground above the stairs be or not be the path of the player
 * Sparrow 6/22/2019
 */
public class Ground_Up : MonoBehaviour
{
    public GameObject stair;
    public GameObject hide_ground;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9 && collision.transform.position.y > transform.position.y)
        {
            hide_ground.layer = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9 && Input.GetKey(KeyCode.S))
        {
            hide_ground.layer = 11;
            stair.layer = 0;
        }
    }
}
