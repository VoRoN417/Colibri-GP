using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Colibri_GP
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 10f; // �������� ����
        public float lifetime = 2f; // ����� ����� ����
        public float damage = 10f; // ����, ������� ������� ����

        private void Start()
        {
            // ���������� ���� ����� ������������� ������� �����
            Destroy(gameObject, lifetime);
        }

        void Update()
        {
            // ������� ���� �� ����������� ����� (��� �� ����������� ��������, ���� ��� �����)
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            // ���������, ���� ������, � ������� ����������� ����, ��������� ��������� IDamageable2D
            IDamageable2D damageable = collision.gameObject.GetComponent<IDamageable2D>();
            if (damageable != null)
            {
                // ���������� ���� �� ������ � ����������� IDamageable2D
                damageable.ReceiveDamage(damage, transform.position, gameObject.AddComponent<GameAgent>());
            }

            // ���������� ���� ����� ������������
            Destroy(gameObject);
        }
    }
}




