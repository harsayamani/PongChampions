using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ballController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;
    int scoreP1;
    int scoreP2;
    Text scoreUIP1;
    Text scoreUIP2;
    GameObject gamOverPanel;
    Text txWinner;
    AudioSource audio;
    public AudioClip hitSound, goalSound;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        gamOverPanel = GameObject.Find("gameOverPanel");
        gamOverPanel.SetActive(false);

        scoreP1 = 0;
        scoreP2 = 0;

        scoreUIP1 = GameObject.Find("scorePlayer1").GetComponent<Text>();
        scoreUIP2 =  GameObject.Find("scorePlayer2").GetComponent<Text>();

        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2, 0).normalized;
        rigid.AddForce(arah * force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void resetBall(float arah)
    {
        transform.localPosition = new Vector2(arah, 0);
        rigid.velocity = new Vector2(0, 0);
    }

    void showScore()
    {
        Debug.Log("Score P1: " + scoreP1 + " Score P2: " + scoreP2);
        scoreUIP1.text = scoreP1 + "";
        scoreUIP2.text = scoreP2 + "";
    }

    

    private void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.name == "tepiKanan")
        {
            audio.PlayOneShot(goalSound);
            scoreP2 += 1;
            showScore();

            if (scoreP2 == 5)
            {
                gamOverPanel.SetActive(true);
                txWinner = GameObject.Find("pemenang").GetComponent<Text>();
                txWinner.text = "Player 2 Winner";
                Destroy(gameObject);
                return;
            }

            resetBall(-6);
            Vector2 arah = new Vector2(2, 0).normalized;
            rigid.AddForce(arah * force);
        }

        else if (coll.gameObject.name == "tepiKiri")
        {
            audio.PlayOneShot(goalSound);
            scoreP1 += 1;
            showScore();

            if (scoreP1 == 5)
            {
                gamOverPanel.SetActive(true);
                txWinner = GameObject.Find("pemenang").GetComponent<Text>();
                txWinner.text = "Player 1 Winner";
                Destroy(gameObject);
                return;
            }

            resetBall(6);
            Vector2 arah = new Vector2(-2, 0).normalized;
            rigid.AddForce(arah * force);
        }
        else
        {
            audio.PlayOneShot(hitSound);
        }

        if (coll.gameObject.name == "pemukul1" || coll.gameObject.name == "pemukul2")
        {
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * force * 2);
        }
    }
}
