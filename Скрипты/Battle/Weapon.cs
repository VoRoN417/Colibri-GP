using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract void Shoot(Vector3 targetPosition);  // Абстрактный метод для атаки

    // Метод проверки, можно ли атаковать
    public abstract bool CanAttack();

    // Метод для обновления времени последней атаки
    public abstract void UpdateLastAttackTime();
}

