using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ����
    public Transform firePoint; // �����, �� ������� ������������ �������
    public float bulletSpeed = 10f; // �������� ����
    public float shootingCooldown = 0.5f; // ����� �������� ����� ����������

    private float lastShootTime = 0f; // ����� ���������� ��������

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > lastShootTime + shootingCooldown)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // �������� ����
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // ��������� ���������� Rigidbody2D � ��������� ��������
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.up * bulletSpeed; // ����������� ��������
        }

        lastShootTime = Time.time; // ���������� ������� ���������� ��������
    }
}