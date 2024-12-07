using UnityEngine;

public class Pistol : Weapon
{
    public GameObject bulletPrefab;  // ������ ����
    public Transform firePoint;      // �����, �� ������� ������������ �������
    public float bulletSpeed = 10f;  // �������� ����
    public float shootingCooldown = 0.5f; // ����� �������� ����� ����������

    private float lastShootTime = 0f; // ����� ���������� ��������

    // ����� �����
    public override void Shoot(Vector3 targetPosition)
    {
        if (CanAttack())
        {
            // �������� ����
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // �������� ��������� Rigidbody2D � ������������� ��������
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = (targetPosition - firePoint.position).normalized;
                rb.velocity = direction * bulletSpeed;  // ����������� ��������
            }

            UpdateLastAttackTime();  // ��������� ����� ���������� ��������
        }
    }

    // ��������, ����� �� ���������
    public override bool CanAttack()
    {
        return Time.time > lastShootTime + shootingCooldown;
    }

    // ��������� ����� ���������� ��������
    public override void UpdateLastAttackTime()
    {
        lastShootTime = Time.time;
    }
}

