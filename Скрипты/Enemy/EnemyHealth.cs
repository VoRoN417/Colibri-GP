using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Colibri_GP
{
    public class EnemyHealth : MonoBehaviour, IDamageable2D
    {
        public float health = 50f;

        public float Health => health; // Property for Health from the interface

        // Implementation of the ReceiveDamage method from IDamageable2D
        public void ReceiveDamage(float damageAmount, Vector2 hitPosition, GameAgent sender)
        {
            health -= damageAmount;
            if (health <= 0f)
            {
                Die();
            }
        }

        public void ReceiveHeal(float healAmount, Vector2 hitPosition, GameAgent sender)
        {
            health += healAmount;
            if (health > 50f) // Example limit on max health
            {
                health = 50f;
            }
        }

        void Die()
        {
            Debug.Log("Enemy died!");
            Destroy(gameObject);
        }
    }
}

