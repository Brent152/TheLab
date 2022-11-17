using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float PLATFORM_TIME_SECONDS;
    PlayerMovement movementScript;
    public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        PLATFORM_TIME_SECONDS = 3f;
        movementScript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frames
    void Update()
    {
        if (Input.GetKeyDown(PlayerKeybinds.auxMovement))
        {
            StartCoroutine("createPlatform", PLATFORM_TIME_SECONDS);
        }
    }

    IEnumerator createPlatform(float time)
    {

        GameObject pt = Instantiate(
        platform,
        movementScript.groundCheck.position,
        Quaternion.identity
        );

        yield return new WaitForSeconds(time);
        Destroy(pt);

    }
}
