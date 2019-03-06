using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {
    // Use this for initialization
    public GameObject planets;
    public GameObject ship;
    //public List<GameObject> planetList;
    
    public PlanetManager Planet;



    // list
    private List<GameObject> bullets;


    void Start () {
        bullets = ship.GetComponent<Ship>().BulletsList;
    }
	
	// Update is called once per frame
	void Update () {
        bool shipCollide = false;
        for (int i = 0; i < Planet.planetList.Count; i++)
        {
            bool isColliding; 
           
            isColliding = CircleCollision(ship, Planet.planetList[i], ship.GetComponent<Ship>().radius+ Planet.planetList[i].GetComponent<Planet>().radius);
           
            if (isColliding) // changes color of planets accordinglly
            {
                shipCollide = isColliding;
                Planet.planetList[i].GetComponent<SpriteRenderer>().color = Color.red;
                ship.GetComponent<Ship>().health -= 1;
            }
            else
            {
                ship.GetComponent<SpriteRenderer>().color = Color.white;
                Planet.planetList[i].GetComponent<SpriteRenderer>().color = Color.white;
            }
            if (shipCollide)
            {
                ship.GetComponent<SpriteRenderer>().color = Color.red;
            }

        }
        for (int i = 0; i < Planet.planetList.Count; i++)
        {
            for (int j = 0; j < bullets.Count; j++)
            {
                bool isColliding;
                isColliding = CircleCollision(bullets[j], Planet.planetList[i], bullets[j].GetComponent<Bullet>().radius + Planet.planetList[i].GetComponent<Planet>().radius);

                if (isColliding) // changes color of planets accordinglly
                {
                    Planet.planetList[i].GetComponent<SpriteRenderer>().color = Color.red;
                    bullets[j].GetComponent<SpriteRenderer>().color = Color.red;
                    Debug.Log(isColliding);
                }
            }
        }

	}

    public bool CircleCollision(GameObject obj1 , GameObject obj2, float totalRadius)
    {
       Vector3 distance = (obj1.transform.position - obj2.transform.position);
       if (distance.magnitude<=totalRadius)
       {
            return true;
       }
       else
       {
            return false;
       }
    }
}
