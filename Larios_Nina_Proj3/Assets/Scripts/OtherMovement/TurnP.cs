using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnP : MonoBehaviour {

    protected Rigidbody rb = null;
    [SerializeField] public float turnSpeed = 1.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        TurnPlayer();
    }

    protected virtual void TurnPlayer()
    {
        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed;
        Quaternion turnOffset = Quaternion.Euler(0, turnAmount, 0);
        rb.MoveRotation(rb.rotation * turnOffset);
    }

}
