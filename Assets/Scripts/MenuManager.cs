using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //play the music

        AudioManager.instance.Play("music", 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        print("sfx vol=" + AudioManager.instance.sfxVol);
        print("music vol=" + AudioManager.instance.musicVol);


        AudioManager.instance.ChangeAudioSourceVolume("music", AudioManager.instance.musicVol);
        AudioManager.instance.ChangeAudioSourceVolume("sfx", AudioManager.instance.sfxVol);

       // AudioManager.instance.sfxVol = 1;
        if( UnityEngine.InputSystem.Keyboard.current.wKey.wasPressedThisFrame )
        {
            AudioManager.instance.Play("sfx1", AudioManager.instance.sfxVol);
        }



    }
}
