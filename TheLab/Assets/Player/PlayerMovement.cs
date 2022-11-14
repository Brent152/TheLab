using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float SPEED;
    public float HEAD_CHECK_DISTANCE;
    public float GROUND_CHECK_DISTANCE;
    public float JUMP_HEIGHT;
    public Vector3 playerGravity = new Vector3(0, Physics.gravity.y * 3, 0);
    public GameObject playerCamera;

    public CharacterController controller;
    public Transform headCheck;
    public Transform groundCheck;
    public LayerMask groundMask;

    public Vector3 velocity;
    public bool isGrounded;
    public bool hitRoof;

    // Start is called before the first frame update
    void Start()
    {
        SPEED = 12f;
        GROUND_CHECK_DISTANCE = .4f;
        HEAD_CHECK_DISTANCE = .4f;
        JUMP_HEIGHT = 3f;

        controller = GetComponent<CharacterController>();
        groundCheck = GameObject.Find("GroundCheck").transform;
        headCheck = GameObject.Find("HeadCheck").transform;
        groundMask = LayerMask.GetMask("Ground");
        playerCamera = GameObject.Find("PlayerCamera");
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, GROUND_CHECK_DISTANCE, groundMask);
        hitRoof = Physics.CheckSphere(headCheck.position, HEAD_CHECK_DISTANCE, groundMask);

        if (hitRoof && velocity.y > 0)
        {
            velocity.y = 0;
        }

        if (isGrounded)
        {
            if (velocity.y < 0)
            {
                velocity.y = -2f;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump(JUMP_HEIGHT, playerGravity.y);
            }
        }

        velocity += playerGravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        controller.Move(move * SPEED * Time.deltaTime);


    }

    public void jump(float jumpHeight, float inputGravity)
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * inputGravity);
    }

}
