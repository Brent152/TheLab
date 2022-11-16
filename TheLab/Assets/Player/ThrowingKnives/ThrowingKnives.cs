using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnives : MonoBehaviour
{
    public float THROWING_KNIFE_SPEED;
    PlayerMovement movementScript;
    public GameObject throwingKnife;

    // Start is called before the first frame update
    void Start()
    {
        THROWING_KNIFE_SPEED = 30f;
        movementScript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(PlayerKeybinds.primaryFire))
        {
            GameObject tk = Instantiate(
                throwingKnife,
                movementScript.playerCamera.transform.position + movementScript.playerCamera.transform.forward.normalized * movementScript.PLAYER_WIDTH_ADJUST,
                movementScript.playerCamera.transform.rotation
            );
            tk.GetComponent<Transform>().Rotate(90, 0, 0);
            tk.GetComponent<Rigidbody>().velocity = movementScript.playerCamera.transform.forward * THROWING_KNIFE_SPEED;
        }
    }
}
