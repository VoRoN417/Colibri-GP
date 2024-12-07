using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Colibri_GP
{
    public class Player : MonoBehaviour
    {
        public enum WeaponType
        {
            Bat,       // ���� (������� ���)
            Pistol,    // �������� (������� ���������)
            Shotgun    // �������� (������� ���������, � ������� ��������)
        }

        public WeaponType weaponType;   // ��� ������, ������� � ������

        private Weapon currentWeapon;

        // ������� ������
        public GameObject bat;          // ������ ��� ����
        public Pistol pistol;           // ������ ��� ���������
        public Shotgun shotgun;         // ������ ��� ���������

        void Start()
        {
            // ������������� ������
            SetWeapon(weaponType);
        }

        void Update()
        {
            // ��������� ����
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
            }

            // ������������ ������ � ������� ������ 1, 2, 3
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeWeapon(WeaponType.Bat);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChangeWeapon(WeaponType.Pistol);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ChangeWeapon(WeaponType.Shotgun);
            }
        }

        // ����� ��� ������ ������
        void SetWeapon(WeaponType type)
        {
            switch (type)
            {
                case WeaponType.Bat:
                    currentWeapon = bat.GetComponent<BatWeapon>();  // ����������� ������ �� �������
                    break;
                case WeaponType.Pistol:
                    currentWeapon = pistol;  // ����������� ��������
                    break;
                case WeaponType.Shotgun:
                    currentWeapon = shotgun;  // ����������� ��������
                    break;
            }
        }

        // ����� �����
        void Attack()
        {
            if (currentWeapon != null)
            {
                Vector3 targetPosition = transform.position + transform.right * 10f; // ����������� �����
                currentWeapon.Shoot(targetPosition);  // �������� ����� Shoot � �������� ������
            }
        }

        // ����� ��� ����� ������
        public void ChangeWeapon(WeaponType newWeaponType)
        {
            weaponType = newWeaponType;
            SetWeapon(weaponType);  // ��������� ������� ������ � ������������ � ���������
        }
    }
}


