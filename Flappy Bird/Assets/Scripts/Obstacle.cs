using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public float speed;
    private GameManager gm;


    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        transform.position += Vector3.left * speed * gm.obstacleSpeed * Time.deltaTime;
    }
}
