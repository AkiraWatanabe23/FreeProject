using System;
using UnityEngine;

[Serializable]
public class PlayerHealth : IDamage
{
    [SerializeField]
    private int _hp = 1;

    public void Init()
    {

    }

    public void ReceiceDamage(int value)
    {
        _hp -= value;
        if (_hp <= 0f)
        {
            //Animation再生とか？
        }
    }
}
