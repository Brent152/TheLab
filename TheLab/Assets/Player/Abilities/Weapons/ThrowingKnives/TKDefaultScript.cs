using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TKDefaultScript : MonoBehaviour
{
    public Rigidbody rb;
    public float MAX_LIFETIME_SECONDS;
    public int DAMAGE;
    public Vector3 KNOCKBACK;

    // Start is called before the first frame update
    void Start()
    {
        DAMAGE = 20;
        KNOCKBACK = new Vector3(0, 5f, 0);

        MAX_LIFETIME_SECONDS = 5.0f;
        rb = GetComponent<Rigidbody>();
        StartCoroutine("StartLifeTimer", MAX_LIFETIME_SECONDS);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health healthScript))
        {
            healthScript.TakeDamage(DAMAGE);
        }
        if (collision.gameObject.TryGetComponent<Knockback>(out Knockback knockbackScript))
        {
            knockbackScript.TakeKnockback(KNOCKBACK);
        }
        Destroy(gameObject);
    }

    IEnumerator StartLifeTimer()
    {
        yield return new WaitForSeconds(MAX_LIFETIME_SECONDS);
        Destroy(gameObject);
    }
}
