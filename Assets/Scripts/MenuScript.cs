using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    InputAction exit;
    public TextMeshProUGUI dialogue;
    int targetCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        exit = InputSystem.actions.FindAction("Exit");

        if (exit == null)
        {
            print("didn't find exit action");
        }
        else
        {
            print("found exit action");

        }
    }

    // Update is called once per frame
    void Update()
    {
        //read text from level manager and output to dialogue text

        /*
        if (LevelManager.instance == null)
        {
            print("lm is null");
        }
        else
        {
            dialogue.text = LevelManager.instance.dialogueText;
        }
        */


        if (exit.IsPressed())
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
