using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private int _score = 1;

    private GameObject _explosion;

    private ScoreBoard _scoreBoard;

    private void Start()
    {
        _scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        _explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        _explosion.transform.parent = _parent;
        _scoreBoard.IncreaseScore(_score);
        Destroy(gameObject);
    }
}
