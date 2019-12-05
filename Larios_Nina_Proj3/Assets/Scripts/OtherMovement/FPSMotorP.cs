using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FPSMotorP : MonoBehaviour {

    Rigidbody rigid = null;

    Vector3 movementThisFrame = Vector3.zero;

    [SerializeField] GroundDetector groundDetector = null;
    bool isGrounded = false;

    public event Action Land = delegate { };

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        ApplyMovement(movementThisFrame);
    }
    private void OnEnable()
    {
        groundDetector.GroundDetected += OnGroundDetected;
        groundDetector.GroundVanished += OnGroundVanished;
    }
    private void OnDisable()
    {
        groundDetector.GroundDetected -= OnGroundDetected;
        groundDetector.GroundVanished -= OnGroundVanished;
    }


    public void Move(Vector3 requestedMovement)
    {
        movementThisFrame = requestedMovement;
    }
    public void Jump(float jumpForce)
    {
        if (isGrounded == false) return;
        rigid.AddForce(Vector3.up * jumpForce);
    }

    void ApplyMovement(Vector3 moveVector)
    {
        if (moveVector == Vector3.zero) return;
        rigid.MovePosition(rigid.position + moveVector);
        movementThisFrame = Vector3.zero;
    }
    void OnGroundDetected()
    {
        isGrounded = true;
        Land.Invoke();
    }
    void OnGroundVanished()
    {
        isGrounded = false;
    }
}
