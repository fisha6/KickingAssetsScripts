using UnityEngine;

public class OperateElevator : MonoBehaviour
{
    private Rigidbody _rb;
    private GameObject _player;
    private const float FLOORDISTANCE = 10.0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        UseElevator();
    }

    private void UseElevator()
    {
        if (Stats.instance.AtElevator && !Stats.instance.Dragging)
        {
            if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.E) && _rb.transform.position.y > Stats.instance.MinY)
            {
                Vector3 newPos = new Vector3(_rb.transform.position.x, _rb.transform.position.y - FLOORDISTANCE, _rb.transform.position.z);
                _rb.transform.position = newPos;
                Stats.instance.AtElevator = false;
                SoundEffects.PlaySoundEffect("ElevatorSound");
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.E) && _rb.transform.position.y < Stats.instance.MaxY)
            {

                Vector3 newPos = new Vector3(_rb.transform.position.x, _rb.transform.position.y + FLOORDISTANCE, _rb.transform.position.z);
                _rb.transform.position = newPos;
                Stats.instance.AtElevator = false;
                SoundEffects.PlaySoundEffect("ElevatorSound");
            }
        }
    }
}
