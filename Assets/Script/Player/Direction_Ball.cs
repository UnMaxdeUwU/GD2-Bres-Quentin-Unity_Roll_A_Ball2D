using System;
using UnityEngine;

public class Direction_Ball : MonoBehaviour
{   
    [SerializeField] private SpriteRenderer Graphic_direction;
    [SerializeField] private SpriteRenderer Graphic_direction2;
    [SerializeField] private SpriteRenderer Graphic_direction3;


    void Update()
    {
        Vector2 Ball_direction = transform.position;
        Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = MousePosition - Ball_direction;
        transform.right = direction;
    }
    public void ChangeColor(Color color)
    {
        Graphic_direction.color = color;
        Graphic_direction2.color = color;
        Graphic_direction3.color = color;
    }
}
