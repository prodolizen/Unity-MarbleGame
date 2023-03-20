using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weasel : ball
{
    Vector2 direction;


    void OnCollisionEnter() //causes wild weasels effects to occur only when comes in contact with the ground (lands)
    {
        StartCoroutine(RndForces());
    }
    
    IEnumerator RndForces()
    {
        while (true)
        {
            yield return new WaitForSeconds(1); //means random directions happen every second. 
            direction.x = Random.Range(-1000, 1000);
            direction.y = Random.Range(-1000, 1000);
            base.rigidbodyball.AddForce(new Vector3(direction.x, 0, direction.y));
        }
    }
   }

