using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public float radius;
    public float bullet;

    // bound variables
    private Camera cam;
    private float height;
    private float width;

    //lists;
    private List<GameObject> bullets;

    // gameobjects
    public GameObject ship;

    // Use this for initialization
    void Start () {

        bullets = ship.GetComponent<Ship>().BulletsList;
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
        if (transform.position.y > height / 2 || transform.position.x > width / 2 || transform.position.x < -width / 2 || transform.position.y < -height / 2)//top
        {
            Destroy(gameObject);
        }
        if (bullets.Count > 5) // ditermines my amount of bullets on screen
        {
            int over = bullets.Count - 5;
            for (int i = 0 ; i < over; i++)
            {
                //Destroy(bullets[i].gameObject);
                bullets.Remove(bullets[i]);
            }
        }
    }

}
