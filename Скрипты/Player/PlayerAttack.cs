using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Colibri_GP
{
    public class Player : MonoBehaviour
    {
        public enum WeaponType
        {
            Bat,       // Бита (ближний бой)
            Pistol,    // Пистолет (средняя дистанция)
            Shotgun    // Дробовик (средняя дистанция, с большим радиусом)
        }

        public WeaponType weaponType;   // Тип оружия, который у игрока

        private Weapon currentWeapon;

        // Префабы оружия
        public GameObject bat;          // Префаб для биты
        public Pistol pistol;           // Префаб для пистолета
        public Shotgun shotgun;         // Префаб для дробовика

        void Start()
        {
            // Инициализация оружия
            SetWeapon(weaponType);
        }

        void Update()
        {
            // Обработка атак
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
            }

            // Переключение оружия с помощью клавиш 1, 2, 3
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

        // Метод для выбора оружия
        void SetWeapon(WeaponType type)
        {
            switch (type)
            {
                case WeaponType.Bat:
                    currentWeapon = bat.GetComponent<BatWeapon>();  // Присваиваем оружие из префаба
                    break;
                case WeaponType.Pistol:
                    currentWeapon = pistol;  // Присваиваем пистолет
                    break;
                case WeaponType.Shotgun:
                    currentWeapon = shotgun;  // Присваиваем дробовик
                    break;
            }
        }

        // Метод атаки
        void Attack()
        {
            if (currentWeapon != null)
            {
                Vector3 targetPosition = transform.position + transform.right * 10f; // Направление атаки
                currentWeapon.Shoot(targetPosition);  // Вызываем метод Shoot у текущего оружия
            }
        }

        // Метод для смены оружия
        public void ChangeWeapon(WeaponType newWeaponType)
        {
            weaponType = newWeaponType;
            SetWeapon(weaponType);  // Обновляем текущее оружие в соответствии с выбранным
        }
    }
}


