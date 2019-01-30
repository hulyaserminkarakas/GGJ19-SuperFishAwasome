using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Movement", menuName = "Enemy Asset/Movement", order = 5)]
public class Movement : ScriptableObject {

    [Range(2f, 5f)]
    public float timeBetweenJump = 3.0f;
    [Range(2f, 10f)]
    public float jumpForce = 3.0f;
    public bool canJump = false;
    [Header("Choose moveForward or patrol")]
    [Range(0f, 10f)]
    public float speed = 2.0f;
    public bool moveForwardOnly = true;
    public bool patrol = false;
    [Range(2f, 4f)]
    public float patrolRange = 3.0f;
}
