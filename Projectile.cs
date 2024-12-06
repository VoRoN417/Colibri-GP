using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Colibri_GP
{
    public class Projectile : MonoBehaviour
    {
        public float speed = 10f;
        public float lifetime = 3f;

        private float damageAmount;

        private void Start()
        {
            Destroy(gameObject, lifetime);
        }

        public void Initialize(float damage)
        {
            damageAmount = damage;
        }

        private void Update()
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            IDamageable2D damageable = other.GetComponent<IDamageable2D>();
            if (damageable != null)
            {
                if (damageAmount > 0f)
                {
                    damageable.ReceiveDamage(damageAmount, transform.position, null);
                }

                Destroy(gameObject);
            }
        }
    }
}


