using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    public float radius;
    public float rateOfFire;
    public float fireTimer;
    public int health;
    public int score;
    public GameObject bulletObj;
    private GameObject bullet;
    private Bullet bullets;
    List<GameObject> bulletsList;

    // Use this for initialization
    void Start () {
        bulletsList = new List<GameObject>();
        health = 3;
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        fireTimer += Time.deltaTime*20;
        if (Input.GetKeyDown(KeyCode.Space)&& fireTimer>rateOfFire)
        {
            bullet = Instantiate(bulletObj, transform.position, transform.rotation);
            bulletsList.Add(bullet);
            fireTimer = 0f;
        }
        if (health<=0)
        {
            transform.gameObject.GetComponent<Vehicle>().velocity = Vector3.zero;
        }
	}

    public List<GameObject> BulletsList
    {
        get { return bulletsList; }
        set { bulletsList = value; }
    }
}
