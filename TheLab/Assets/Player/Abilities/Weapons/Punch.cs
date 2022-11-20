using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public int DAMAGE;
    public float KNOCKBACK_MULTIPLIER;
    public float PUNCH_REACH;

    public float COOLDOWN_SECONDS;
    public bool isPunching;


    PlayerMovement movementScript;


    // Start is called before the first frame update
    void Start()
    {
        PUNCH_REACH = 2f;
        DAMAGE = 15;
        KNOCKBACK_MULTIPLIER = 6f;
        COOLDOWN_SECONDS = .75f;
        movementScript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(PlayerKeybinds.melee) && !isPunching)
        {
            StartCoroutine("DoPunch");
        }
    }

    IEnumerator DoPunch()
    {
        isPunching = true;
        if (Physics.Raycast(movementScript.transform.position, transform.forward, out RaycastHit hit, PUNCH_REACH))
        {
            if (hit.collider.gameObject.TryGetComponent<Health>(out Health healthScript))
            {
                healthScript.TakeDamage(DAMAGE);
            }
            if (hit.collider.gameObject.TryGetComponent<Knockback>(out Knockback knockbackScript))
            {
                knockbackScript.TakeKnockback(KNOCKBACK_MULTIPLIER * (hit.collider.gameObject.transform.position - transform.position).normalized);
            }
        }
        yield return new WaitForSeconds(COOLDOWN_SECONDS);
        isPunching = false;
    }


}
