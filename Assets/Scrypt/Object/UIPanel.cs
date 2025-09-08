using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIPanel : MonoBehaviour
{
    [SerializeField] private Image _hpBar;
    [SerializeField] private Image _hpDamage;
    [SerializeField] private TextMeshProUGUI _textHp;
    [SerializeField] private TextMeshProUGUI _textDamage;
    [SerializeField] private TextMeshProUGUI _bullet;


    public Action<State,float> NewInfo;
    public Action<int, int> NewBullet;
    public Action<int, int> UpLvlRazrad;

    private float _time;

    private void Awake()
    {
        NewInfo += NewUi;
        NewBullet += NewsBullets;
    }

    private void NewsBullets(int bullet, int maxBullet)
    {
        _bullet.text = $"{bullet}/{maxBullet}";
    }

    private void Update()
    {
        if (_time >= 0)
        {
            _time -= Time.deltaTime;
            return;
        }
        if (_hpBar.fillAmount < _hpDamage.fillAmount)
        {
            _hpDamage.fillAmount -= Time.deltaTime;
        }

    }
    private void NewUi(State state, float damage)
    {
        _textHp.text = $"{state.Hp}/{state.MaxHp}";
        _hpBar.fillAmount = state.Hp / state.MaxHp;
        _time = 1;
        if (damage > 0)
        {
            TextMeshProUGUI text = Instantiate(_textDamage, new Vector3(transform.position.x,transform.position.y + 1,transform.position.z),transform.rotation,transform);
            text.text = damage.ToString();
            Destroy(text, 1);
        }
    }

}
