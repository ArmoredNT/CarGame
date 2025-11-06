using System;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    [SerializeField] private float spawnTime;
    float timeElapsed;
    [SerializeField] int pooledCount;

    public bool Active = true;
    
    SpriteRenderer sp;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Active && timeElapsed >= spawnTime)
        {
            Active = false;
            sp.enabled = false;
        }
        else
        {
            timeElapsed += Time.deltaTime;
            transform.position += new Vector3(0f, -3f * Time.deltaTime, 0f);
        }
    }

    public void Reset()
    {
        Active = true;
        timeElapsed = 0;
        sp.enabled = true;
        pooledCount++;
    }
}
