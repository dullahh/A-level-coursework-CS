using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public float randomXshift = 9f;
    public float randomYshift = 9f;
    public float zSpot = 29.3f;
    public int hitAccum = 0;// the variable that'll hold the amount of shots on target




    //}
    public void OnCollisionEnter(Collision collision)
    {
        float horizontalShift = UnityEngine.Random.Range(-randomXshift, randomXshift);
        float verticalShift = UnityEngine.Random.Range(2, randomYshift);

        if (collision.gameObject.CompareTag("projectile"))
        {
            hitAccum++;// this accumulates 1 to the count each time this condition is met
                        //(the target coming in contact with a bullet)
            transform.position = new Vector3(horizontalShift, verticalShift, zSpot);
            
         
            
        }

    }
}
