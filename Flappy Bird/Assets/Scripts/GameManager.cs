using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float bgSpeed = 1f;

    public float obstacleSpeed = 1f;

    public void GameOver()
    {
        bgSpeed = 0f;
        obstacleSpeed = 0f;
    }

}
