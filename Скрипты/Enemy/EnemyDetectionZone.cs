using System.Collections;
using UnityEngine;

namespace Colibri_GP
{
    public class EnemyDetectionZone : MonoBehaviour
    {
        public float detectionRadius = 5f;  // ������ ���� �����������
        public LayerMask playerLayer;  // ���� ��� ������, ����� ����������� ����������
        public float lostSightTime = 2f;  // ����� �� ����������� �������������, ���� ����� ����� �� ����

        private Enemy enemy;  // ������ �� �����
        private GameAgent playerAgent;  // ������ �� ������
        private bool isPlayerInRange = false;  // ���� ��� ������������ ��������� ������ � ����

        void Start()
        {
            enemy = GetComponent<Enemy>();  // �������� ��������� �����
            if (enemy == null)
            {
                Debug.LogError("Enemy component not found!");
            }

            // ���� ������ �� �������
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
            // ���������, ���� �� ����� � ������� �����������
            Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);

            if (playerCollider != null && !isPlayerInRange)
            {
                // ����� ����� � ���� �����������
                isPlayerInRange = true;
                StartCoroutine(HandlePlayerDetected());
            }
            else if (playerCollider == null && isPlayerInRange)
            {
                // ����� ����� �� ����
                isPlayerInRange = false;
                StartCoroutine(LostPlayerSight());
            }
        }

        // ����� ��� ��������� ������������� ������
        private IEnumerator HandlePlayerDetected()
        {
            while (isPlayerInRange)
            {
                if (playerAgent != null)
                {
                    // ������������� ������
                    enemy.UpdateMovementAndAttack(playerAgent);
                }
                yield return null;
            }
        }

        // ���� ����� ���� �� ����, ������������� �������������
        private IEnumerator LostPlayerSight()
        {
            yield return new WaitForSeconds(lostSightTime);
            if (!isPlayerInRange)
            {
                // ���� ����� ��� � �� ��� ����� ���������
                enemy.StopChasing();
            }
        }

        // ����������� ���� ����������� ��� �������� � ���������
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
}

