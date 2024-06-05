using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    [Header("Enemies")]
    public int enemiesKilled;

    [Header("Gamemode")]
    public int score;


    [Header("Player")]
    public int maxHealth = 3;
    public int health = 3;

    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI waveNumberText;

    public TextMeshProUGUI endScoreText;
    public TextMeshProUGUI endWaveNumberText;
   
    SpawnManager spawnManager;

    [SerializeField] GameObject Player;
    [SerializeField] GameObject ui;
    [SerializeField] GameObject gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*scoreText.text = "Score:" + score.ToString();
        waveNumberText.text = "Wave Number:" + spawnManager.wave.ToString();

        endScoreText.text = "Score:" + score.ToString();
        endWaveNumberText.text = "Wave Number:" + spawnManager.wave.ToString();*/


        if (health == 0)
        {
            ui.SetActive(false);
            gameOverText.SetActive(true);
            Player.SetActive(false);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
    }
}
