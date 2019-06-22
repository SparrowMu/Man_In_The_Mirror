using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Check light hit mirror
 * Then lit the mirror in the mirror_world
 * Change the light intensity while the light get close or further
 * Sparrow 6/20/2019
 */
public class Mirror_Light_Connect : MonoBehaviour
{
    public Light Mirror_Light;
    float intensity = 0f;
    float light_distance = 0f;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    /*
     * Check if the light source is hitting the mirror
     * Sparrow 6/20/2019
     */
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "LightSource")
        {
            light_distance = (other.GetComponent<Transform>().position - transform.position).sqrMagnitude;
            Mirror_Light.intensity = (1.3f - light_distance) * 2;
        }
    }
}
