using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{


    public float MAX_DISTANCE;
    public float PLAYER_WIDTH_ADJUST;

    PlayerMovement movementScript;


    // Start is called before the first frame update
    void Start()
    {
        MAX_DISTANCE = 80f;
        PLAYER_WIDTH_ADJUST = 1.5f;
        movementScript = GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Physics.Raycast(movementScript.playerCamera.transform.position,
            movementScript.playerCamera.transform.forward,
            out RaycastHit hit,
            MAX_DISTANCE, movementScript.groundMask))
            {
                Debug.Log(movementScript.playerCamera.transform.forward * PLAYER_WIDTH_ADJUST);
                movementScript.controller.enabled = false;
                transform.position = hit.point + hit.normal * PLAYER_WIDTH_ADJUST;
                movementScript.controller.enabled = true;
            }
        }
    }
}
