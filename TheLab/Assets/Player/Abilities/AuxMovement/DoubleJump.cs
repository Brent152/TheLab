using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{

    PlayerMovement movementScript;

    public bool usedDoubleJump = false;

    // Start is called before the first frame update
    void Start()
    {
        movementScript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movementScript.isGrounded)
        {
            usedDoubleJump = false;
        }

        if (Input.GetKeyDown(PlayerKeybinds.jump) && !movementScript.isGrounded && !usedDoubleJump)
        {
            movementScript.Jump(movementScript.JUMP_HEIGHT, movementScript.playerGravity.y);
            usedDoubleJump = true;
        }
    }
}
