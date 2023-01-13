using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLose : MonoBehaviour
{
    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Enemy") //Checks to see if the player is infront of the enemy during a collision and ends the game if so.
        {
            Vector3 directionToPlayer = transform.position - c.transform.position;
            float dotProduct = Vector3.Dot(c.transform.forward, directionToPlayer);

            if (dotProduct > 0)
            {
                GameStats.instance.gameLost = true;
                SoundEffects.StopSounds();
                SoundEffects.PlaySoundEffect("GameOver");
            }
        }
    }
}
