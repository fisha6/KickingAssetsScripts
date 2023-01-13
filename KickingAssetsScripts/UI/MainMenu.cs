using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _instructionsObj;
    [SerializeField] private GameObject _controlsObj;

    public void StartGame()
    {
        if (Time.timeScale != 1) Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void ToggleInstructions()
    {
        if (_instructionsObj.activeInHierarchy)
        {
            _instructionsObj.SetActive(false);
        }
        else
        {
            _instructionsObj.SetActive(true);
        }
    }

    public void ToggleControls()
    {
        if (_controlsObj.activeInHierarchy)
        {
            _controlsObj.SetActive(false);
        }
        else
        {
            _controlsObj.SetActive(true);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
