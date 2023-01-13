using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        SetClimb();
        Climbing();
    }

    private void SetClimb()
    {
        if (Stats.instance.AtClimbable || Stats.instance.Climbing)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Stats.instance.Climbing = !Stats.instance.Climbing;

                if (Stats.instance.Hanging) Stats.instance.Hanging = false;

                if (_rb.useGravity) _rb.useGravity = false;
                else _rb.useGravity = true;
            }
        }
    }

    private void Climbing()
    {
        if (Stats.instance.Climbing)
        {
            if (Input.GetKey(KeyCode.W) && CeilingCheck() > 1.2 && !Stats.instance.Hanging)
            {
                transform.Translate(transform.up * Stats.instance.ClimbSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S) && HeightCheck() > 1.5 && !Stats.instance.Hanging)
            {
                transform.Translate(-transform.up * Stats.instance.ClimbSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.A) && CeilingCheck() < 1.22 && Stats.instance.AtClimbable)
            {
                Stats.instance.Hanging = true;
                transform.Translate(-transform.right * Stats.instance.ClimbSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D) && CeilingCheck() < 1.22 && Stats.instance.AtClimbable)
            {
                Stats.instance.Hanging = true;
                transform.Translate(transform.right * Stats.instance.ClimbSpeed * Time.deltaTime);
            }
        }
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

    private float CeilingCheck() // Returns the distance between the player and whatever object is above.
    {
        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.distance;
        }
        else return -1;
    }
}
