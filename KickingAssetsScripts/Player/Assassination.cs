using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassination : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private GameObject _p;
    [SerializeField] private GameObject _deadEnemy;

    void Update()
    {
        Attack();
    }

    private bool EnemyCheck() // Checks to see if there is an enemy infront of the player and sets "target".
    {
        Ray ray = new Ray(transform.position, Stats.instance.Direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Stats.instance.MeleeDistance))
        {
            if (hit.transform.tag == "Enemy" || hit.transform.tag == "Target")
            {
                target = hit.transform.gameObject; //sets the target
                return true;
            }
            else return false;
        }
        else return false;
    }

    private bool BehindEnemyCheck() // Uses the dot product to determine if the player is behind the enemy.
    {
        Vector3 directionToPlayer = _p.transform.position - target.transform.position;
        float dotProduct = Vector3.Dot(target.transform.forward, directionToPlayer);

        return (dotProduct < 0);
    }

    private void Attack() // Checks if we have a target and if we are behind said target before destroying it.
    {
        if (EnemyCheck() && BehindEnemyCheck())
        {
            Stats.instance.CanExecute = true; //used in UI prompts.

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (target.transform.tag == "Target")
                {
                    Stats.instance.KillCount++;
                    GameStats.instance.gameWon = true;
                    Destroy(target);
                }
                else
                {
                    float reducedHeight = target.transform.position.y - 0.62f;
                    Vector3 spawnLocation = new Vector3(target.transform.position.x, reducedHeight, target.transform.position.z);
                    Instantiate(_deadEnemy, spawnLocation, _deadEnemy.transform.rotation);
                    SoundEffects.PlaySoundEffect("BodyFall");
                    Stats.instance.KillCount++;
                    Destroy(target);
                }
            }
        }
        else Stats.instance.CanExecute = false; //used in UI prompts.
    }
}
