using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpspeed;
    public float rotationSpeed;
    public Text countText;
    public Text winText;
    public Text liveText;
    
    private int score;
    private int live; 
    private bool canjump;
    private bool cansteer;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        live = 3;
        SetScoreText();
        SetLiveText();
        winText.text = "";
        canjump = false;
        cansteer = false;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (canjump && Input.GetKeyDown("space"))
        {
            rb.AddForce(Vector3.up * jumpspeed * Time.deltaTime);
        }

        if (cansteer)
        {
            rb.AddForce(movement * speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive (false);
			score = score + 10;
			SetScoreText();
		}
        else if (other.gameObject.tag == "Goal")
        {
            winText.text = "You Win! Your Score was: " + score.ToString();
        }
        
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canjump = true;
            cansteer = true;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            live = live - 1;
            SetLiveText();
            if(live < 0)
            {
                //YOU LOSE!
            }
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

