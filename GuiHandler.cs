using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiHandler : MonoBehaviour {

    // gameobjects 
    public GameObject healthMusk;
    private List<GameObject> musk;

	// Use this for initialization
	void Start () {
        float pos = transform.position.x;
        for (int i = 0; i < 3; i++)
        {
            musk.Add(Instantiate(healthMusk, new Vector3(pos, transform.position.y), Quaternion.identity));
            pos += .5f;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
