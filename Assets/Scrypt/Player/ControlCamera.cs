using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    private float eulerX = 0, eulerY = 0;
    [SerializeField] private float _razresh;
    private void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y") * -(1);
        eulerX = (transform.rotation.eulerAngles.x + y * _razresh) % 360;
        eulerY = (transform.rotation.eulerAngles.y + x * _razresh) % 360;

        transform.parent.Rotate(x * _razresh * Vector3.up);
        transform.localRotation = Quaternion.Euler(eulerX,0, 0);
    }
}
