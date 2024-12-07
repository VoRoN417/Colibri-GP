using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Colibri_GP
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 10f; // Скорость пули
        public float lifetime = 2f; // Время жизни пули
        public float damage = 10f; // Урон, который наносит пуля

        private void Start()
        {
            // Уничтожаем пулю после определенного времени жизни
            Destroy(gameObject, lifetime);
        }

        void Update()
        {
            // Двигаем пулю по направлению вверх (или по направлению движения, если это нужно)
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            // Проверяем, если объект, с которым столкнулась пуля, реализует интерфейс IDamageable2D
            IDamageable2D damageable = collision.gameObject.GetComponent<IDamageable2D>();
            if (damageable != null)
            {
                // Отправляем урон на объект с интерфейсом IDamageable2D
                damageable.ReceiveDamage(damage, transform.position, gameObject.AddComponent<GameAgent>());
            }

            // Уничтожаем пулю после столкновения
            Destroy(gameObject);
        }
    }
}




