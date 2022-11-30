using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class UpdateTextToNumber : MonoBehaviour
{
    TMP_Text text;
    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    public void UpdateTextTo(float number)
    {
        text.text = number.ToString("F1");
    }
}
