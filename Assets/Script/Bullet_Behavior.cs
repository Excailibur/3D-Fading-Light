using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behavior : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f; // Bullet speed
    [SerializeField] private float lifetime = 10.0f; // Bullet life time duration

    private void Awake()
    {
        Destroy(gameObject,lifetime);
    }
    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Handle collision logic here, e.g., destroy the bullet on impact
        Destroy(gameObject);
    }

    public float getSpeed()
    {
        return speed;
    }
}
