using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpspeed;
    public float sofaspeed;
    public float sofajumpspeed;
    //public float rotationSpeed;
    public Text countText;
    public Text winText;
    public Text liveText;

    private AudioSource coinaudio;
    private AudioSource jumpaudio;
    private AudioSource hitaudio;
    private AudioSource exploaudio;
    private AudioSource bounce;
    private AudioSource bett;
    private int score;
    private int live; 
    private bool canstillsteer;
    private bool cansteer;
    private bool sofastillsteer;
    private bool sofasteer;

    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        AudioSource[] audios = GetComponents<AudioSource>();
        coinaudio = audios[0];
        jumpaudio = audios[1];
        hitaudio = audios[2];
        exploaudio = audios[3];
        bounce = audios[4];
        bett = audios[5];
    }
    void Start()
    {
        score = 0;
        live = 3;
        SetScoreText();
        SetLiveText();
        winText.text = "";
        canstillsteer = false;
        cansteer = false;
        sofastillsteer = false;
        sofasteer = false;

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (cansteer && Input.GetKeyDown("space"))
        {
            rb.AddForce(Vector3.up * jumpspeed * Time.deltaTime);
            jumpaudio.Play();
        }

        if (cansteer)
        {
            rb.AddForce(movement * speed * Time.deltaTime);
        }

        if (sofasteer && Input.GetKeyDown("space"))
        {
            rb.AddForce(Vector3.up * sofajumpspeed * Time.deltaTime);
            jumpaudio.Play();
        }

        if (sofasteer)
        {
            rb.AddForce(movement * sofaspeed * Time.deltaTime);
        }

    }
    void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "PickUp") {
            coinaudio.Play();
			other.gameObject.SetActive (false);
			score = score + 10;
			SetScoreText();
		}
        else if (other.gameObject.tag == "Goal")
        {
            winText.text = "You Win! Your Score was: " + score.ToString();
            SceneManager.LoadScene("win");
        }
        else if (other.gameObject.tag == "Lava")
        {
            hitaudio.Play();
            SceneManager.LoadScene("lost");
        }
        
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            bounce.Play();
            if (cansteer)
            {
                canstillsteer = true;
            }
            cansteer = true;
        }
        else if (collision.gameObject.CompareTag("Sofa"))
        {
            bett.Play();
            if (sofasteer)
            {
                sofastillsteer = true;
            }
            sofasteer = true;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            live = live - 1;
            hitaudio.Play();
            SetLiveText();
            if(live < 0)
            {
                SceneManager.LoadScene("lost");
            }
        }
        else if(collision.gameObject.tag == "rocket")
        {
            live = live - 1;
            hitaudio.Play();
            exploaudio.Play();
            SetLiveText();
            if (live < 0)
            {
                SceneManager.LoadScene("lost");
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            if (canstillsteer)
            {
                canstillsteer = false;
            }
            else
            {
                cansteer = false;
            }
         
        }
        else if (collision.gameObject.CompareTag("Sofa"))
        {
            if (sofastillsteer)
            {
                sofastillsteer = false;
            }
            else
            {
                sofasteer = false;
            }

        }
    }

    private void SetScoreText()
    {
        countText.text = "Score: " + score.ToString();
    }

    private void SetLiveText()
    {
        liveText.text = "Lives: " + live.ToString();
    }
}
    /*
    public float speed;
    public float jumpspeed;
    public float rotationSpeed;

    public Camera ca;

    private Rigidbody rb;
    private Transform tr;
    
    private int score;
    private bool canjump;
    private bool cansteer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        score = 0;
        canjump = false;
        cansteer = false;
    }

    private void FixedUpdate()
    {
        
        /*
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        //transform.Translate(0, 0, z);
        
        //float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);
        //Vector3 rotation = new Vector3(0.0f, 0.0f, rotateVertical);

        if (canjump && Input.GetKeyDown("space"))
        {
            rb.AddForce(Vector3.up * jumpspeed);
        }

        if (cansteer)
        {
            rb.AddRelativeForce(movement * speed);
        }
        
        if (cansteer && Input.GetKey("a"))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        else if (cansteer && Input.GetKey("d"))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false); //Destroy(other.gameObject);
            score = score + 10;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canjump = true;
            cansteer = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canjump = false;
            cansteer = false;
        }
    }
*/

