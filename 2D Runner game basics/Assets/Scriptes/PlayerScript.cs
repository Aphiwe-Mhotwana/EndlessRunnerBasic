
using UnityEngine;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour
{
    //Jump Power 
    public float JumpForce;
    // player score
    float score;

    // The player's Rigidbody
    Rigidbody2D rigid;
    // this ref the score textbox
    public Text ScoreText;
    public Button btnStart;


    [SerializeField]
    //Checks if player is on the ground 
    bool isGrounded = false;
    //Checks if player is alive
    bool isAlive = true;


    // this method gets the rigidbody from the player
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        // score is set to zero
        score = 0;
        

    }

    // Update is called once per frame
    void Update()
    {
        //this code makes the player jump
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (isGrounded == true) 
            {
                rigid.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isGrounded == false)
            {
                rigid.AddForce(Vector2.down * JumpForce);
                isGrounded = true;
            }
        }
        // this code increases the score
        if (isAlive)
        {
            score += Time.deltaTime * 4;
            ScoreText.text = "SCORE" + " : " + score.ToString("F");
        }
        else 
        {
            ScoreText.text = "Game Over";
        }
    }
    //Checks collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //checks if player is on the floor
        if (collision.gameObject.CompareTag("ground")) 
        {
            if (isGrounded == false) 
            {
                isGrounded=true;
            }
        }
        // checks if player hits spikes
        if (collision.gameObject.CompareTag("spike"))
        {
            isAlive = false;
            Time.timeScale = 0;
        }
    }

    
}
