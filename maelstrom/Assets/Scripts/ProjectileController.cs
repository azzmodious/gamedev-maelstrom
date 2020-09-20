using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed;
    public float ttl;
    public float startTime;
    public GameObject GameManager; 
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if(Time.time > startTime + ttl)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + " was hit by a bullet");       
           if(other.gameObject.tag == "SpaceObject")
            {
                GameController controller = (GameController)GameManager.GetComponent(typeof(GameController));
                controller.HandleAsteroidHit(other.gameObject);
                Destroy(gameObject);
                Destroy(other.gameObject);
           
            }
            
        
       
    }
}
