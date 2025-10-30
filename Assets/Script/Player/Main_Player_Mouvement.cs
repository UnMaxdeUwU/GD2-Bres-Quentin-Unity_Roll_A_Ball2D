using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Main_Player_Mouvement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float Strength_ImpulseSpeed = 5f;
    private float Strenght_ImpulseCurrent = 0f;
    private float Strength_ImpuleMax = 15f;
    private Vector2 CheckPoint_Position;
    [SerializeField] private Grappin _grappin;
    
    [SerializeField] private GameObject _arrow;
    [SerializeField] private Color activeColor = Color.red;
    [SerializeField] private Color inactiveColor = Color.black;
    [SerializeField] private float arrow_value1 = 5f;
    [SerializeField] private float arrow_value2 = 10f;
    [SerializeField] private float arrow_value3 = 15f;
    [SerializeField] private SpriteRenderer arrow1;
    [SerializeField] private SpriteRenderer arrow2;
    [SerializeField] private SpriteRenderer arrow3;

    [SerializeField] private AudioClip[] audioClips;
    private bool[] soundPlayed = new bool[3];
    
    [SerializeField] private Main_Score _scoreData;
    [SerializeField] private NewMonoBehaviourScript _uiController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CheckPoint_Position = transform.position;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;//position du départ
        ResetArrows(inactiveColor);
        

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
            ChangeColor();
            Strenght_ImpulseCurrent = Mathf.Clamp(Strenght_ImpulseCurrent, 0f, Strength_ImpuleMax);

        }
        

        if (Input.GetMouseButtonUp(0)) //relache du clic gauche
        {   
            BallMouve(direction.normalized, Strenght_ImpulseCurrent);  //apelle fonction avec valeur du maintient du clique droit
            float reset = 0f;
            Strenght_ImpulseCurrent = reset;
            ResetArrows(inactiveColor);
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
            SoundFXManager.instance.PlaySoundFXClipArray(audioClips, transform, 100f, 3);
            ResetPosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CheckPoint>() != null)
        {
            NewCheckPoint();
            UpdateScore(1);
        }

        if (other.gameObject.GetComponent<Coins>() != null)
        {
            UpdateScore(5);
            Destroy(other.gameObject);
        }

        if (other.gameObject.GetComponent<Void>() != null)
        {   
            SoundFXManager.instance.PlaySoundFXClipArray(audioClips, transform, 100f, 5);
            ResetPosition();
        }
    }
    private void ResetPosition()
    {
        rb.position = CheckPoint_Position;
        rb.linearVelocity = Vector2.zero;
        _grappin.IsGrappin = false;
        _grappin._dj.enabled = false;
        _grappin._lr.enabled = false;
        
    }

    private void NewCheckPoint()
    {
        CheckPoint_Position = transform.position;
        SoundFXManager.instance.PlaySoundFXClipArray(audioClips, transform, 1f, 4);
    }

    private void ChangeColor()
    {   
        Debug.Log(Strenght_ImpulseCurrent);
        if (Strenght_ImpulseCurrent >= arrow_value1)
        {
            arrow1.color = activeColor;
            //Debug.Log("arrow1 red");
            if (!soundPlayed[0]) //si le son n'est pas encore joué alors
            {
                SoundFXManager.instance.PlaySoundFXClipArray(audioClips, transform, 1f, 2);
                soundPlayed[0] = true;
            }

        }

        if (Strenght_ImpulseCurrent >= arrow_value2)
        {
            arrow2.color = activeColor;
            if (!soundPlayed[1])
            {
                SoundFXManager.instance.PlaySoundFXClipArray(audioClips, transform, 1f, 1);
                soundPlayed[1] = true;
            }

        }
        if (Strenght_ImpulseCurrent >= arrow_value3)
            {
            arrow3.color = activeColor;
            if (!soundPlayed[2])
            {
                SoundFXManager.instance.PlaySoundFXClipArray(audioClips, transform, 1f, 0);
                soundPlayed[2] = true;
            }
            }
    }
    private void ResetArrows(Color color)
    {
        arrow1.color = color;
        arrow2.color = color;
        arrow3.color = color;
        for (int i = 0; i < soundPlayed.Length; i++)
        {
            soundPlayed[i] = false;
        }
    }
    public static Action<int> OnTargetCollected;
    public void UpdateScore(int value)
    {
        _scoreData.ScoreValue = Mathf.Clamp(_scoreData.ScoreValue+ value, 0, _scoreData.ScoreValue+ value);
        //_uiController.UpdateScore(_scoreData.ScoreValue);
        OnTargetCollected?.Invoke(_scoreData.ScoreValue);
    }
}
