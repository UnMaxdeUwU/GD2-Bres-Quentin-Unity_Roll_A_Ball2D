using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private Transform BulletSprite;

    public void Init(Vector2 direction, Quaternion rot)
    {   
        Vector2 NormalizeDirection = direction.normalized;
        _rb.linearVelocity = NormalizeDirection * _speed;
        BulletSprite.transform.rotation = rot;
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Main_Player_Mouvement>() != null)

        {
            Destroy(gameObject);
        }
    }
}
