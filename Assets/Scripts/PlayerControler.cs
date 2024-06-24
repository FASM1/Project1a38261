using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float horsePower = 0;
    //[SerializeField] float speed = 20.0f;
    [SerializeField] float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    //[SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //playerRb.centerOfMass = centerOfMass.transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        //Moves the car forward based on vertical inputt
        //transform.Translate(Vector3.forward * Time.deltaTime * speed *forwardInput);
        playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
        // Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);// 3.6 for kph
        speedometerText.SetText("Speed" + speed + "kmh");
    }
}
