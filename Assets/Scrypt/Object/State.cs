using UnityEngine;

public class State : MonoBehaviour
{
    public float MaxHp;
    public float Hp;
    public float ResistBullet;
    public float ResistBlast;
    public float Speed;
    public float Heist;
    public float JumpSpeed;

    [SerializeField] private UIPanel _panel;
    public GameManager _gm;


    private void Awake()
    {
        Hp = MaxHp;
    }
    public void TakeDamage(float damage,int tipe)
    {
        switch (tipe)
        {
            case 0:
                Hp -= damage * (1 - ResistBullet / 100);
                break;
            case 1:
                Hp -= damage * (1 - ResistBlast / 100);
                break;
        }
        _panel.NewInfo.Invoke(GetComponent<State>(),damage);
        if (Hp <= 0)
        {
            _gm.Kill.Invoke();
            Destroy(gameObject);
        }
    }
}
