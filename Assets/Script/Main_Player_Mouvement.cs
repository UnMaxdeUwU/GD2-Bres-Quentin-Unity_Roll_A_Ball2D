using UnityEngine;

public class Main_Player_Mouvement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float Strength_ImpulseSpeed = 5f;
    private float Strenght_ImpulseCurrent = 0f;
    private float Strength_ImpuleMax = 20f;
    private Vector2 CheckPoint_Position;
    [SerializeField] private Grappin _grappin;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CheckPoint_Position = transform.position; //position du départ
    }

    // Update is called once per frame
    void Update()
    {   
        Vector2 Main_Position = transform.position;
        
        Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //position de ma souris
        Vector2 direction = MousePosition - Main_Position; 
        if (Input.GetMouseButton(0)) //clique gauche
        {  
            Strenght_ImpulseCurrent += Strength_ImpulseSpeed*Time.deltaTime; 
            Strenght_ImpulseCurrent = Mathf.Clamp(Strenght_ImpulseCurrent, 0f, Strength_ImpuleMax);
            
        }

        if (Input.GetMouseButtonUp(0)) //relache du clic gauche
        {   
            BallMouve(direction.normalized, Strenght_ImpulseCurrent);  //apelle fonction avec valeur du maintient du clique droit
            float reset = 0f;
            Strenght_ImpulseCurrent = reset;
        }
        
        
        
        
    }

    private void BallMouve(Vector2 direction, float current)
    {
        //rb.AddForce(transform.right * current);
        rb.AddForce(direction * current, ForceMode2D.Impulse); 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Spike>() != null)
        {
            ResetPosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CheckPoint>() != null)
        {
            NewCheckPoint();
        }

        if (other.gameObject.GetComponent<Void>() != null)
        {
            ResetPosition();
        }
    }
    private void ResetPosition()
    {
        rb.position = CheckPoint_Position;
        _grappin.IsGrappin = false;
        _grappin._dj.enabled = false;
        _grappin._lr.enabled = false;
    }

    private void NewCheckPoint()
    {
        CheckPoint_Position = transform.position;
    }
}
