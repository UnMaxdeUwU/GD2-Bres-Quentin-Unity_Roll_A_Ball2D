using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Collider2D col;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Main_Player_Mouvement>() != null)
        {
            col.enabled = false;
        }
    }
}
