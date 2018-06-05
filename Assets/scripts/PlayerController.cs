using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    //public GUIText countText;
    //public GUIText winText;
    private int count;
    private Rigidbody rb;

    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        //SetCountText();
        //winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = Camera.main.transform.TransformDirection(movement);

        rb.AddForce(movement * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count = count + 1;
           // SetCountText();
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
}
