using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    public Animator animator;
    float MoveSpeed;

	// Use this for initialization
	void Start () {
        animator = this.gameObject.GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
        MoveSpeed = Input.GetAxis("Vertical");
        animator.SetFloat("MoveSpeed",MoveSpeed);
	}
}
