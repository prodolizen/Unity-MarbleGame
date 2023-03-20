using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_shoot : MonoBehaviour
{
    public GameObject marblelaunch;
    private GameObject spawnedmarble;
    public bool hasball = false;
    public int launchforce;
    Vector3 launchangle;
    public AudioSource shootsound;

    private void Start() //sets int launch force to movable angles
    {
        launchangle = transform.localEulerAngles;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.X)) //launch force increased when X is pressed
        {
            launchforce++;
        }

        if (Input.GetKey(KeyCode.Z)) //launch force is decreased when Y is pressed
        {
            launchforce--;
        }

        if (Input.GetKeyDown(KeyCode.Space)) //when space is pressed marble is spawned on the launcher 
        {
            if (hasball == false)
            {
                spawnedmarble = GameObject.Instantiate(marblelaunch, this.transform);
                spawnedmarble.transform.parent = this.gameObject.transform;
                hasball = true;
            }
          
        }
        if (Input.GetMouseButtonDown(0)) //when mouse1 is clicked marble is launched 
        {
            Debug.Log("mousedown");
            if (hasball == true && spawnedmarble.GetComponent<ball>().islaunched == false)
            {
                Debug.Log(spawnedmarble.GetComponent<ball>().islaunched);
                spawnedmarble.transform.parent = null;
                spawnedmarble.GetComponent<ball>().shootball(launchforce);
                shootsound.Play();
              
            }
        }
        if (Input.GetKey(KeyCode.UpArrow)) //raises angle of elevation
        {
            launchangle.x -= 25 * Time.deltaTime;
            transform.localEulerAngles = launchangle;
        }

        if (Input.GetKey(KeyCode.DownArrow)) //lowers angle of elevation 
        {
            launchangle.x += 25 * Time.deltaTime;
            transform.localEulerAngles = launchangle;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) //tilts the launch angle to the left
        {
            launchangle.y -= 25 * Time.deltaTime;
            transform.localEulerAngles = launchangle;
        }

        if (Input.GetKey(KeyCode.RightArrow)) //tilts the launch angle to the right
        {
            launchangle.y += 25 * Time.deltaTime;
            transform.localEulerAngles = launchangle;
        }
    }
}
