using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCarSpawner : MonoBehaviour
{
    private List<EnemyCar> car = new List<EnemyCar>();
    [SerializeField] private GameObject carPrefab;
    
    [SerializeField] private Vector3 spawnPoint;
    [SerializeField] private float spawnRange;
    [SerializeField] private float spawnTime;
    float timeElapsed;

    private bool yeDirtyFlag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeElapsed >= spawnTime)
        {
            timeElapsed = 0;

            int carIndex = ContainsInactiveCar();
            if (carIndex != -1 )
            {
                //create car
                car[carIndex].gameObject.transform.position = spawnPoint + new Vector3(Random.Range(-spawnRange, spawnRange), 0f, 0f);
                car[carIndex].Reset();
            }
            else
            {
                car.Add(Instantiate(carPrefab, spawnPoint + new Vector3(Random.Range(-spawnRange, spawnRange), 0f, 0f), Quaternion.identity).GetComponent<EnemyCar>());
            }
        }
        timeElapsed += Time.deltaTime;
    }

    int ContainsInactiveCar()
    {
        for (int i = 0; i < car.Count; i++)
        {
            if (car[i].Active == false) return i;
        }

        return -1;
    }
}
