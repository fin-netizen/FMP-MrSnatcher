using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    InputAction exit;
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
        if (exit.IsPressed())
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
