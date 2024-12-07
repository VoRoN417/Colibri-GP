using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using static System.Console;

public class DropBonus : MonoBehaviour //кидаем на врага из которого идут бонусы
{
    public bool IsDead = false;
    public int BonusMin = 0;
    public int BonusMax = 0;
    public int PowerUp1Min = 0;
    public int PowerUp1Max = 0;
    public int PowerUp2Min = 0;
    public int PowerUp2Max = 0;
    public List<GameObject> BonusPrefabs = new List<GameObject>(); //изначально три прифаба куда кидаем прифабы бонусов
    void Start()
    {
        
    }


    void Update()
    {
        if (IsDead == true)
        {
            if(BonusMax >= 0)
            {
                for (int i = 0; i < Random.Range(BonusMax, BonusMax); i++)
                {
                    Instantiate(BonusPrefabs[0]);
                    BonusPrefabs[0].transform.position = gameObject.transform.position;
                }
            }
            if(PowerUp1Max >= 0)
            {
                for (int i = 0; i < Random.Range(PowerUp1Min, PowerUp1Max); i++)
                {
                    Instantiate(BonusPrefabs[1]);
                    BonusPrefabs[1].transform.position = gameObject.transform.position;

                }
            }
            if (PowerUp2Max >= 0)
            {
                for (int i = 0; i < Random.Range(PowerUp2Min, PowerUp2Max); i++)
                {
                    Instantiate(BonusPrefabs[2]);
                    BonusPrefabs[2].transform.position = gameObject.transform.position;

                }
            }
            Destroy(gameObject);
        }
    }
}
