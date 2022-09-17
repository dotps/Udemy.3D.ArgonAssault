using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private PlayerController _player;

    private void Start()
    {
        _player = GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 pointCollision = collision.GetContact(0).point;
        Vector3 localPointCollision = transform.InverseTransformPoint(pointCollision);
        _player.Die(localPointCollision);
    }

    private void OnTriggerEnter(Collider other)
    {
        _player.Die(); 
    }
}
