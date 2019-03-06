using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    // floats
    public float radius;
    private float height;
    private float width;
    public float speed;
    private float randX;
    private float randY;

    // vectors 
    public Vector3 asterPos;            
    public Vector3 direction;                
    public Vector3 velocity;

    // cameras 
    public Camera cam;

    // Use this for initialization
    void Start () {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        asterPos = transform.position;  
        float randX = Random.Range(-width / 2, width / 2);
        float randY = Random.Range(-height / 2, height / 2);
        direction = new Vector3(randX, randY, 0);         
        velocity = new Vector3(0, 0, 0); 
        speed = 0.1f;
    }

    // Update is called once per frame
    void Update () {
        SetTransform();

        Drive();

        Wrap();

        DebugLines();
    }


    public void Drive()
    {

        velocity = speed * direction;

        asterPos += velocity* Time.deltaTime;
    }

    public void SetTransform()
    {
        transform.position = asterPos;
    }


    public void Wrap()
    {
        if (asterPos.y > height / 2)//top
        {
            asterPos.y = (asterPos.y - (height / 2)) + (-height / 2);
        }
        else if (asterPos.y < -height / 2)// bottom
        {
            asterPos.y = (height / 2) - ((-height / 2) - asterPos.y);
        }
        if (asterPos.x < -width / 2)// left
        {
            asterPos.x = (width / 2) - ((-width / 2) - asterPos.x);
        }
        else if (asterPos.x > width / 2) // right
        {
            asterPos.x = (asterPos.x - (width / 2)) + (-width / 2);
        }
    }
    void DebugLines()
    {
        // velociy debug line 
        Debug.DrawLine(asterPos, asterPos + (velocity * 3), Color.red);
        // direction debug line 
        Debug.DrawLine(asterPos, asterPos + (direction), Color.yellow);
        // position debug line 
        Debug.DrawLine(new Vector3(0, 0, 0), asterPos, Color.blue);
    }
}
