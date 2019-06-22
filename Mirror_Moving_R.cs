using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Move one object will affect the other side
 * Sparrow 6/20/2019
 */
public class Mirror_Moving_R : MonoBehaviour
{
    public Transform object_bro;
    bool player1_pick = false;
    bool if_pick = false;

    void Update()
    {
        if(player1_pick == true && Input.GetKeyDown(KeyCode.Q))
        {
            if_pick = true;
            
        }
        else if(if_pick == true && Input.GetKeyDown(KeyCode.Q))
        {
            if_pick = false;
        }
        if(if_pick == true)
        {
            float x = -transform.position.x;
            float y = transform.position.y;
            Vector3 new_position = new Vector3(x, y, 0f);
            object_bro.position = new_position;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "P1" && object_bro.GetComponent<Mirror_Moving_M>().Get_Player2_Pick() == false)
        {
            player1_pick = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "P1" || object_bro.GetComponent<Mirror_Moving_M>().Get_Player2_Pick() == true)
        {
            player1_pick = false;
        }
    }

    public bool Get_Player1_Pick()
    {
        return player1_pick;
    }
}
