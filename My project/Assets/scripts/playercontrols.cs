using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class playercontrols : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed = 75;
    public float jumpForce;
    public Rigidbody rig;

    public int coinCount;

    void move()
    {
        // get the input axis
        float x = Input.GetAxis("Horizontal");

        float z = Input.GetAxis("Vertical");

        Vector3 rotation = Vector3.up * x;

        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        // calculate a direction relative to where we are facing
        Vector3 dir = (transform.forward * z + transform.right * x) * moveSpeed;

        dir.y = rig.velocity.y;

        //set that as our velocity
        rig.velocity = dir;

        rig.MoveRotation(rig.rotation * angleRot);

    }

    void Tryjump()
    {
        // create a ray facing down
        Ray ray = new Ray(transform.position, Vector3.down);

        //shoot the raycast
        if (Physics.Raycast(ray, 1.5f)) {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }







    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //inpute for movement
        move(); 

        //input for jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Tryjump();
        }
    }
}
