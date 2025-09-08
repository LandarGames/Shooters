using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Hold")]
    public GameObject Hold;
 

    [SerializeField] private Transform _camera;
    [Header("AimGun")]

    private State _state;
    private Rigidbody _rb;
    private bool _jump = false;

    [SerializeField] private UIPanel _panel;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _state = GetComponent<State>();
        _panel.NewBullet.Invoke(Hold.GetComponent<Gun>()._bullet, Hold.GetComponent<Gun>().MaxBullet);

    }

    private void Update()
    {
        GetComponent<MoveMent>().Move(_state);
        if (Input.GetKeyDown(KeyCode.Space) && _jump)
        {
            GetComponent<MoveMent>().Jump(_state);
            _jump = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            UseItem();
        }
    }



    

    private void UseItem()
    {
        Hold.GetComponent<Gun>().Shot(_camera);
        _panel.NewBullet.Invoke(Hold.GetComponent<Gun>()._bullet, Hold.GetComponent<Gun>().MaxBullet);
    }


    private void OnCollisionEnter(Collision collision)
    {
        _jump = true;
    }

}
