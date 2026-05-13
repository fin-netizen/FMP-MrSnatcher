using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    
    [SerializeField] private string resetGameLevel = "level";
    public Button button;
    public void ResetButton()
    {
        SceneManager.LoadScene(resetGameLevel);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clicked();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void clicked()
    {
        button.Select();
    }
}
