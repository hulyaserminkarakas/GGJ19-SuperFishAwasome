using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {
    //player position elements
    public Vector3 playerPos;
    //collectibles
    public int score;
    public int hp;
    public int powerUp1;
    public SaveData() { }
    public SaveData(Vector3 playerPos, int hp, int score, int powerUp1)
    {
        this.playerPos = playerPos;
        this.score = score;
        this.hp = hp;
        this.powerUp1 = powerUp1;
    }
}
