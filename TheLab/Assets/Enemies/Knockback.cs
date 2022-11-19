using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeKnockback(Vector3 knockbackForce)
    {
        // Debug.Log("KNOCKED BACK: " + knockbackForce);
        rb.AddForce(knockbackForce, ForceMode.Impulse);
    }

}
