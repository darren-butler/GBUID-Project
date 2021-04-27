using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveDistance = 1f;
    [SerializeField] private float speed = 5f;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown(KeyCode.W))
        {
            target = new Vector2(transform.position.x, transform.position.y + moveDistance);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            target = new Vector2(transform.position.x, transform.position.y - moveDistance);
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
