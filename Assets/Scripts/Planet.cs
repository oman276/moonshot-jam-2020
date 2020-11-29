using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float rotation = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
    }
}
