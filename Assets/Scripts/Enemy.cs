using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    public float enemyHealth;
    public GameObject target;
    public float damageAmount = 10f;
    public BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Awake()
    {
        enemyHealth = 25;
        target = GameObject.FindWithTag("Target");
        boxCollider = target.GetComponent<BoxCollider2D>();
        rb = this.GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
        if (boxCollider.bounds.Contains(transform.position))
        {
            target.GetComponent<Target>().TargetTakeDamage(1);
        }

        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;


        

    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }


    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Target"))
        {
            Destroy(this.gameObject);
        }

        


    }
}