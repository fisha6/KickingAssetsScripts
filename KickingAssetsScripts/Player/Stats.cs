using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [Header("Movement Values")]
    [SerializeField] private bool move3D;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float climbSpeed;
    [SerializeField] private float jumpStrength;
    [SerializeField] private float initGravityMultiplier;
    [SerializeField] private float fallGravityMultiplier;
    [SerializeField] private float dragSpeed;
    [SerializeField] private float dragDistance;
    [SerializeField] private float collisionDistanceBuffer;

    [Header("Elevator Values")]
    [SerializeField] private float minY; // 8.0f for level 1.
    [SerializeField] private float maxY; // 30.0f for level 1.

    [Header("Combat Values")]
    [SerializeField] private float meleeDistance;
    [SerializeField] private bool detected;
    [SerializeField] private int killCount;

    private Vector3 direction;
    private bool atCupboard = false;
    private bool atElevator = false;
    private bool atClimbable = false;
    private bool climbing = false;
    private bool hanging = false;
    private bool canExecute = false;
    private bool dragging = false;
    private bool canDragBody = false;
    private bool canHideBody = false;
    private float speed;
    private GameObject deadAI;

    public static Stats instance;

    void Start()
    {
        instance = this;
        speed = moveSpeed;
        killCount = 0;
    }

    /**
     * START OF GETTERS & SETTERS
     */

    //Movement Getters & Setters
    public Vector3 Direction
    {
        get { return direction; }
        set { direction = value; }
    }
    public bool Move3D
    {
        get { return move3D; }
        set { move3D = value; }
    }

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public float ClimbSpeed
    {
        get { return climbSpeed; }
    }

    public float DragSpeed
    {
        get { return dragSpeed; }
    }

    public bool Dragging
    {
        get { return dragging; }
        set { dragging = value; }
    }

    public float DragDistance
    {
        get { return dragDistance; }
    }

    public float JumpStrength
    {
        get { return jumpStrength; }
        set { jumpStrength = value; }
    }

    public float InitGravityMultiplier
    {
        get { return initGravityMultiplier; }
        set { initGravityMultiplier = value; }
    }

    public float FallGravityMultiplier
    {
        get { return fallGravityMultiplier; }
        set { fallGravityMultiplier = value; }
    }

    public bool AtClimbable
    {
        get { return atClimbable; }
        set { atClimbable = value; }
    }

    public bool Climbing
    {
        get { return climbing; }
        set { climbing = value; }
    }

    public bool Hanging
    {
        get { return hanging; }
        set { hanging = value; }
    }   

    public float CollisionDistanceBuffer
    {
        get { return collisionDistanceBuffer; }
    }
    //Elevator Getters & Setters
    public float MinY
    {
        get { return minY; }
        set { minY = value; }
    }

    public float MaxY
    {
        get { return maxY; }
        set { maxY = value; }
    }
    
    public bool AtElevator
    {
        get { return atElevator; }
        set { atElevator = value; }
    }

    //Combat Getters & Setters
    public bool Detected
    {
        get { return detected; }
        set { detected = value; }
    }

    public float MeleeDistance
    {
        get { return meleeDistance; }
        set { meleeDistance = value; }
    }

    public bool CanExecute
    {
        get { return canExecute; }
        set { canExecute = value; }
    }

    public bool CanDragBody
    {
        get { return canDragBody; }
        set { canDragBody = value; }
    }

    public bool CanHideBody
    {
        get { return canHideBody; }
        set { canHideBody = value; }
    }

    public bool AtCupboard
    {
        get { return atCupboard; }
        set { atCupboard = value; }
    }

    public GameObject DeadAI
    {
        get { return deadAI; }
        set { deadAI = value; }
    }

    public int KillCount
    {
        get { return killCount; }
        set { killCount = value; }
    }
}
