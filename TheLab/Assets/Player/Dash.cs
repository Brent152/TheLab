using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float DASH_SPEED;
    public float DASH_TIME_SECONDS;
    PlayerMovement movementScript;

    Vector3 originalVelocity;
    public bool isDashing;

    // Start is called before the first frame update
    void Start()
    {
        DASH_SPEED = 100f;
        DASH_TIME_SECONDS = .2f;
        isDashing = false;
        movementScript = GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            isDashing = true;
            originalVelocity = movementScript.velocity;
            movementScript.velocity += movementScript.playerCamera.transform.forward * DASH_SPEED;
            StartCoroutine(DashTimer());
        }
    }

    IEnumerator DashTimer()
    {
        yield return new WaitForSeconds(DASH_TIME_SECONDS);
        movementScript.velocity = originalVelocity;
        isDashing = false;
    }
}
