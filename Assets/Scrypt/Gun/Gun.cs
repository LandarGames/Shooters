using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float Damage;
    public float SpedBullet;
    public int MaxBullet;
    public float KdRecharge;
    public float Delay;
    public int TipeDamage;
    public Vector3 Aiming;

    private Ray _ray;
    private bool _enabled = true;
    private float _time;
    public int _bullet;
    private bool _recharge = false;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private GameManager _gm;

    private void Awake()
    {
        _bullet = MaxBullet;
    }
    private void Update()
    {
        if (_time < 0)
        {
            GetComponent<Animator>().SetBool("Atak", false);
            if (_recharge == true)
            {
                _bullet = MaxBullet;
                _recharge = false;
                GetComponent<Animator>().SetBool("Recharge", false);
            }
            GetComponent<Animator>().speed = 1;
            return;
        }

        _time -= Time.deltaTime;
    }

    public float GetRegacrge()
    {
        if (_bullet > 0)
        {
            return 0;
        }
        return _time / KdRecharge;
    }
    public void Shot(Transform pos)
    {
        if (_time < 0 && _bullet > 0)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Animator>().SetBool("Atak",true);
            GetComponent<Animator>().speed = 1 / Delay;
            _effect.Play();
            _enabled = true;
            _ray = new Ray(pos.position, pos.forward);
            RaycastHit hit;
            _bullet -= 1;
            if (Physics.Raycast(_ray, out hit, Mathf.Infinity,1,QueryTriggerInteraction.Ignore) && _enabled == true)
            {

                Transform objectHit = hit.transform;
                Debug.Log(objectHit.gameObject);
                if (objectHit.tag == "Head")
                {
                    Debug.Log("YE");
                    objectHit.parent.gameObject.GetComponent<State>()?.TakeDamage(Damage * 2, TipeDamage);
                    _gm.Head.Invoke();
                }
                else
                {
                    objectHit.gameObject.GetComponent<State>()?.TakeDamage(Damage, TipeDamage);
                }
                _enabled = false;
            }
            if (_bullet > 0)
            {
                _time = Delay;
            }
            else
            {

                GetComponent<Animator>().SetBool("Recharge", true);
                GetComponent<Animator>().speed = 1 / KdRecharge;
                _time = KdRecharge;
                _recharge = true;
            }

        }
    }

    public void Recharge()
    {
        GetComponent<Animator>().SetBool("Recharge", true);
        GetComponent<Animator>().speed = 1 / KdRecharge;
        _bullet = 0;
        _recharge = true;
        _time = KdRecharge;
    }
}
