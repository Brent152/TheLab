using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int BASE_HEALTH;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        BASE_HEALTH = 100;
        currentHealth = BASE_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
