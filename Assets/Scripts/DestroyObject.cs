using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float _delayTime;
    [SerializeField] private bool _awake;

    private void Start()
    {
        if (_awake)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        Destroy(_target, _delayTime);
    }
}
