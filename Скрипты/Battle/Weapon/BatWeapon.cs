using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Colibri_GP
{
    public class BatWeapon : Weapon
    {
        public float attackRange = 1.5f;  // ��������� ����� (��������� �����)
        public float damage = 10f;        // ����, ��������� ��� �����
        public float attackCooldown = 1f; // �������� ����� ������� � ��������

        private float lastAttackTime = 0f; // ����� ���������� �����

        private void Start()
        {
            // ������������� (���� ����������)
        }

        // ����� �����
        public override void Shoot(Vector3 targetPosition)
        {
            if (CanAttack())
            {
                // ��� ���� ����� ���������� ��� ������������ � ������ � �������
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange);

                foreach (var hit in hitEnemies)
                {
                    IDamageable2D damageable = hit.GetComponent<IDamageable2D>();
                    if (damageable != null)
                    {
                        damageable.ReceiveDamage(damage, transform.position, gameObject.AddComponent<GameAgent>());
                    }
                }

                UpdateLastAttackTime();  // ��������� ����� ��������� �����
            }
        }

        // ��������, ����� �� ���������
        public override bool CanAttack()
        {
            return Time.time > lastAttackTime + attackCooldown;
        }

        // ��������� ����� ��������� �����
        public override void UpdateLastAttackTime()
        {
            lastAttackTime = Time.time;
        }

        // ������������ ������� ����� ��� �������
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    }
}


