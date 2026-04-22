using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public TextMeshProUGUI dialouge;
    public int targetCount;

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
            dialouge.text = ("Congratulations, you killed all your targets, Please press L to return to the menu");
        }
    }
}
