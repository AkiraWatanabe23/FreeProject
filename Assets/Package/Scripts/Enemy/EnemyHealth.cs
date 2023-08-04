using UnityEngine;

public class EnemyHealth : IDamage
{
    [SerializeField]
    private int _hp = 1;

    public void ReceiceDamage(int value)
    {
        _hp -= value;
        if (_hp <= 0)
        {

        }
    }
}
