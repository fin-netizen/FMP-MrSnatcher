using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //public static LevelManager instance;
    //public TextMeshProUGUI dialouge;

    public string dialogueText;
    
    public int targetCount;
    public float endTimer = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {


        /*
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            //this code runs only once
            //read player prefs values and store them in AudioManager.instance.musicVol


            print("Init levelmanager");


            print("do not destroy");




        }
        else
        {
            print("do destroy");
            Destroy(gameObject);
            return;
        }
        */


    }
    void Start()
    {
        //count how many enemies are in the scene
        // update target count with the result


        
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FindEnemies();
    }


    void FindEnemies()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        print("target count = " + enemies.Length);
        targetCount = enemies.Length;


        print("target count=" + targetCount);
        print("Current target count is " + targetCount);
        dialogueText = ("Current target count is " + targetCount);
        if (targetCount == 0)
        {
            endTimer -= Time.deltaTime;
            dialogueText = ("Congratulations, you killed all your targets, now let's get you back to the menu");
            if (endTimer <= 0)
            {

                if ( SceneManager.GetActiveScene().name == "Level1" )
                {
                    SceneManager.LoadScene("Level2");
                    return;
                }
                if (SceneManager.GetActiveScene().name == "Level2")
                {
                    SceneManager.LoadScene("Menu");
                }


                endTimer = 5;
            }

        }
    }


    public void TargetCount(int targetCount)
    { 

    }
    void Level1()
    {

    }
    void Level2()
    {

    }
}
