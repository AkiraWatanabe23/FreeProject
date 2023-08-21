using System;
using UnityEngine;

[Serializable]
public class AnimationPlayer
{
    private Animator _anim = default;
    private string _currentAnimation = "Idle";

    public void Init(Animator animator)
    {
        _anim = animator;
        ChangeAnimation("Idle");
    }

    public void ChangeAnimation(string nextAnimation)
    {
        if (_currentAnimation == nextAnimation) { return; }

        _anim.SetBool(_currentAnimation, false);
        _currentAnimation = nextAnimation;
        _anim.SetBool(_currentAnimation, true);
    }
}
