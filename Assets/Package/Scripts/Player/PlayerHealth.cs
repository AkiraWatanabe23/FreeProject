using System;
using UnityEngine;

[Serializable]
public class PlayerHealth : IDamage
{
    [SerializeField]
    private int _hp = 1;

    private GameObject _player = default;

    public void Init(GameObject player)
    {
        _player = player;
    }

    public void ReceiceDamage(int value)
    {
        _hp -= value;
        if (_hp <= 0f)
        {
            //Animation再生とか？
            _player.SetActive(false);
        }
    }
}
