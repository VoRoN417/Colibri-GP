using UnityEngine;

namespace Colibri_GP
{
    public class Enemy : MonoBehaviour
    {
        public enum WeaponType
        {
            Bat,       // Bat (melee)
            Pistol,    // Pistol (medium range)
            Shotgun    // Shotgun (medium range, large radius)
        }

        public WeaponType weaponType;   // The type of weapon the enemy has
        public float moveSpeed = 2f;

        private GameAgent playerAgent;
        private bool isChasing = false;  // Flag to indicate if the enemy is chasing the player
        private Weapon currentWeapon;

        // Distances for each weapon type
        public float batAttackRange = 1.0f;  // For bat (melee)
        public float pistolAttackRange = 5.0f;  // For pistol
        public float shotgunAttackRange = 3.0f;  // For shotgun

        // Weapon prefabs
        public Pistol pistol;
        public Shotgun shotgun;
        public GameObject bat;

        void Start()
        {
            // Find the player (GameAgent) object in the scene
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

            // Set the weapon based on the weapon type
            SetWeapon(weaponType);
        }

        void Update()
        {
            if (playerAgent != null && isChasing)
            {
                float distanceToPlayer = Vector2.Distance(transform.position, playerAgent.transform.position);

                // Check the distance and perform corresponding actions based on the weapon
                if (distanceToPlayer <= GetAttackRange() && currentWeapon.CanAttack())
                {
                    AttackPlayer();
                }
                else if (distanceToPlayer > GetAttackRange())
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

        // Method for selecting a weapon
        void SetWeapon(WeaponType type)
        {
            switch (type)
            {
                case WeaponType.Bat:
                    currentWeapon = bat.GetComponent<BatWeapon>();  // Assign bat weapon
                    break;
                case WeaponType.Pistol:
                    currentWeapon = pistol;
                    break;
                case WeaponType.Shotgun:
                    currentWeapon = shotgun;
                    break;
            }
        }

        // Method to get the attack range based on the weapon type
        float GetAttackRange()
        {
            switch (weaponType)
            {
                case WeaponType.Bat:
                    return batAttackRange;
                case WeaponType.Pistol:
                    return pistolAttackRange;
                case WeaponType.Shotgun:
                    return shotgunAttackRange;
                default:
                    return 0f;
            }
        }

        // Method to move towards the player
        void MoveTowardsPlayer()
        {
            Vector2 direction = (playerAgent.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, playerAgent.transform.position, moveSpeed * Time.deltaTime);

            // Rotate the enemy to face the player
            LookAtPlayer(direction);
        }

        // Method to rotate the enemy towards the player
        void LookAtPlayer(Vector2 direction)
        {
            if (direction != Vector2.zero)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }

        // Method to attack the player
        void AttackPlayer()
        {
            if (currentWeapon != null)
            {
                currentWeapon.Shoot(playerAgent.transform.position);
                currentWeapon.UpdateLastAttackTime();
            }
        }
    }
}





