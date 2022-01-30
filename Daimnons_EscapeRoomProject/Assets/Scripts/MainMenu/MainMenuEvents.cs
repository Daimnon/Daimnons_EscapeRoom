using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuEvents : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField]
    private GameObject _menuPanel, _ControlsPanel, _CreditsPanel;
    #endregion

    #region Unity Events
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Controls()
    {
        _menuPanel.SetActive(false);
        _ControlsPanel.SetActive(true);
    }

    public void Credits()
    {
        _menuPanel.SetActive(false);
        _CreditsPanel.SetActive(true);
    }

    public void ReturnToMenu()
    {
        if (_ControlsPanel.activeInHierarchy)
        {
            _ControlsPanel.SetActive(false);
            _menuPanel.SetActive(true);
        }
        else if (_CreditsPanel.activeInHierarchy)
        {
            _CreditsPanel.SetActive(false);
            _menuPanel.SetActive(true);
        }
    }
    #endregion
}
