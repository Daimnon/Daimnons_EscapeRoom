using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField]
    private GameObject _greenKey, allAnswers;

    [SerializeField]
    private TextMeshProUGUI _questionText;

    public void DropKey()
    {
        _questionText.fontSize = 3;
        _questionText.text = "Correct!";
        allAnswers.SetActive(false);
        _greenKey.SetActive(true);
    }
}
