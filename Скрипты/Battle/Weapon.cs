using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract void Shoot(Vector3 targetPosition);  // ����������� ����� ��� �����

    // ����� ��������, ����� �� ���������
    public abstract bool CanAttack();

    // ����� ��� ���������� ������� ��������� �����
    public abstract void UpdateLastAttackTime();
}

