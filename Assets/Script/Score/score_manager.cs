using UnityEngine;
using System;
using UnityEngine;
using TMPro;
public class NewMonoBehaviourScript : MonoBehaviour
{

    [SerializeField] private TMP_Text _scoreText;

    private void Start()
    {
        UpdateScore(0);
    }
    
    public void UpdateScore(int NewScore)
    {
        _scoreText.text = "Score : " + NewScore.ToString();
        //  _scoreText.text = $"Score : {NewScore.ToString()}; methode plus sur
    }


    private void OnEnable()
    {
        Main_Player_Mouvement.OnTargetCollected += UpdateScore; 
    }

    private void OnDisable()
    {
        Main_Player_Mouvement.OnTargetCollected -= UpdateScore;
    }
}


