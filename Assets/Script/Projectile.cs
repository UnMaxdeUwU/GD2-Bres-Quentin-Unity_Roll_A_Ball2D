using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;

    public void Init(Vector2 direction)
    {
        _rb.linearVelocity = direction * _speed;
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Main_Player_Mouvement>() != null)

        {
            Destroy(gameObject);
        }
    }
}
