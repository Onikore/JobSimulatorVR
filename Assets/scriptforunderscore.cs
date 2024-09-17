using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scriptforunderscore : MonoBehaviour
{
    [SerializeField] private string originalText="Взять планшет";
    [SerializeField] private bool ToggleState = false;

    void Start()
    {
        TextMeshProUGUI textMeshPro = GetComponent<TextMeshProUGUI>();

        UpdateText();
        
    }

    public void ToggleStateChanged(bool state)
    {
        ToggleState = state;
        UpdateText();
    }

    private void UpdateText()
    {
        TextMeshProUGUI textMeshPro = GetComponent<TextMeshProUGUI>();

        if (ToggleState)
        {
            textMeshPro.text =$"<s>{originalText} </s>";
        }
        else
        {   
            textMeshPro.text = originalText;
        }
    }

}
