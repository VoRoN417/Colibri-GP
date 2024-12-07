using System.Collections;
using UnityEngine;

namespace Colibri_GP
{
    public class EnemyDetectionZone : MonoBehaviour
    {
        public float detectionRadius = 5f;  // Радиус зоны обнаружения
        public LayerMask playerLayer;  // Слой для игрока, чтобы фильтровать коллайдеры
        public float lostSightTime = 2f;  // Время до прекращения преследования, если игрок исчез из зоны

        private Enemy enemy;  // Ссылка на врага
        private GameAgent playerAgent;  // Ссылка на игрока
        private bool isPlayerInRange = false;  // Флаг для отслеживания состояния игрока в зоне

        void Start()
        {
            enemy = GetComponent<Enemy>();  // Получаем компонент врага
            if (enemy == null)
            {
                Debug.LogError("Enemy component not found!");
            }

            // Ищем игрока по фракции
            GameAgent[] agents = FindObjectsOfType<GameAgent>();
            foreach (GameAgent agent in agents)
            {
                if (agent.GameFaction == GameAgent.Faction.Player)
                {
                    playerAgent = agent;
                    break;
                }
            }

            if (playerAgent == null)
            {
                Debug.LogError("Player not found!");
            }
        }

        void Update()
        {
            if (playerAgent != null)
            {
                CheckPlayerDetection();
            }
        }

        void CheckPlayerDetection()
        {
            // Проверяем, есть ли игрок в радиусе обнаружения
            Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);

            if (playerCollider != null && !isPlayerInRange)
            {
                // Игрок вошел в зону обнаружения
                isPlayerInRange = true;
                StartCoroutine(HandlePlayerDetected());
            }
            else if (playerCollider == null && isPlayerInRange)
            {
                // Игрок вышел из зоны
                isPlayerInRange = false;
                StartCoroutine(LostPlayerSight());
            }
        }

        // Метод для обработки преследования игрока
        private IEnumerator HandlePlayerDetected()
        {
            while (isPlayerInRange)
            {
                if (playerAgent != null)
                {
                    // Преследование игрока
                    enemy.UpdateMovementAndAttack(playerAgent);
                }
                yield return null;
            }
        }

        // Если игрок ушел из зоны, останавливаем преследование
        private IEnumerator LostPlayerSight()
        {
            yield return new WaitForSeconds(lostSightTime);
            if (!isPlayerInRange)
            {
                // Если игрок так и не был снова обнаружен
                enemy.StopChasing();
            }
        }

        // Отображение зоны обнаружения для удобства в редакторе
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
}

