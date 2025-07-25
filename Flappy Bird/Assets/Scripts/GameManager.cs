using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float bgSpeed = 1f;
    public float obstacleSpeed = 1f;
    public GameObject player;
    public GameObject obstacleSpawner;
    public GameObject gameStartPanel;
    public GameObject gameOverPanel;
    public GameObject scorePanel;
    public bool gamePlaying;

    public void GameStart()
    {
        gamePlaying = true;
        scorePanel.SetActive(true);
        obstacleSpawner.SetActive(true);
        player.GetComponent<Rigidbody2D>().gravityScale = 1f;
        gameStartPanel.SetActive(false);
    }

    public void GameOver()
    {
        bgSpeed = 0f;
        obstacleSpeed = 0f;
        gameOverPanel.SetActive(true);
        gamePlaying = false;
    }


}
