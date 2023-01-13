using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPrompts : MonoBehaviour
{
    [SerializeField] private GameObject _detectedPrompt;
    [SerializeField] private GameObject _elevatorPrompt;
    [SerializeField] private GameObject _interactPrompt;
    [SerializeField] private GameObject _dragPrompt;

    void Update()
    {
        if (!GameStats.instance.gameWon || !GameStats.instance.gameLost) //Calls the HandlePrompts function only if the game is still active.
        {
            HandlePrompts();
        }

    }

    private void HandlePrompts()
    {
        if (Stats.instance.AtElevator && !Stats.instance.Dragging)
            _elevatorPrompt.SetActive(true); //Toggles the elevator prompt UI on and off.
        else _elevatorPrompt.SetActive(false);

        if (Stats.instance.Detected) _detectedPrompt.SetActive(true); //Toggles the detected alert UI on and off.
        else _detectedPrompt.SetActive(false);

        if (Stats.instance.CanDragBody) _dragPrompt.SetActive(true); //Toggles the drag body prompt UI on and off.
        else _dragPrompt.SetActive(false);

        if (Stats.instance.CanHideBody || Stats.instance.CanExecute || Stats.instance.AtClimbable) _interactPrompt.SetActive(true);
        else _interactPrompt.SetActive(false); //Toggles the interact prompt on/off.

    }
}
