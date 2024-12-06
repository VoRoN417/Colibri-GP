using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Colibri_GP
{
    public class Enemy : MonoBehaviour
    {
        public float health = 50f;
        public float moveSpeed = 2f;
        public float attackRange = 1.5f; 
        public float attackCooldown = 1f; 
        public float damage = 10f; 
        private float lastAttackTime = 0f; 

        private Transform player;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
            if (player == null)
            {
                Debug.LogError("Player not found!");
            }
        }

        void Update()
        {
            if (player != null)
            {
                float distanceToPlayer = Vector2.Distance(transform.position, player.position);

                if (distanceToPlayer <= attackRange && Time.time > lastAttackTime + attackCooldown)
                {
                    AttackPlayer();
                }
                else if (distanceToPlayer > attackRange)
                {
                    MoveTowardsPlayer();
                }
            }
        }

        void MoveTowardsPlayer()
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }

        void AttackPlayer()
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            lastAttackTime = Time.time;
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            if (health <= 0f)
            {
                Die();
            }
        }

        void Die()
        {
            Destroy(gameObject);
        }
    }
}

