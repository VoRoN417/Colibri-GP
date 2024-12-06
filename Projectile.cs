using UnityEngine;

namespace Colibri_GP
{
    public class Projectile : MonoBehaviour
    {
        public float speed = 10f;
        public float lifetime = 2f;
        public float damage = 10f;

        private void Start()
        {
            // Уничтожение объекта по истечении заданного времени
            Destroy(gameObject, lifetime);
        }

        void Update()
        {
            // Перемещение снаряда вверх
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        // Метод для обработки столкновения с триггером
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Вывод сообщения в Debug Log о столкновении
            Debug.Log("Снаряд столкнулся с объектом: " + other.name);

            // Проверка, если объект, с которым столкнулись, имеет тег "Enemy"
            if (other.CompareTag("Enemy"))
            {
                Enemy enemy = other.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }

                // Уничтожение объекта при столкновении с врагом
                Destroy(gameObject);
            }
            else if (other.CompareTag("Obstacle"))
            {
                // Уничтожение объекта при столкновении с препятствием
                Destroy(gameObject);
            }
            // Вы можете добавить дополнительные проверки для других тегов по мере необходимости
        }
    }

}
