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
        //_questionText.transform.position -= new Vector3(_questionText.transform.position.x, _questionText.transform.position.y - 10, _questionText.transform.position.z);
        _questionText.fontSize = 3;
        _questionText.text = "Correct!";
        _allAnswers.SetActive(false);
        _greenKey.SetActive(true);
    }
    #endregion
}
