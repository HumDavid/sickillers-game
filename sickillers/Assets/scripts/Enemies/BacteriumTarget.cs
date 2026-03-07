using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriumTarget : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
        Debug.Log(health);
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
