using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public Camera camera;
    public GameObject asteroid;
    public float edgeMargin;
    public Vector2 screenBounds;
    public Vector2 screenSize;
    public Vector3 mousePoint;
    private GameObject[] asteroids;
    private bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Camera.main.transform.position.z, Screen.height));
        screenBounds = Camera.main.ScreenToViewportPoint(player.transform.position);
        screenSize = new Vector2(Screen.width, Screen.height);
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        //spawn(asteroid);
    }
    public void spawn(GameObject go)
    {
        Vector3 spawnPosition = new Vector3(-mousePoint.x, 0.0f, Random.Range(-mousePoint.z-edgeMargin, mousePoint.z+edgeMargin));
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(go, spawnPosition, spawnRotation);
    }
    void findScreenBounds()
    {
        // this creates a horizontal plane passing through this object's center
        Plane plane = new Plane(Vector3.up, new Vector3(0, 0, 0));
        // create a ray from the mousePosition
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width, Screen.height, 0));
        // plane.Raycast returns the distance from the ray start to the hit point
        float distance;
        //plane.Raycast(ray, distance);
        if (plane.Raycast(ray, out distance))
        {
            // some point of the plane was hit - get its coordinates
            mousePoint = ray.GetPoint(distance);
            //ray.GetPoint(distance);
            // use the hitPoint to aim your cannon
        }
    }
    // Update is called once per frame
    void Update()
    {
        findScreenBounds();
        if (!spawned)
        {
            spawn(asteroid);
            spawn(asteroid);
            spawned = true;
        }
    }

    private void HandleDoughnutSpace()
    {
        GameObject[] spaceObjects = GameObject.FindGameObjectsWithTag("SpaceObject");
        foreach(GameObject go in spaceObjects)
        {
            if (go.transform.position.x > mousePoint.x + edgeMargin)
                go.transform.position = new Vector3(-mousePoint.x, 0, go.transform.position.z);
            if (go.transform.position.x < -mousePoint.x - edgeMargin)
                go.transform.position = new Vector3(mousePoint.x, 0, go.transform.position.z);
            if (go.transform.position.z < -mousePoint.z - edgeMargin)
                go.transform.position = new Vector3(go.transform.position.x, 0, mousePoint.z);
            if (go.transform.position.z > mousePoint.z + edgeMargin)
                go.transform.position = new Vector3(go.transform.position.x, 0, -mousePoint.z);
        }
    }
    private void LateUpdate()
    {
        Vector3 viewPos = player.transform.position;
        HandleDoughnutSpace();
      
       
    }
}
