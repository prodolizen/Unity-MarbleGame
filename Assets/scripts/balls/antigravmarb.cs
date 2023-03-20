using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antigravmarb : ball
{
    private bool hit = false;
    private Collider[] detectoverlap;
    private void OnCollisionEnter(Collision collision)
    {
        if (hit == false) //sets hit to true if collision occurs
        {
            hit = true;
        }
    }

    private void FixedUpdate()
    {
        if (hit)
        {
            detectoverlap = Physics.OverlapSphere(gameObject.transform.position, 5); //overlap sphere with radius 5 is added to marble
            for (int i = 0; i < detectoverlap.Length; i++) 
            {
                Rigidbody detectrigidbody = detectoverlap[i].transform.parent.gameObject.GetComponent<Rigidbody>(); 

                if (detectrigidbody != null && detectrigidbody != rigidbodyball) //if a rigidbody that isnt a marble is detected 
                {
                    rigidbodyball.AddForce(0, -Physics.gravity.y * 2, 0, ForceMode.Acceleration); //causes objects to float at 2x gravity
                }
            }
        }
    }
}