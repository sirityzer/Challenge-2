using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public float jumpForce;
    public Transform groundCheck;
    public Text countText;
    public Text winText;
    public Text lifeText;
    public Text loseText;
    public AudioSource regular;
    public AudioSource win;
    private int count;
    private int lives;
    bool grounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        loseText.text = "";
        DontDestroyOnLoad(gameObject);
        lives = 3;
        SetCountText();
        SetLifeText();
    }


    // Update is called once per frame
    void Update()
    {
        
    
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);
        rb2d.rotation = 0.0f;
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            if (count == 4)
            {
                SceneManager.LoadScene("Level 2");
                lives = 3;
            }
            
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
        }
        SetLifeText();
        SetCountText();
    }
    void SetLifeText()
    {
        lifeText.text = "Lives:" + lives.ToString();
        if (lives <= 0)
        {
            loseText.text = "You Died";
            Destroy(gameObject);
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You Win!";
            regular.mute=true;
            win.mute = false;

        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (rb2d.velocity.y<0)
            {


                if (Input.GetKey(KeyCode.UpArrow))
                {
                    rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                    grounded = false;
                }
            }
        }
    }
}
