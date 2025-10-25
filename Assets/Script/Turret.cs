using System;
using UnityEngine;

public class Turret : MonoBehaviour
{   
    private Rigidbody2D _rb;
    private bool playerEnter = false;
    private Vector2 _positionTurret;
    private Transform _positionPlayer;
    [SerializeField] private float RotationCorrection = 25f;
    [SerializeField] private Transform TurretSprite;
    [SerializeField] private Transform _SpawnPoint;
    [SerializeField] private Projectile _projectilePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

    }
    //&& = AND, || = OR

    // Update is called once per frame
    void Update()
    {
        if (playerEnter && TurretSprite != null)
        {   
            _positionTurret = transform.position;
            Vector2 target = _positionPlayer.position;  
            Vector2 direction = target - _positionTurret;
            float angle = Mathf.Atan2(direction.y , direction.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0, 0, angle + RotationCorrection);
            TurretSprite.transform.rotation = Quaternion.Euler(0, 0, angle + RotationCorrection);
            Debug.Log(angle);
            Instantiate(_projectilePrefab, _SpawnPoint.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Main_Player_Mouvement>() != null)
        {
            playerEnter = true;
            _positionPlayer = other.transform;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Main_Player_Mouvement>() != null)
        {   
            playerEnter = true;
            _positionPlayer = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerEnter = false;
    }
}
