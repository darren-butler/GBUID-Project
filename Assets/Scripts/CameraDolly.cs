using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDolly : MonoBehaviour
{
    [SerializeField] private GameObject subject;

    private void FixedUpdate()
    {
        transform.position = new Vector3(subject.transform.position.x, transform.position.y, transform.position.z);
    }
}
