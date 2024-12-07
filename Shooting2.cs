using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб пули
    public Transform firePoint; // Точка, из которой будет выстрел
    public float bulletSpeed = 10f; // Скорость пули
    public float shootingCooldown = 0.5f; // Время между выстрелами

    private float lastShootTime = 0f; // Время последнего выстрела
    private AudioSource audioSource; // Компонент AudioSource для воспроизведения звука

    void Start()
    {
        // Получаем компонент AudioSource на старте
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > lastShootTime + shootingCooldown)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Создаем пушку
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Получаем Rigidbody2D на объекте пули
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.up * bulletSpeed; // Задаем скорость пули
        }

        // Воспроизводим звук выстрела
        if (audioSource != null)
        {
            audioSource.Play(); // Проигрываем звук
        }

        lastShootTime = Time.time; // Обновляем время последнего выстрела
    }
}