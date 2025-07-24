using UnityEngine;

public class TextureOffset : MonoBehaviour
{
    [SerializeField] private float speed;

    public GameManager gm;

    [SerializeField] private Renderer ren;
    // Update is called once per frame
    void Update()
    {
        ren.material.mainTextureOffset -= Vector2.left * Time.deltaTime * speed * gm.bgSpeed;
    }
}
