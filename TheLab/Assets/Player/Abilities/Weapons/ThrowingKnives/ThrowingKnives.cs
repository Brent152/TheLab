using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnives : MonoBehaviour
{
    [SerializeField] public int numThrows;

    public float THROWING_KNIFE_SPEED;
    PlayerMovement movementScript;
    public GameObject throwingKnife;
    public bool isThrowing;

    // Start is called before the first frame update
    void Start()
    {
        THROWING_KNIFE_SPEED = 30f;
        numThrows = 1;
        movementScript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frames
    void Update()
    {
        if (Input.GetKeyDown(PlayerKeybinds.primaryFire) && !isThrowing)
        {
            StartCoroutine("ThrowKnife", numThrows);
        }
    }

    IEnumerator ThrowKnife()
    {
        isThrowing = true;
        for (int i = 0; i < numThrows; i++)
        {
            GameObject tk = Instantiate(
            throwingKnife,
            movementScript.playerCamera.transform.position + movementScript.playerCamera.transform.forward.normalized * movementScript.PLAYER_WIDTH_ADJUST,
            movementScript.playerCamera.transform.rotation
            );
            tk.GetComponent<Transform>().Rotate(90, 0, 0);
            tk.GetComponent<Rigidbody>().velocity = movementScript.playerCamera.transform.forward * THROWING_KNIFE_SPEED;
            yield return new WaitForSeconds(.1f);
        }
        isThrowing = false;
    }

}
