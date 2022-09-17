using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // [SerializeField] private InputAction movement; // New Input System
    [Header("General")]
    [Tooltip("Подсказка")][SerializeField] private float _speed = 10f;
    [SerializeField] private float _speedRotation = 10f;
    [SerializeField] private GameObject[] _lasers;
    [SerializeField] private GameObject _vfxExplosive;

    private float xRange = 8;
    private float yRange = 5;
    
    private float xAngle = -20;
    private float yAngle = -20;
    private float zAngle = -20;

    private float positionPitchFactor = -2f;
    private float controlPitchFactor = -15f;
    private float positionYawFactor = 2f;
    private float controlRollFactor = -20f;
    
    private float _hInput;
    private float _vInput;
    private Vector3 _direction;

    public bool isDead;
    

    // Start is called before the first frame update
    void Start()
    {
        LaserSetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if (isDead) return;
        
        _hInput = Input.GetAxis("Horizontal");
        _vInput = Input.GetAxis("Vertical");
        _direction = new Vector3(_hInput, _vInput, 0);
        
        MovePlayerOldInput();
        Rotation();
        Shooting();
        // MovePlayerNewInput();
    }

    private void Shooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            LaserSetActive(true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            LaserSetActive(false);
        }
    }

    private void LaserSetActive(bool active)
    {
        foreach (var laser in _lasers)
        {
            var particleEmission = laser.GetComponent<ParticleSystem>().emission;
            particleEmission.enabled = active;
        }
    }

    private void Rotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + _vInput * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = _hInput * controlRollFactor;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

        // Vector3 rotation = new Vector3(xAngle * _vInput, yAngle * _hInput, zAngle * _hInput);
        // transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotation), Time.deltaTime * _speedRotation);
        // transform.localRotation = Quaternion.Euler(rotation);
    }

    private void MovePlayerOldInput()
    {
        Vector3 position = transform.localPosition + _speed * Time.deltaTime * _direction;
        float x = Mathf.Clamp(position.x, -xRange, xRange);
        float y = Mathf.Clamp(position.y, -yRange, yRange);

        transform.localPosition = new Vector3(x, y, position.z);
    }
    
    private void MovePlayerNewInput()
    {
        // Vector3 direction = movement.ReadValue<Vector2>();
        //
        // Debug.Log(direction);
        //
        // Vector3 position = transform.localPosition + _speed * Time.deltaTime * direction;
        // float x = Mathf.Clamp(position.x, -xRange, xRange);
        // float y = Mathf.Clamp(position.y, -yRange, yRange);
        //
        // transform.localPosition = new Vector3(x, y, position.z);
    }
    
    private void OnEnable()
    {
        // movement.Enable(); // New Input System
    }

    private void OnDisable()
    {
        // movement.Disable(); // New Input System
    }

    public void Die(Vector3 pointCollision = new Vector3())
    {
        // isDead = true;
        this.enabled = false;
        GetComponent<Collider>().enabled = false;
        var rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
        _vfxExplosive.transform.localPosition = pointCollision;
        _vfxExplosive.SetActive(true);
        Invoke("ReloadLevel", 1f);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
