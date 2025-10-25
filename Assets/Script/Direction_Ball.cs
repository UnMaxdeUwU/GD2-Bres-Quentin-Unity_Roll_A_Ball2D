using System;
using UnityEngine;

public class Direction_Ball : MonoBehaviour
{   
    
    void Update()
    {
        Vector2 Ball_direction = transform.position;
        Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = MousePosition - Ball_direction;
        transform.right = direction;
    }
}
