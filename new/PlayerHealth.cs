using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Colibri_GP
{
    public class PlayerHealth : MonoBehaviour, IDamageable2D
    {
        public float health = 100f;

        public float Health => health; // Свойство для Health из интерфейса

        // Реализация метода ReceiveDamage для интерфейса IDamageable2D
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
            if (health > 100f) // Пример ограничения на максимум здоровья
            {
                health = 100f;
            }
        }

        void Die()
        {
            Debug.Log("Player died!");
            Destroy(gameObject);
        }
    }
}


