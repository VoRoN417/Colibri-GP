using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Colibri_GP
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public GameObject projectilePrefab;
        public Transform shootPoint;

        private void Update()
        {
            Move();

            RotateTowardsMouse();

            if (Input.GetMouseButtonDown(0)) 
            {
                Shoot();
            }
        }

        private void Move()
        {
            // Получаем ввод игрока по горизонтали и вертикали (WASD или стрелки)
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // Создаем вектор направления на основе ввода игрока
            Vector3 direction = new Vector3(horizontal, vertical, 0).normalized;

            // Двигаем персонажа по координатам сцены
            transform.position += direction * moveSpeed * Time.deltaTime;
        }

        private void RotateTowardsMouse()
        {
            // Получение позиции мыши в мировых координатах
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Определяем направление от персонажа до мыши
            Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
            // Поворачиваем персонажа в сторону мыши
            transform.up = direction; 
        }

        private void Shoot()
        {
            // Спавним снаряд из префаба в точке стрельбы
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
            // Инициализируем снаряд
            projectile.GetComponent<Projectile>().Initialize(10f);
        }
    }
}