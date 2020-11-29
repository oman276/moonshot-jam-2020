using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float maxThrust;
    public float maxTorque;
    private Rigidbody2D rb;

    public float screenLimit;
    public float screenLimitTop;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        rb.AddForce(thrust);
        rb.AddTorque(torque);
    }

    void Update()
    {
        if (transform.position.x > screenLimit || transform.position.x < -screenLimit)
        {
            Vector2 newPos = new Vector2(-transform.position.x, transform.position.y);
            transform.position = newPos;
        }
        if (transform.position.y > screenLimitTop || transform.position.y < -screenLimitTop)
        {
            Vector2 newPos = new Vector2(transform.position.x, -transform.position.y);
            transform.position = newPos;
        }
    }

}
