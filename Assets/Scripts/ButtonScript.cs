using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    InputAction exit;
    [SerializeField] private string resetGameLevel = "level";
    public void ResetButton()
    {
        SceneManager.LoadScene(resetGameLevel);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        exit = InputSystem.actions.FindAction("Exit");

        if( exit == null )
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
        if (exit.triggered)
        {
            LeaveGame(name);
        }
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LeaveGame(string name)
    {
        if(exit.triggered)
        {
            SceneManager.LoadScene(name);

        }
    }
}
