using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Цель для следования (например, персонаж)
    public float smoothSpeed = 0.125f; // Скорость смягчения
    public Vector3 offset; // Смещение камеры относительно цели

    void LateUpdate()
    {
        if (target != null)
        {
            // Рассчитываем новую позицию камеры
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Если необходимо, можно также вращать камеру по целевой функции:
            // transform.LookAt(target);
        }
    }
}
