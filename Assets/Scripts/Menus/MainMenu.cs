using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _howToPlayPanel;
    [SerializeField] private GameObject _creditsPanel;
    [SerializeField] private GameObject _optionsPanel;

    private GameObject _currentPanel;
    private void Start()
    {
        _currentPanel = _mainMenuPanel;
    }

    public void StartGame()
    {
        _currentPanel = _mainMenuPanel;
    }

    public void OpenHowToPlay()
    {
        SetCurrentPanel(_howToPlayPanel);
    }

    public void Options()
    {
        SetCurrentPanel(_optionsPanel);
    }

    public void Credits()
    {
        SetCurrentPanel(_creditsPanel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SetCurrentPanel(_mainMenuPanel);
    }

    /// <summary>
    /// Closes current panel and opens new panel
    /// </summary>
    /// <param name="visible"></param>
    /// <param name="newPanel"></param>
    private void SetCurrentPanel(GameObject newPanel)
    {
        _currentPanel.SetActive(false);
        _currentPanel = newPanel;
        _currentPanel.SetActive(true);
    }
}
