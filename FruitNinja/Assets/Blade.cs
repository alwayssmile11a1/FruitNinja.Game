using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

    //PUBLIC VARIABLES
    public GameObject bladeTrailPrefab;
    public float minCuttingVelocity = 0.001f;

    //PRIVATE VARIABLES
    //this variable lets us know the mouse is holding or not
    bool isCutting = false;
    //link to the blade object
    Rigidbody2D rb;
    //link to cam
    Camera cam;
    GameObject currentBladeTrail;
    CircleCollider2D circleCollider;
    Vector2 previousPosition;



    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        //previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0))
        {
            //Start Cutting
            StartCutting();
        }
        else
        {
            if(Input.GetMouseButtonUp(0))
            {
                //Stop Cutting
                StopCutting();
            }
        }

        if(isCutting)
        {
            UpdateCutting();
        }
	}

    void StartCutting()
    {
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled = false;
    }

    void StopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 1f);
        circleCollider.enabled = false;
    }

    void UpdateCutting()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        float velocity = (newPosition - previousPosition).magnitude / Time.deltaTime;
        if(velocity>minCuttingVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }

        previousPosition = newPosition;
    }


}
