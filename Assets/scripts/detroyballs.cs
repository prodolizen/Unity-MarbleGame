using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detroyballs : MonoBehaviour
{
    public float hp;

   
    void Update()
    {
        Debug.Log(hp);

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
