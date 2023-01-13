using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float NULLVALUE = -1.0f;
    private GameObject collidedObj;

    void Update()
    {
        movement();
    }

    private void movement() //Handles the player's basic movement.
    {
        float horInput = Input.GetAxis("Horizontal");
        float forInput = Input.GetAxis("Vertical");
        Vector3 moveDir;
        
        
        if(Stats.instance.Move3D) moveDir = new Vector3(horInput, 0, forInput).normalized; // Handles how many dimensions of movement the player has.
        else moveDir = new Vector3(horInput, 0).normalized;

        if (!Stats.instance.Climbing)
        {
            if (DirectionalDistCheck() > Stats.instance.CollisionDistanceBuffer || DirectionalDistCheck() == NULLVALUE || collidedObj.transform.tag == "Player")
                transform.Translate(moveDir * Stats.instance.Speed * Time.deltaTime); // Handles base character movement with keyboard when dragging dead AI.          
        }
        

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        Stats.instance.Direction = moveDir; //Used to establish the direction the player is facing.
    }

    private float DirectionalDistCheck()
    {
        Ray ray = new Ray(transform.position, Stats.instance.Direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            collidedObj = hit.transform.gameObject;
            return Vector3.Distance(transform.position, hit.transform.position);
        }
        else return -1;
    }
}
