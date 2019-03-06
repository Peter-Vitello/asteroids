using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour {

    public List<GameObject> planetList;
    public GameObject planets;
    //public GameObject mars;
    public int planetSize;
    private Camera cam;
    private float height;
    private float width;

    // Use this for initialization
    void Start () {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        planetSize = 9;
        for (int i = 0; i < planetSize; i++)
        {
            float randX = Random.Range(-width / 2, width / 2);
            float randY = Random.Range(-height / 2, height / 2);
            planetList.Add(Instantiate(planets,new Vector3(randX,randY),Quaternion.identity));
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
