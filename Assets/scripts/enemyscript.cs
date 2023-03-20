using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript : MonoBehaviour
{
    bool isdead = false;
    public Transform cagelocation; //allows us to be able to transform target to cagelocation
    public AudioSource collectsound;
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player" && isdead == false)
        {
            isdead = true; //target has been captured
            this.gameObject.transform.position = cagelocation.position; //moves the captured ball to the capture zone
            collectsound.Play(); //plays audio when target is captured
        }
    }

}