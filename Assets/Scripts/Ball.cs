using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float _speed = 20f;
    Rigidbody _rigidBody;
    Vector3 _velocity;
    Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _rigidBody = GetComponent<Rigidbody>();

        Invoke("Launch", .5f);
    }

    void Launch()
    {
        _rigidBody.velocity = Vector3.up * _speed;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = _rigidBody.velocity.normalized * _speed;
        _velocity = _rigidBody.velocity;

        if (!_renderer.isVisible)
        {
            GameManager.Instance.Balls--;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _rigidBody.velocity = Vector3.Reflect(_velocity, collision.contacts[0].normal);
    }
}
