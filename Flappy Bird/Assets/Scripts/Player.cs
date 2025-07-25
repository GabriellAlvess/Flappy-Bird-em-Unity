using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float jumpForce;
    public float rotationMultiplayer;
    public Animator animator;
    public int score;

    public GameManager gm;
    public Rigidbody2D rb;

    [SerializeField] private bool jump;
    public TextMeshProUGUI scoreText;

    public AudioSource jumpSound;
    public AudioSource hitSound;
    public AudioSource scoreSound;
    public AudioSource dieSound;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            jump = true;
            jumpSound.Play();
        }

        // Codigo para rodar apenas no editor da Unity
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            jump = true;
        }
#endif

    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            if (jump)
            {
                rb.linearVelocity = Vector2.up * jumpForce;
                jump = false;
            }
            if (rb.linearVelocity.sqrMagnitude > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0,
                    Mathf.Clamp((rb.linearVelocity.y + 2) * rotationMultiplayer, -85, 20));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.name.Equals("Celling"))
        {
            if (collision.collider.tag.Equals("Obstacle"))
            {
                foreach (BoxCollider2D col in collision.collider.transform.parent.GetComponentsInChildren<BoxCollider2D>())
                {
                    col.enabled = false;
                }
            }

            animator.enabled = false;

            if (gm.gamePlaying)
            {
                hitSound.Play();
                dieSound.Play();
            }

            if (collision.collider.name.Equals("Ground"))
            {
                Destroy(rb);
            }

            gm.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        scoreText.text = score.ToString();
        scoreSound.Play();
        if (score % 5 == 0)
        {
            gm.obstacleSpeed += 0.1f;
            gm.bgSpeed += 0.1f;
        }

    }
}
