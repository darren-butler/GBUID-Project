using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject backgroundImage;
    [SerializeField] private int imageCount;
    [SerializeField] private float offset;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = -2; i < imageCount; i++) 
        {
            Vector3 v = new Vector3(i * offset, transform.position.y, transform.position.x);
            GameObject gameObject = Instantiate(backgroundImage, v, Quaternion.identity);
            gameObject.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
