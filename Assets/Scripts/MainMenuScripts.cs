using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScripts : MonoBehaviour
{


    public GameObject MainMenu;
    public GameObject HowToPlay;
    public GameObject Settings;
    public GameObject SettingsBtn;
    public GameObject Credits;

    public AudioSource gameAudio;
    public AudioClip clip;

    public Animator settingsAnimator;
    public GameObject FadePanel;
    public GameObject overlayPanel;

    // Start is called before the first frame update
    void Start()
    {
        FadeIn();
        MainMenu.SetActive(true);
        HowToPlay.SetActive(false);
        Settings.SetActive(false);
        Credits.SetActive(false);

        gameAudio.Play();

        Debug.Log("Start() Called");
    }


    public void SettingsBtnClickd()
    {
        PlayButtonSound();
        overlayPanel.SetActive(true);
        Settings.SetActive(true);
        SettingsBtn.SetActive(false);
        settingsAnimator.SetTrigger("Slide-In");
        
        Debug.Log("SettingsBtnClickd() Called");
    }
    
    public void HowToPlayBtnClickd()
    {
        MainMenu.SetActive(false);
        HowToPlay.SetActive(true);
        Debug.Log("HowToPlayBtnClickd() Called");
        PlayButtonSound();
    }

    
    public void CreditsBtnClickd()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(true);
        Debug.Log("CreditsBtnClickd() Called");
        PlayButtonSound();
    }


    public void BackBtnClicked()
    {
        MainMenu.SetActive(true);
        HowToPlay.SetActive(false);
        // Settings.SetActive(false);
        settingsAnimator.SetTrigger("Slide-Out");
        // Invoke("DisableSettingsPanel",1);
        StartCoroutine(DisableSettingsPanel());
        Credits.SetActive(false);
        PlayButtonSound();
    }
    
    public IEnumerator DisableSettingsPanel()
    {
        yield return new WaitForSeconds(1);
        Settings.SetActive(false);
        SettingsBtn.SetActive(true);
    }

    public void PlayBtnClicked()
    {
        FadeOut();
        StartCoroutine(LoadLevelWithDelay());
    }

    IEnumerator LoadLevelWithDelay()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("CalculatorScene");
    }

    public void PlayButtonSound()
    {
        gameAudio.PlayOneShot(clip);
    }

    public void StartSound()
    {
        gameAudio.Play();
        Debug.Log("Trying the sound");
    }

    void FadeIn()
    {
        FadePanel.GetComponent<Animator>().SetTrigger("Fade-in");
    }

    void FadeOut()
    {
        FadePanel.GetComponent<Animator>().SetTrigger("Fade-out");
    } 

    
}
