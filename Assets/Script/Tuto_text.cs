using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Tuto_text : MonoBehaviour
{
    [SerializeField] private TMP_Text txt;
    [SerializeField] private Image Mouse;
    [SerializeField] private Image MouseLeft;

    void Start()
    {
        string str = "Pour se déplacer, maintenir       et relacher";
        txt.text = str;

    }
}
