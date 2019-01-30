using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BalikJam", menuName = "Combat/Attack", order = 1)]
public class Attack : ScriptableObject {

    [Header("Combat")]
    public string attackName = "Default Attack";
    public int damage = 40;
    [Space]
    [Header("Movement")]
    [Range(2f, 5f)]
    public float timeBetweenAttacks = 3.0f;
    public bool canJump = false;
    public bool moveForwardOnly = true;
    public bool patrol = false;
    [Range(2f, 4f)]
    public float patrolRange = 3.0f;
    [Space]
    [Header("Audio")]
    public AudioSource attackAudio;
    [Range(0f, 1f)]
    public float pitch;
    [Range(0.5f, 2f)]
    public float volume;
}
