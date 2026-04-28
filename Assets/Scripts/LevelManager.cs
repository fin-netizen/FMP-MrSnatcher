using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public TextMeshProUGUI dialouge;
    public int targetCount;
    public float endTimer = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        targetCount = 0;

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


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print("target count=" + targetCount);
        print("Current target count is " + targetCount);
        dialouge.text = ("Current target count is " + targetCount);
        if(targetCount == 0)
        {
            endTimer -= Time.deltaTime;
            dialouge.text = ("Congratulations, you killed all your targets, now let's get you back to the menu");
            if(endTimer <= 0)
            {
                SceneManager.LoadScene("Menu");
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
