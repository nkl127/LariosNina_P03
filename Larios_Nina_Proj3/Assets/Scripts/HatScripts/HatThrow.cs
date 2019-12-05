using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatThrow : MonoBehaviour {

    public GameObject boomer;
    int count = 0;
    float timeLeft =  .03f;


    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //throw hat
            //if hat doesn't collide with "playerpos" obj, return to player
            GameObject clone;
            if (count == 0)
            {
                timeLeft = .03f;
                clone = Instantiate(boomer, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as GameObject;
                count = 1;
                //only have one hat at a timw
            }
            if (count == 1)
            {
                timeLeft -= Time.deltaTime;
            }
            if (timeLeft <= 0)
            {
                count = 0;
            }
        }
	}
}
