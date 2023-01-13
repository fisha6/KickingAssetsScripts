using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCheck : MonoBehaviour
{
    void Update()
    {
        InteractionCheck();
    }
    private void InteractionCheck() // Checks to see if the player is infront of any interactable objects.
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Climbable") Stats.instance.AtClimbable = true;
            else Stats.instance.AtClimbable = false;

            if (hit.transform.tag == "Elevator") Stats.instance.AtElevator = true;
            else Stats.instance.AtElevator = false;

            if (hit.transform.tag == "Cupboard") Stats.instance.AtCupboard = true;
            else Stats.instance.AtCupboard = false;
        }
    }
}
