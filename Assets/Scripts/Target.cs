using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 100;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void TargetTakeDamage(float damage)
    {
        health -= damage;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Destroy(other.gameObject);
            health -= 5;
        }

        else if (other.gameObject.tag.Equals("Bullet"))
        {
            Destroy(other.gameObject);
            health -= 1;
        }

        
    }
}
