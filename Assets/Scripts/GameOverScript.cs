using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {
    public Text txtGameOver;
    public RectTransform panelGameOver;
    public Button resButton;
    public Sprite rocket;
    public float finalTime;

    private Player player;
    private Timer t;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        t = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
    }

    void FixedUpdate()
    {
        if (player.curHealth <= 0)
        {
            Dead();
            resButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Win();
            finalTime = 999f - t.timer;
            resButton.gameObject.SetActive(true);
        }
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void Dead()
    {
        panelGameOver.gameObject.SetActive(true);
        txtGameOver.text = "YOU LOSE";
    }

    public void Win()
    {
        panelGameOver.gameObject.SetActive(true);
        txtGameOver.gameObject.SetActive(true);
    }
}
