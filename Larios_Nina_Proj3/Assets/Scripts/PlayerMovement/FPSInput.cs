using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FPSInput : MonoBehaviour
{
    public event Action<Vector3> MoveInput = delegate { };
    public event Action JumpInput = delegate { };

    public AudioClip footsteps;
    public AudioSource MusicSource;
    public ParticleSystem dust;

    private void Update()
    {
        DetectMoveInput();
        DetectJumpInput();

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            MusicSource.Play();
            dust.Play();
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            MusicSource.Stop();
            dust.Stop();
        }
    }

    void DetectMoveInput()
    {
        float yInput = Input.GetAxisRaw("Vertical");

        if (yInput != 0)
        {
            Vector3 forwardMovement = transform.forward * yInput;
            Vector3 movement = (forwardMovement).normalized;
            MoveInput.Invoke(movement);
        }
    }
    void DetectJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpInput.Invoke();
        }
    }
}
