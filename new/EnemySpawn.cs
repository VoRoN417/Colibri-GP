using Colibri_GP;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public bool ActivePointEnemy = false;
    [SerializeField] private List<GameObject> EnemyPrefabs = new List<GameObject>();



    void Start()
    {

    }

    void Update()
    {
        if (ActivePointEnemy == true)
        {
            for (int i = 0; i < EnemyPrefabs.Count; i++)
            {
                EnemyAppear en = EnemyPrefabs[i].GetComponent<EnemyAppear>();
                en.TurnToTrue();
            }
            Destroy(gameObject);
        }
    }

    public void Destroy()
    {
        ActivePointEnemy = true;
    }
}
    
