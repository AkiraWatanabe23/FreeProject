using System;
using UnityEngine;

[Serializable]
public class PlayerHealth : IDamage
{
    [SerializeField]
    private int _hp = 1;

    private GameObject _player = default;
    private AnimationPlayer _animation = default;

    public void Init(GameObject player, AnimationPlayer animation)
    {
        _player = player;
        _animation = animation;
    }

    public void ReceiceDamage(int value)
    {
        _hp -= value;
        _animation.ChangeAnimation("Damage");

        if (_hp <= 0f)
        {
            _animation.ChangeAnimation("Death");
            _player.SetActive(false);
        }
    }
}
