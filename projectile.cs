using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("target"))
        {

            Destroy(gameObject); // destroy is a predefined function which terminates whatever
            // GameObject parameter is given, which in this case is the projectile itself

        }
        else if (collision.gameObject.CompareTag("environment object"))
        {
            Destroy(gameObject);
        }
    }
}    
