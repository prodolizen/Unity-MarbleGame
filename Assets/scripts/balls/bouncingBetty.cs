using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncingBetty : ball
{
    Vector3 direction;


    void OnCollisionEnter()
    {
        StartCoroutine(RndForces());
    }

    IEnumerator RndForces()
    {
        while (true)
        {
            yield return new WaitForSeconds(5); //every 5 seconds effects will occur 
            direction.z = Random.Range(500, 1000); //random jump between 500, 1000
            base.rigidbodyball.AddForce(new Vector3(0, direction.z, 0));
        }
    }
}

