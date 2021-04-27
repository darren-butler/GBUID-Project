using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gem;
    [SerializeField] private int gemCount = 50;
    private float gridOffset = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnGems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnGems()
    {
        for(int i = 0; i < gemCount; i++)
        {
            GameObject gameObject = Instantiate(gem, new Vector3(Random.Range(-7, 90)+ gridOffset, Random.Range(-3, 2) + gridOffset, 0), Quaternion.identity);
            gameObject.transform.parent = transform;

        }
    }
}
