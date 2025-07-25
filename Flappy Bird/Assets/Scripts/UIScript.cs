using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

    public GameManager gm;
    public GameObject startPanel;
    public GameObject overPanel;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (startPanel.activeInHierarchy)
            {
                gm.GameStart();
            }

            if (overPanel.activeInHierarchy)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

    }
}

