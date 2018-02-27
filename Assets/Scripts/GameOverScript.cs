using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {
    public Text txtGameOver;
    public RectTransform panelGameOver;
    public Sprite rocket;

    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(5);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    void FixedUpdate()
    {
        if (player.curHealth <= 0)
        {
            StartCoroutine(Restart());
            Dead();
            Restart();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(Restart());
            Win();
            Restart();
        }
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
