using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public Rigidbody rigidbodyball; //means the marble can collide with other objects
    public bool islaunched = false;
    
    public void shootball(int launchforce)
    {
        islaunched = true;
        rigidbodyball.isKinematic = false;
        rigidbodyball.AddForce(transform.forward * launchforce, ForceMode.VelocityChange); //adds forward force to the marble
        StartCoroutine(lifetime());

    }
   IEnumerator lifetime()
    {

        yield return new WaitForSeconds(10); //gives lifespan of 10s to the marble
        
        //if a marble is found whilst the player does not have a marble then the marble is destroyed
        GameObject.FindObjectOfType<ball_shoot>().hasball = false; 
        GameObject.Destroy(gameObject);

    }
}
