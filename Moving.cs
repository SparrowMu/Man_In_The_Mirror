using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Contral player moving left right and up stairs
 * Sparrow 6/21/2019
 * 
 * Last change: Sparrow 6/22/2019
 */
public class Moving : MonoBehaviour
{
    float speed = 5f;
    Vector2 zero_velocity = new Vector2(0, 0);

    Collision2D col;

    void Start()
    {
        
    }
    
    void Update()
    {
        //Moving on the ground
        if (col.collider.tag == "Environment")
        {
            if (Input.GetKey(KeyCode.A))
            {
                GetComponent<Rigidbody2D>().velocity = -transform.right * speed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                GetComponent<Rigidbody2D>().velocity = transform.right * speed;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = zero_velocity;
            }
        }
        //Moving on stairs
        else if(col.collider.tag == "Stair")
        {
            if(col.transform.rotation.z < 0)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    GetComponent<Rigidbody2D>().velocity = -(transform.right * 0.707f + transform.up * 0.707f) * speed;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    GetComponent<Rigidbody2D>().velocity = (transform.right * 0.707f + transform.up * 0.707f) * speed;
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = zero_velocity;
                }
            }
            else if (col.transform.rotation.z > 0)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    GetComponent<Rigidbody2D>().velocity = -(transform.right * 0.707f - transform.up * 0.707f) * speed;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    GetComponent<Rigidbody2D>().velocity = (transform.right * 0.707f - transform.up * 0.707f) * speed;
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = zero_velocity;
                }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Environment" || collision.collider.tag == "Stair")
        {
            col = collision;
        }
        if(collision.collider.tag == "Stair")
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "Stair")
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 10;
        }
        if(collision.collider.tag == "Environment" || collision.collider.tag == "Stair")
        {
            col = null;
        }
    }
}
