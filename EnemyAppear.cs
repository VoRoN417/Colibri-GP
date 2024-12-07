using Colibri_GP;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAppear : MonoBehaviour
{
    public GameObject EnemyPrefab; //кидаем прифаб врага
    public bool IsActive = false;
    void Start()
    {
        
    }

    void Update()
    {

        if (IsActive == true)
        {
            Instantiate(EnemyPrefab); //создаём врага
            EnemyPrefab.transform.position = gameObject.transform.position; //позицию в точке спауна
            Destroy(gameObject); //уничтожаем точку спауна
        }

    }

    public void TurnToTrue() 
    {
        IsActive = true;
    }
}
