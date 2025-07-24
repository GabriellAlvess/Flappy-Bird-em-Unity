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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            jump = true;
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
        if (jump)
        {
            rb.linearVelocity = Vector2.up * jumpForce;
            jump = false;
        }

        transform.rotation = Quaternion.Euler(0, 0,
            Mathf.Clamp( (rb.linearVelocity.y + 2)* rotationMultiplayer, -85, 20)); 
    }
}
