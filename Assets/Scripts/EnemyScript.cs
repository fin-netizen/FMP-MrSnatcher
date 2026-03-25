using UnityEditor;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject player;
    //PlayerScript playerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerScript = GetComponent<PlayerScript>();
        print("player position=" + player.transform.position);
        print("my position=" + transform.position);
       
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
       // print("the distance is " + distance);
        if (distance >= 12)
        {
            
        }
    }
}
