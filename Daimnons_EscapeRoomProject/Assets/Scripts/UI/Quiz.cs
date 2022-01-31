using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField]
    private GameObject _greenKey, _allAnswers;

    [SerializeField]
    private TextMeshProUGUI _questionText;
    #endregion

    #region Unity Events
    public void DropKey()
    {
        _questionText.fontSize = 3;
        _questionText.text = "Correct!";
        _allAnswers.SetActive(false);
        _greenKey.SetActive(true);
    }
    #endregion
}
