using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private int _score = 1;
    [SerializeField] private int _health = 5;
    
    private Transform _parent;
    private GameObject _explosion;
    private ScoreBoard _scoreBoard;
    private MeshRenderer _meshRenderer;
    private Color _defaultColor;

    private void Start()
    {
        _scoreBoard = FindObjectOfType<ScoreBoard>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _defaultColor = _meshRenderer.material.color;
        var rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        _parent = GameObject.Find("SPAWN").transform;
    }

    private void OnParticleCollision(GameObject other)
    {
        _health--;
        Debug.Log("Health " + gameObject.name + ": " + _health);
        _scoreBoard.IncreaseScore(_score);
        ChangeColor();
        if (_health <= 0)
        {
            Die();
        }
    }

    private void ChangeColor()
    {
        _meshRenderer.material.color = Color.red;
        Invoke("SetColorToDefault", 0.1f);
    }

    private void SetColorToDefault()
    {
        _meshRenderer.material.color = _defaultColor;
    }

    private void Die()
    {
        _explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        _explosion.transform.parent = _parent;
        Destroy(gameObject);
    }
}
