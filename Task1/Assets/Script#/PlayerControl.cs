using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    private Transform CubeTransform;
    public AudioSource m_Audio;

    private Rigidbody CubeRigidBody;
    //	private GameObject enemyScript;
    public bool isGrounded;
    public Animator m_animator;
    public int highCount;
    public GameObject InGame;


    public CharacterController mPlayercontroller;
    private Vector3 trgPost;
    private int count;
    public Text countText;
    public Text winText;
    //	public Transform GroundObject;
    public Text life, gameOver, highScore, currentScore;
    private Vector3 prevLoc;
    public GameObject gamePanel, winPanel;
    public static PlayerControl Instance;
    // Use this for initialization


    //Healthbar..........

    public Image currentHealthbar;

    public const float maxHealth = 100;

    public float currentHealth = maxHealth;

    bool isDamage;

    public bool GameOver;
    public bool isDown, isRight, isUp;

    public void Awake()
    {

        Debug.Log(PlayerPrefs.GetInt("audioKey"));

        m_Audio.volume = PlayerPrefs.GetFloat("volumeValue");


        Debug.Log("volume value. = " + m_Audio.volume);
    }

    void Start()
    {

        if (PlayerPrefs.GetInt("audioKey") == 0)
        {


            m_Audio.Stop();

        }
        GameObject.Find("enemy").SendMessage("SendMessageTest");
        Instance = this;

        InGame.SetActive(true);
        count = 0;
        SetCountText();

        CubeRigidBody = GetComponent<Rigidbody>();
        CubeTransform = GetComponent<Transform>();


        //		enemyScript = GameObject.FindWithTag ("enemy");

    }


    //	public bool Grounded;
    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < -6f)
        {


            currentHealthbar.fillAmount = 0;
            highScore.text = "Best score = " + PlayerPrefs.GetInt("highScore_key").ToString();
            GameOver = true;
            gamePanel.SetActive(true);
            Destroy(gameObject);


        }




        //			Debug.DrawLine (transform.position, GroundObject.position, Color.red);
        //		Grounded = Physics.Linecast (this.transform.position, GroundObject.position, 1 << LayerMask.NameToLayer ("Ground"));
        //		Debug.Log ("Grounded" + Grounded);


        if (isDown || (Input.GetKey(KeyCode.LeftArrow)))
        {

            //	left direction

            CubeTransform.Translate(Vector3.forward * 5f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 40f * Time.deltaTime);


        }
        if (isRight || (Input.GetKey(KeyCode.RightArrow)))
        {


            CubeTransform.Translate(Vector3.forward * 5f * Time.deltaTime);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), 40f * Time.deltaTime);

        }
        if (isUp && isGrounded || (Input.GetKey(KeyCode.Space)) && isGrounded)
        {
            CubeRigidBody.AddForce(new Vector3(0, 1.8f, 0), ForceMode.Impulse);

        }

        if (isRight || (Input.GetKey(KeyCode.RightArrow)) || isDown || (Input.GetKey(KeyCode.LeftArrow)))
        {

            m_animator.SetBool("isRUN", true);
        }
        else
        {


            m_animator.SetBool("isRUN", false);
        }
    }

    public void OnPointerLeftDown()
    {
        isDown = true;
        //this.downTime = Time.realtimeSinceStartup;
    }

    public void OnPointerLeftUp()
    {
        isDown = false;
    }


    public void OnPointerRightDown()
    {
        isRight = true;
        //this.downTime = Time.realtimeSinceStartup;
    }

    public void OnPointerRightUp()
    {
        isRight = false;
    }

    public void OnPointerJumpDown()
    {
        isUp = true;
        //this.downTime = Time.realtimeSinceStartup;
    }

    public void OnPointerJumptUp()
    {
        isUp = false;
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Platform")
        {

            isGrounded = true;


        }





    }


    public void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.name == "Platform")
        {
            Debug.Log("exit...");
            isGrounded = false;


        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("hammer"))
        {
            //			Debug.Log ("enemy hit .. ");
            float defeat = 1f;
            TakeDamage(defeat);






        }

        if (other.gameObject.CompareTag("bullet"))
        {

            float value = 1f;
            Debug.Log("bullet.....");
            other.gameObject.SetActive(false);
            TakeDamage(value);

        }

    }

    private void SetCountText()
    {
        countText.text = "Score      " + count.ToString();
        if (count >= 7)
        {
            winPanel.SetActive(true);
            winText.text = "You Win!!\n congratulations";
            gameObject.SetActive(false);

            GameObject.FindWithTag("enemy").SetActive(false);

        }
    }

    private void TakeDamage(float damage)
    {
        if (currentHealth != 0)
        {

            currentHealth -= damage;




            currentHealthbar.fillAmount = currentHealth / maxHealth;
            life.text = (currentHealthbar.fillAmount * 100).ToString();
        }
        else
        {
            GameOver = true;

            highCount = PlayerPrefs.GetInt("highScore_key");
            if (highCount < count)
            {


                PlayerPrefs.SetInt("highScore_key", count);

                highScore.text = "High score " + PlayerPrefs.GetInt("highScore_key").ToString();

                Debug.Log("HIghScore = " + PlayerPrefs.GetInt("highScore_key"));


            }

            currentScore.text = "Current score " + count.ToString();
            gamePanel.SetActive(true);
            highScore.text = "High score " + PlayerPrefs.GetInt("highScore_key").ToString();

            //			enemyScript.GetComponent<Test> ().enabled = false;
            Destroy(gameObject);
            gameOver.text = "Game Over";



        }

    }




}





