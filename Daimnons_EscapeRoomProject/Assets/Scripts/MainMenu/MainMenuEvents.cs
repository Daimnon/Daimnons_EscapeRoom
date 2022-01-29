using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuEvents : MonoBehaviour
{
    [SerializeField]
    private GameObject _menuPanel, _ControlsPanel, _CreditsPanel;

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
}
