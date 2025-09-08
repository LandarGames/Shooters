using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _unit;

    [SerializeField] private Transform[] _position;
    [SerializeField] private TextMeshProUGUI _textHead;
    [SerializeField] private TextMeshProUGUI _killText;
    [SerializeField] private TextMeshProUGUI _timer;
    private int _time;
    private int _kill;
    private int _head;
    public Action Kill;
    public Action Head;
    private void Start()
    {
        SpawnNew();
        Timer();
        Kill += Kills;
        Head += Heads;
        _textHead.text = $"{_head},попаданий в голову";
        _killText.text = $"{_kill},убийств";

    }


    private void Kills()
    {
        _kill++;
        _killText.text = $"{_kill} убийств";
    }

    private void Heads()
    {
        _head++;
        _textHead.text = $"{_head} попаданий в голову";
    }

    private void Timer()
    {
        _time++;
        _timer.text = $"{(int)(_time / 60) }:{_time % 60}";
        Invoke(nameof(Timer),1);
    }

    private void SpawnNew()
    {
        GameObject go = Instantiate(_unit,new Vector3(UnityEngine.Random.Range(-10.03f, -2.59f), -0.781f,UnityEngine.Random.Range(-0.11f, 2.753f)),transform.rotation);
        go.gameObject.GetComponent<State>()._gm = GetComponent<GameManager>();
        Invoke(nameof(SpawnNew),5);
    }
}
