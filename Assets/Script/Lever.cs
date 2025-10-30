using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Lever : MonoBehaviour
{   
    [SerializeField] AudioClip audioClip;
    private Collider2D _collider2D;
    [SerializeField] Tilemap _tilemap;
    [SerializeField] TilemapRenderer _tilemapRenderer;
    [SerializeField] TilemapCollider2D _tilemapCollider2D;
    [SerializeField] private GameObject _coin;


    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Main_Player_Mouvement>() != null)
        {
            GetComponent<Animator>().Play("AnimationLever");
            SoundFXManager.instance.PlaySoundFXClip(audioClip, transform, 1f);
            _collider2D.enabled = false;
            _tilemapRenderer.enabled = false;
            _tilemap.enabled = false;
            _tilemapCollider2D.enabled = false;
            _coin.SetActive(true);
            
        }
    }


}
