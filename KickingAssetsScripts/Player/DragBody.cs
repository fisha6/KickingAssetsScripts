using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBody : MonoBehaviour
{
    void Update()
    {
        DeadEnemyCheck();
        if (Stats.instance.Dragging)
        {
            StopDrag();
        }
        else
        {
            Stats.instance.MoveSpeed = Stats.instance.MoveSpeed;
            Drag();
        }
    }

    private bool DeadEnemyCheck() // Checks to see if there is a dead enemy infront of the player.
    {
        Ray ray = new Ray(transform.position, Stats.instance.Direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "DeadEnemy")
            {
                Stats.instance.DeadAI = hit.transform.gameObject;
                return true;
            }
            else return false;
        }
        else return false;
    }

    private void Drag()
    {
        if (Stats.instance.DeadAI && DistanceCheck() <= Stats.instance.DragDistance && !Stats.instance.Dragging)
        {
            Stats.instance.CanDragBody = true;
            if (!Stats.instance.Dragging && Input.GetKeyDown(KeyCode.F)) //Will begin moving the body.
            {
                //Stats.instance.DeadAI.GetComponentInChildren<SphereCollider>().enabled = false;
                Stats.instance.DeadAI.transform.SetParent(transform);
                Stats.instance.Dragging = true;
                Stats.instance.CanDragBody = false;
                Stats.instance.Speed = Stats.instance.MoveSpeed - Stats.instance.DragSpeed;
            }
        }
        else
        {
            Stats.instance.CanDragBody = false;
        }


    }

    private void StopDrag()
    {
        if (Stats.instance.Dragging)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Transform childToRemove = transform.Find("Enemy");
                childToRemove.parent = null;
                Stats.instance.Dragging = false;
                Stats.instance.Speed = Stats.instance.MoveSpeed;
            }
        }
    }

    private float DistanceCheck()
    {
        float distance = Vector3.Distance(transform.position, Stats.instance.DeadAI.transform.position);
        return distance;
    }


}
