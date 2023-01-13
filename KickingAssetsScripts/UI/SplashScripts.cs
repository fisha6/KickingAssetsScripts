using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScripts : MonoBehaviour
{
    [SerializeField] private GameObject _gameWonObj;
    [SerializeField] private GameObject _gameLostObj;
    [SerializeField] private GameObject _UI;

    public void ReturnToMenu() //Returns to scene 0 (The Main Menu).
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (GameStats.instance.gameWon) //toggles on the game won splash screen, activates the cursor and toggles off the UI.
        {
            Time.timeScale = 0;
            _UI.SetActive(false);
            _gameWonObj.SetActive(true);
            Cursor.visible = true;
        }
        else if (GameStats.instance.gameLost) //toggles on the game lost splash screen, activates the cursor and toggles off the UI.
        {
            Time.timeScale = 0;
            _UI.SetActive(false);
            _gameLostObj.SetActive(true);
            Cursor.visible = true;
        }
    }
}
