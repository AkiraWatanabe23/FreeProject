using System;
using UnityEngine;

[Serializable]
public class PlayerAnimation
{
    private Animator _anim = default;
    private string _currentAnimation = "";

    public void Init(Animator animator)
    {
        _anim = animator;
    }

    public void ChangeAnimToIdle()
    {
        if (_currentAnimation == "Idle") { return; }

        _currentAnimation = "Idle";
    }

    public void ChangeAnimToMove()
    {
        if (_currentAnimation == "Move") { return; }

        _currentAnimation = "Move";
    }

    public void ChangeAnimToAttackLongDistance()
    {
        if (_currentAnimation == "LongDistance") { return; }

        _currentAnimation = "LongDistance";
    }

    public void ChangeAnimToAttackProximity()
    {
        if (_currentAnimation == "Proximity") { return; }

        _currentAnimation = "Proximity";
    }

    public void ChangeAnimToDamage()
    {
        if (_currentAnimation == "Damage") { return; }

        _currentAnimation = "Damage";
    }

    public void ChangeAnimToDeath()
    {
        if (_currentAnimation == "Death") { return; }

        _currentAnimation = "Death";
    }
}
