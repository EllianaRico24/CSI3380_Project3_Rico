using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;

    float xMove;
    float yMove;


    Rigidbody rb;

    int totalScore;

    public GameObject levelPassText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");

        if(transform.position.y <= -5f)
        {
            SceneManager.LoadScene(0);
        }
        
    }

    public void FixedUpdate() 
    {

        rb.AddForce(xMove * moveSpeed, 0, yMove * moveSpeed);
    }

    private void OnTriggerEnter(Collider other) 
    {
       if (other.tag == "Star")
       {
        totalScore++;
        other.gameObject.SetActive(false);
       }

       if (totalScore >= 11)
       {
        levelPassText.SetActive(true);
       }
    }
}
