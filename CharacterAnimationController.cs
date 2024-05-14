using System;
using UnityEngine;

public class CharacterAnimationController : AnimationController
{
    private static readonly int isWalking = Animator.StringToHash("isWalking");
    //animation을 0.5 이상 안갈때 멈추는 로직?
    private readonly float magnituteThreshold = 0.5f;
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 vector)
    {
        // vector의 magnitude가 0.5f보다 크다면 움직이고 아니면 false
        animator.SetBool(isWalking, vector.magnitude > magnituteThreshold);
    }
}