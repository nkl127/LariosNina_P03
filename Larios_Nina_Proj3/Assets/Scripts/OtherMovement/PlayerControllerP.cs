﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FPSInputP))]
[RequireComponent(typeof(FPSMotorP))]

public class PlayerControllerP : MonoBehaviour {

    FPSInput input = null;
    FPSMotor motor = null;

    [SerializeField] float moveSpeed = .1f;
    [SerializeField] float jumpStrength = 10f;

    public AudioClip footsteps;
    public AudioSource MusicSource;

    private void Awake()
    {
        input = GetComponent<FPSInput>();
        motor = GetComponent<FPSMotor>();
    }
    private void OnEnable()
    {
        input.MoveInput += OnMove;
        input.JumpInput += OnJump;
    }
    private void OnDisable()
    {
        input.MoveInput -= OnMove;
        input.JumpInput -= OnJump;
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void OnMove(Vector3 movement)
    {
        motor.Move(movement * moveSpeed);
    }
    void OnJump()
    {
        motor.Jump(jumpStrength);
    }
    void IncreaseSpeed()
    {
        moveSpeed = .3f;
    }
    void DecreaseSpeed()
    {
        moveSpeed = .1f;
    }
}
