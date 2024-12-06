using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения персонажа

    void Update()
    {
        // Получаем позицию курсора на экране
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Убираем ось Z для 2D

        // Рассчитываем направление взгляда и поворачиваем персонажа
        Vector3 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Получаем ввод с клавиатуры
        float moveX = Input.GetAxis("Horizontal"); // A и D
        float moveY = Input.GetAxis("Vertical"); // W и S

        // Создаем вектор движения
        Vector3 movement = new Vector3(moveX, moveY, 0).normalized * moveSpeed * Time.deltaTime;

        // Перемещаем персонажа
        transform.position += movement;
    }
}