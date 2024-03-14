using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{

    [Header("Speed Setup")]
    public Vector2 Frition = new Vector2(-.1f, 0f);

    public float speed;
    public float speedRun;
    public float ForceJump;

    [Header("Animation Setup")]
    public float jumpScaleY;
    public float jumpScaleX;
    public float animationDuration;
    public Animator animator;

    [Header("Animation Player")]
    public string activateAnimation = "Run";
    public string triggerDeath = "Death";
}
