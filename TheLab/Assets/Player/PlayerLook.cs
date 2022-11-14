using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    float SENSITIVITY = 600f;

    [SerializeField]
    Transform playerTransform;

    float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform.parent.GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        xRotation -= Input.GetAxis("Mouse Y") * SENSITIVITY * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerTransform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * SENSITIVITY * Time.deltaTime);

    }
}
