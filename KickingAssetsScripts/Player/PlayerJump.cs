using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float fallingHeight;
    private Rigidbody _rb;
    private float height;
    private bool falling = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        height = HeightCheck();

        if (height > fallingHeight)
        {
            falling = true;
        }

        Jump();
        AdjustGravity();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !Stats.instance.Climbing && !Stats.instance.Dragging) 
        {
            if (height < 1.5f && height != -1) // Prevents double jumping and jumping when falling.
            {
                _rb.AddForce(transform.up * Stats.instance.JumpStrength, ForceMode.Impulse); // Handles the player's jump.
            }
        }
    }

    private void AdjustGravity()
    {
        if (_rb.velocity.y < 0) _rb.velocity += Vector3.up * Physics.gravity.y * (Stats.instance.FallGravityMultiplier - 1) * Time.deltaTime;
        else if (_rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            _rb.velocity += Vector3.up * Physics.gravity.y * (Stats.instance.InitGravityMultiplier - 1) * Time.deltaTime;
        }
        /* 
         * Adjusts Gravity at 2 points during jumping, before the player reaches peak height and after,
         * giving the jump a nicer feel. Also allows the player to hold space to have a stronger jump.
         */
    }

    private float HeightCheck() // Returns the distance between the player and whatever object or terrain is below.
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.distance;
        }
        else return -1;
    }

    private void OnCollisionEnter(Collision c)
    {
        if (falling) //Handles landing after a jump.
        {
            if (c.transform.position.y < transform.position.y && c.transform.tag == "Floor")
            {
                falling = false;
                if (!Stats.instance.Dragging)
                    SoundEffects.PlaySoundEffect("JumpImpact");

                /**
                  Checks to see you're above the object you collide with before playing a sound,
                  this will ensure the player has landed on something after a jump and not just ran into an object.
                */
            }
        }
    }
}
