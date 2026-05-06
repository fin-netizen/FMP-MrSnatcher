using UnityEngine;
using TMPro;
using UnityEngine.Audio; 
public class SliderScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sliderText = null;
    public AudioMixer mixer;
    [SerializeField] private float maxSliderAmount = 100.0f;
    float musicVol, sfxVol;

    public void MusicSliderChange(float value)
    {
        AudioManager.instance.musicVol = value;
        float localValue = value * maxSliderAmount;
        sliderText.text = localValue.ToString("0");
        PlayerPrefs.SetFloat("Music", AudioManager.instance.musicVol);
        mixer.SetFloat("MusicVol", Mathf.Log10(AudioManager.instance.musicVol) * 20);
    }
    public void SfxSliderChange(float value)
    {
        AudioManager.instance.sfxVol = value;
        float localValue = value * maxSliderAmount;
        sliderText.text = localValue.ToString("0");
        PlayerPrefs.SetFloat("Sfx", AudioManager.instance.sfxVol);
        mixer.SetFloat("sfxVol", Mathf.Log10(AudioManager.instance.sfxVol) * 20);
    }
  
    public void PlayMusic(string musicName, float vol)
    {
       AudioManager.instance.Play(musicName, vol);
    }
    public void PlaySfx(string sfxName, float vol)
    {
       AudioManager.instance.Play(sfxName, vol);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
