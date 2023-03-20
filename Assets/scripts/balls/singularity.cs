using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singularity : ball
{
    private bool hit = false;
    private Collider[] detectoverlap;
    private void OnCollisionEnter(Collision collision)
    {
        if (hit == false)
        {
            hit = true;
        }
    }

    private void FixedUpdate()
    {
        if (hit)
        {
            detectoverlap = Physics.OverlapSphere(gameObject.transform.position, 5); //marble effects objects withing a 5 radius in all directions as its a sphere
            for (int i = 0; i < detectoverlap.Length; i++)
            {
                Rigidbody detectrigidbody = detectoverlap[i].transform.parent.gameObject.GetComponent<Rigidbody>();

                if (detectrigidbody != null && detectrigidbody != rigidbodyball)
                {
                    rigidbodyball.AddForce(0, Physics.gravity.y * 2, 0, ForceMode.Acceleration);
                }
            }
        }
    }
}