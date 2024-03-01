using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonKey : MonoBehaviour
{
    [SerializeField] GameObject key;
    [SerializeField] GameObject keySpawnPoint;
    public  void spawnKey()
    {
        Instantiate(key,keySpawnPoint.transform,keySpawnPoint.transform);
    }
}
