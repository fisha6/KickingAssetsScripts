using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject _platform;
    [SerializeField] private bool moveHorizontal;
    [SerializeField] private float moveDistance;
    [SerializeField] private float speed;

    private float originalYPos;
    private float originalXPos;
    private float runningTime = 0.0f;

    private void Update()
    {
        Motion();
    }

    private void Start()
    {
        originalYPos = _platform.transform.position.y;
        originalXPos = _platform.transform.position.x;
    }

    private void Motion() //Handles the movement of the platform (can move side to side or up and down based on the moveHorizontal bool.)
    {
        runningTime += Time.deltaTime;

        if (moveHorizontal)
            transform.position = new Vector3(originalXPos + ((float)Math.Sin(runningTime * speed) * moveDistance), transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x, originalYPos + ((float)Math.Sin(runningTime * speed) * moveDistance), transform.position.z);
    }
}
