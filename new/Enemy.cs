using UnityEngine;

namespace Colibri_GP
{
    public class Enemy : MonoBehaviour, IDamageable2D
    {
        public float health = 50f;
        public float moveSpeed = 2f;
        public float attackRange = 1.5f;
        public float attackCooldown = 1f;
        public float damage = 10f;
        private float lastAttackTime = 0f;

        private GameAgent playerAgent;
        private bool isChasing = false;  // ����, ������� ���������, ��� ���� ���������� ������

        public float Health => health;

        void Start()
        {
            // ���� ������ � ����������� GameAgent ��� ������
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
            if (playerAgent != null && isChasing)
            {
                float distanceToPlayer = Vector2.Distance(transform.position, playerAgent.transform.position);

                if (distanceToPlayer <= attackRange && Time.time > lastAttackTime + attackCooldown)
                {
                    AttackPlayer();
                }
                else if (distanceToPlayer > attackRange)
                {
                    MoveTowardsPlayer();
                }
            }
        }

        public void UpdateMovementAndAttack(GameAgent player)
        {
            playerAgent = player;
            isChasing = true;
        }

        public void StopChasing()
        {
            isChasing = false;
        }

        // ����� ��� �������� � ������
        void MoveTowardsPlayer()
        {
            Vector2 direction = (playerAgent.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, playerAgent.transform.position, moveSpeed * Time.deltaTime);

            // ������� ����� � ������� ������
            LookAtPlayer(direction);
        }

        // ����� ��� �������� ����� � ������� ������
        void LookAtPlayer(Vector2 direction)
        {
            // ������������ ����� � ������� ������
            if (direction != Vector2.zero)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }

        // ����� ����� ������
        void AttackPlayer()
        {
            IDamageable2D damageable = playerAgent.GetComponent<IDamageable2D>();
            if (damageable != null)
            {
                damageable.ReceiveDamage(damage, transform.position, gameObject.AddComponent<GameAgent>());
            }

            lastAttackTime = Time.time;
        }

        // ����� ��������� �����
        public void ReceiveDamage(float damageAmount, Vector2 hitPosition, GameAgent sender)
        {
            health -= damageAmount;
            if (health <= 0f)
            {
                Die();
            }
        }

        // ����� ������������� ��������
        public void ReceiveHeal(float healAmount, Vector2 hitPosition, GameAgent sender)
        {
            health += healAmount;
            if (health > 50f)
            {
                health = 50f;
            }
        }

        // ����� ������
        void Die()
        {
            Destroy(gameObject);
        }
    }
}





