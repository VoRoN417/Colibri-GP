using Colibri_GP;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAppear : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public bool IsActive = false;
    void Start()
    {
        
    }

    void Update()
    {

        if (IsActive == true)
        {
            Instantiate(EnemyPrefab);
            EnemyPrefab.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }

    }

    public void TurnToTrue()
    {
        IsActive = true;
    }
}
