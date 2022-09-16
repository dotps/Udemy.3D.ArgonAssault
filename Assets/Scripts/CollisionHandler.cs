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
        Debug.Log("OnCollisionEnter " + collision.gameObject.name);
        _player.Die();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter " + other.gameObject.name);
        _player.Die();
    }
}
