using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatThrow : MonoBehaviour {

    public GameObject boomer;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
                //throw hat
                //if hat doesn't collide with "playerpos" obj, return to player
                GameObject clone;
                clone = Instantiate(boomer, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as GameObject;
                //only have one hat at a time
        }
	}
}
