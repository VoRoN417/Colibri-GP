using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Colibri_GP
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public GameObject projectilePrefab;
        public Transform shootPoint;

        private void Update()
        {
            Move();

            RotateTowardsMouse();

            if (Input.GetMouseButtonDown(0)) 
            {
                Shoot();
            }
        }

        private void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 direction = new Vector2(horizontal, vertical).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }

        private void RotateTowardsMouse()
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
            transform.up = direction; 
        }

        private void Shoot()
        {
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
            projectile.GetComponent<Projectile>().Initialize(10f);
        }
    }
}

