using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FPSInputP : MonoBehaviour {

    public event Action<Vector3> MoveInput = delegate { };
    public event Action JumpInput = delegate { };

    private void Update()
    {
        DetectMoveInput();
        DetectJumpInput();
    }

    void DetectMoveInput()
    {
        //   float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        if (yInput != 0)
        {
            //   Vector3 horizontalMovement = transform.right * xInput;
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
