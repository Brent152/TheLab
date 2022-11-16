using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{

    public float CROUCH_RATIO;
    PlayerMovement movementScript;
    float playerHeight;
    Vector3 cameraPosition;
    bool isCrouching;

    // Start is called before the first frame update
    void Start()
    {
        CROUCH_RATIO = .33f;
        movementScript = GetComponent<PlayerMovement>();
        playerHeight = GetComponent<CharacterController>().height;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(PlayerKeybinds.crouch) && !isCrouching)
        {
            isCrouching = true;
            movementScript.controller.height = playerHeight / 2;
            movementScript.playerCamera.transform.position -= new Vector3(0, playerHeight * CROUCH_RATIO, 0);
        }

        if (isCrouching && !movementScript.hitRoof && !Input.GetKey(PlayerKeybinds.crouch))
        {
            isCrouching = false;
            movementScript.controller.height = playerHeight;
            movementScript.playerCamera.transform.position += new Vector3(0, playerHeight * CROUCH_RATIO, 0);
        }
    }
}
