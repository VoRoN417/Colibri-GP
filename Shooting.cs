using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб пули
    public Transform firePoint; // Точка, из которой производится выстрел
    public float bulletSpeed = 10f; // Скорость пули
    public float shootingCooldown = 0.5f; // Время задержки между выстрелами

    private float lastShootTime = 0f; // Время последнего выстрела

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > lastShootTime + shootingCooldown)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Создание пули
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        // Получение компонента Rigidbody2D и установка скорости
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.up * bulletSpeed; // Направление стрельбы
        }

        lastShootTime = Time.time; // Обновление времени последнего выстрела
    }
}