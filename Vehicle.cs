using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{

    // Unnecessary
    //public float speed;                       // Speed of the vehicle, not needed anymore

    // Necessary
    public float accelRate;                     // Small, constant rate of acceleration
    public Vector3 vehiclePosition;             // Local vector for movement calculation
    public Vector3 direction;                   // Way the vehicle should move
    public Vector3 velocity;                    // Change in X and Y
    private Vector3 acceleration;                // Small accel vector that's added to velocity
    public float angleOfRotation;               // 0 
    public float maxSpeed;                      // 0.5 per frame, limits mag of velocity
    public Camera cam;
    private float height;
    private float width;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        vehiclePosition = new Vector3(0, 0, 0);     // Or you could say Vector3.zero
        direction = new Vector3(1, 0, 0);           // Facing right
        velocity = new Vector3(0, 0, 0);            // Starting still (no movement)
        // Make a note of the time the script started.
    }

    // Update is called once per frame
    void Update()
    {
        RotateVehicle();

        Drive();

        SetTransform();

        Wrap();

        DebugLines();
    }

    /// <summary>
    /// Changes / Sets the transform component
    /// </summary>
    public void SetTransform()
    {
        // Rotate vehicle sprite
        transform.rotation = Quaternion.Euler(0, 0, angleOfRotation-90);

        // Set the transform position
        transform.position = vehiclePosition;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Drive()
    {
        // Accelerate
        // Small vector that's added to velocity every frame
        if (Input.GetKey(KeyCode.UpArrow))
        {
            acceleration = accelRate * direction;
            // We used to use this, but acceleration will now increase the vehicle's "speed"
            // Velocity will remain intact from one frame to the next
            velocity += acceleration;
            //vehiclePosition += velocity;
        }
        //if(Input.GetKeyUp(KeyCode.UpArrow))
        else
        {
            velocity = velocity * 0.99f;
        }
        // Add velocity to vehicle's position
        vehiclePosition += velocity*Time.deltaTime*50;
        // Limit velocity so it doesn't become too large
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
    }

    public void RotateVehicle()
    {
        // Player can control direction
        // Left arrow key = rotate left by 2 degrees
        // Right arrow key = rotate right by 2 degrees
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            angleOfRotation += 2;
            direction = Quaternion.Euler(0, 0, 2) * direction;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            angleOfRotation -= 2;
            direction = Quaternion.Euler(0, 0, -2) * direction;
        }
    }
    public void Wrap()
    {
        if (vehiclePosition.y > height / 2)//top
        {
            vehiclePosition.y = (vehiclePosition.y - (height / 2)) + (-height / 2);
        }
        else if (vehiclePosition.y < -height / 2)// bottom
        {
            vehiclePosition.y = (height / 2) - ((-height / 2) - vehiclePosition.y);
        }
        if (vehiclePosition.x < -width / 2)// left
        {
            vehiclePosition.x = (width / 2) - ((-width / 2) - vehiclePosition.x);
        }
        else if (vehiclePosition.x > width / 2) // right
        {
            vehiclePosition.x = (vehiclePosition.x - (width / 2)) + (-width / 2);
        }
    }
    void DebugLines()
    {
        // velociy debug line 
        Debug.DrawLine(vehiclePosition,vehiclePosition + (velocity *3), Color.red);
        // direction debug line 
        Debug.DrawLine(vehiclePosition, vehiclePosition + (direction), Color.yellow);
        // position debug line 
        Debug.DrawLine(new Vector3(0,0,0), vehiclePosition, Color.blue);
    }
}
