using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider hpBar;
    private SaveData saveData;
    public GameObject player;
    public PlayerCombat playerCombat;
    public static GameManager instance = null;
    public Text scoreTxt;
    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        InitGame();
    }

    void InitGame()
    {
        
        LoadGame();
        playerCombat = player.GetComponent<PlayerCombat>();
        playerCombat.health = saveData.hp;
        ApplySaveData();

    }
    public void DamagePlayer(int damage) {
        bool isDead = playerCombat.ReceiveDamage(damage);
        if (isDead) {
            PlayerMovements pm = player.GetComponent<PlayerMovements>();
            if (pm != null)
            {
                pm.anim.SetTrigger("DeathTrigger");
                pm.isAlive = false;
                Time.timeScale = 0.4f;

            }
        }
        saveData.hp = playerCombat.health;
        hpBar.value = (float)playerCombat.health / 100f;
    }
    private void LoadGame()
    {
        float x, y, z;
        int score, hp;
        int powerUp1;

        x = PlayerPrefs.GetFloat("playerX", 0);
        y = PlayerPrefs.GetFloat("playerY", 0);
        z = PlayerPrefs.GetFloat("playerZ", 0);
        score = 31;
        hp = PlayerPrefs.GetInt("hp", 100);
        powerUp1 = PlayerPrefs.GetInt("powerUp1", 0);
        saveData = new SaveData(new Vector3(x, y, z), hp, score, powerUp1);
    }
    private void SaveGame() {
        if(saveData != null) {
            PlayerPrefs.SetFloat("playerX", saveData.playerPos.x);
            PlayerPrefs.SetFloat("playerY", saveData.playerPos.y);
            PlayerPrefs.SetFloat("playerZ", saveData.playerPos.z);
            PlayerPrefs.SetInt("hp", saveData.hp);
            PlayerPrefs.SetInt("score", saveData.score);
            PlayerPrefs.SetInt("powerUp1", saveData.powerUp1);
        }
    }
    private void ApplySaveData() {
        if (saveData == null)
            return;
        if (player != null) {
          //  player.transform.position = saveData.playerPos;
        }
        if (scoreTxt != null) {
            scoreTxt.text = saveData.score.ToString();
        }
        if (hpBar != null)
        {
            hpBar.value = 1;
        }
        //decide what to do with powerup images
    }
    public void InitGameUI() {
        scoreTxt = GameObject.Find("ScoreTxt").GetComponent<Text>();
        //decide what to do with powerup images and add dem 're
    }
    public void IncreaseScore(int val) {
        saveData.score = saveData.score + val;
        scoreTxt.text = saveData.score.ToString();
    }
    private void OnDestroy()
    {
        int score = PlayerPrefs.GetInt("score", 0);
        int powerUp1 = PlayerPrefs.GetInt("powerUp1", 0);
        //saveData = new SaveData(player.transform.position, playerCombat.health, score, powerUp1);
        SaveGame();
        
    }
    //Enable at the end of the video
    public void DisplayHPBar() {
        hpBar.enabled = true;
    }
}