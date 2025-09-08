using UnityEngine;

public class MoveMent : MonoBehaviour
{
    private Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void Move(State _state)
    {
        float heist = 1;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            heist = _state.Heist;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            heist = 1;
        }

        Vector3 go = new Vector3(x * _state.Speed * heist * Time.deltaTime, 0, y * _state.Speed * heist * Time.deltaTime);
        _rb.AddForce(transform.rotation * go, ForceMode.VelocityChange);
    }

    public void Jump(State _state)
    {
        _rb.AddForce(Vector3.up * _state.JumpSpeed, ForceMode.VelocityChange);
    }
}
