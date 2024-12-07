using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Colibri_GP
{
    public class BatWeapon : Weapon
    {
        public float attackRange = 1.5f;  // Дистанция атаки (дальность удара)
        public float damage = 10f;        // Урон, наносимый при ударе
        public float attackCooldown = 1f; // Задержка между ударами в секундах

        private float lastAttackTime = 0f; // Время последнего удара

        private void Start()
        {
            // Инициализация (если необходимо)
        }

        // Метод атаки
        public override void Shoot(Vector3 targetPosition)
        {
            if (CanAttack())
            {
                // Для биты атака происходит при столкновении с врагом в радиусе
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange);

                foreach (var hit in hitEnemies)
                {
                    IDamageable2D damageable = hit.GetComponent<IDamageable2D>();
                    if (damageable != null)
                    {
                        damageable.ReceiveDamage(damage, transform.position, gameObject.AddComponent<GameAgent>());
                    }
                }

                UpdateLastAttackTime();  // Обновляем время последней атаки
            }
        }

        // Проверка, можно ли атаковать
        public override bool CanAttack()
        {
            return Time.time > lastAttackTime + attackCooldown;
        }

        // Обновляем время последней атаки
        public override void UpdateLastAttackTime()
        {
            lastAttackTime = Time.time;
        }

        // Визуализация радиуса удара для отладки
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    }
}


