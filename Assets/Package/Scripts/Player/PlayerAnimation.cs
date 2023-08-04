using System;
using UnityEngine;

[Serializable]
public class PlayerAnimation
{
    private Animator _anim = default;

    public void Init(Animator animator)
    {
        _anim = animator;
    }
}
