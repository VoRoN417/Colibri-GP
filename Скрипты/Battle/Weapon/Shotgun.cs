using UnityEngine;

public class Shotgun : Weapon
{
    public GameObject bulletPrefab;   // Префаб пули
    public Transform firePoint;       // Точка, из которой производится выстрел
    public float bulletSpeed = 5f;    // Скорость пули
    public int pellets = 5;           // Количество пуль, которые вылетают из дробовика
    public float shootingCooldown = 0.5f; // Время задержки между выстрелами

    private float lastShootTime = 0f; // Время последнего выстрела

    // Метод атаки
    public override void Shoot(Vector3 targetPosition)
    {
        if (CanAttack())
        {
            for (int i = 0; i < pellets; i++)
            {
                // Случайный угол для каждого выстрела (отклонение для имитации разброса)
                float angleOffset = Random.Range(-10f, 10f);
                // Создание пули с случайным углом отклонения
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, angleOffset));

                // Получаем компонент Rigidbody2D и устанавливаем скорость
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 direction = (targetPosition - firePoint.position).normalized;
                    rb.velocity = direction * bulletSpeed; // Направление стрельбы
                }
            }

            UpdateLastAttackTime();  // Обновляем время последнего выстрела
        }
    }

    // Проверка, можно ли атаковать
    public override bool CanAttack()
    {
        return Time.time > lastShootTime + shootingCooldown;
    }

    // Обновляем время последнего выстрела
    public override void UpdateLastAttackTime()
    {
        lastShootTime = Time.time;
    }
}

