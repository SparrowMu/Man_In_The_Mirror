using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Move one object will affect the other side
 * Sparrow 6/20/2019
 */
public class Mirror_Moving_M : MonoBehaviour
{
    public Transform object_bro;
    bool player2_pick = false;
    bool if_pick = false;

    void Update()
    {
        if (player2_pick == true && Input.GetKeyDown(KeyCode.P))
        {
            if_pick = true;
        }
        else if (if_pick == true && Input.GetKeyDown(KeyCode.P))
        {
            if_pick = false;
        }
        if (if_pick == true)
        {
            float x = -transform.position.x;
            float y = transform.position.y;
            Vector3 new_position = new Vector3(x, y, 0f);
            object_bro.position = new_position;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "P2" && object_bro.GetComponent<Mirror_Moving_R>().Get_Player1_Pick() == false)
        {
            player2_pick = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "P2" || object_bro.GetComponent<Mirror_Moving_R>().Get_Player1_Pick() == true)
        {
            player2_pick = false;
        }
    }

    public bool Get_Player2_Pick()
    {
        return player2_pick;
    }
}
