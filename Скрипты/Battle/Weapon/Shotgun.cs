using UnityEngine;

public class Shotgun : Weapon
{
    public GameObject bulletPrefab;   // ������ ����
    public Transform firePoint;       // �����, �� ������� ������������ �������
    public float bulletSpeed = 5f;    // �������� ����
    public int pellets = 5;           // ���������� ����, ������� �������� �� ���������
    public float shootingCooldown = 0.5f; // ����� �������� ����� ����������

    private float lastShootTime = 0f; // ����� ���������� ��������

    // ����� �����
    public override void Shoot(Vector3 targetPosition)
    {
        if (CanAttack())
        {
            for (int i = 0; i < pellets; i++)
            {
                // ��������� ���� ��� ������� �������� (���������� ��� �������� ��������)
                float angleOffset = Random.Range(-10f, 10f);
                // �������� ���� � ��������� ����� ����������
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, angleOffset));

                // �������� ��������� Rigidbody2D � ������������� ��������
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 direction = (targetPosition - firePoint.position).normalized;
                    rb.velocity = direction * bulletSpeed; // ����������� ��������
                }
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

