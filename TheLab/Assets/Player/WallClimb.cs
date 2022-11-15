using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimb : MonoBehaviour
{
    public float CLIMB_SPEED;
    public float CLIMB_REACH;
    PlayerMovement movementScript;



    // Start is called before the first frame update
    void Start()
    {
        CLIMB_SPEED = 15f;
        CLIMB_REACH = .7f;
        movementScript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Physics.Raycast(movementScript.playerCamera.transform.position, transform.forward, out RaycastHit hit, CLIMB_REACH, movementScript.groundMask))
            {
                movementScript.velocity.y = CLIMB_SPEED;
            }
        }

    }
}
