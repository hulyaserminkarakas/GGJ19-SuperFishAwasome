using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SimpleAudioConfig", menuName = "Enemy Asset/Simple Audio Config", order = 2)]
public class SimpleAudioConfig : ScriptableObject {

    [Range(0.5f, 2.0f)]
    public float pitch;
    [Range(0.5f, 2f)]
    public float volume;
}
