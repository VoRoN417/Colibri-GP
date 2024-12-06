using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Colibri_GP
{
    public class Weapon : MonoBehaviour
    {
        public float damageAmount = 10f;
        public float fireRate = 0.5f;
        private float nextFireTime = 0f; 

        public GameObject projectilePrefab;
        public Transform firePoint;

        void Update()
        {
            if (Time.time >= nextFireTime)
            {
                if (Input.GetButton("Fire1"))
                {
                    FireWeapon();
                    nextFireTime = Time.time + fireRate;
                }
            }
        }

        void FireWeapon()
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            Projectile projectileScript = projectile.GetComponent<Projectile>();
            if (projectileScript != null)
            {
                projectileScript.Initialize(damageAmount);
            }
        }
    }
}


