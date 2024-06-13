using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [HideInInspector] public Animator anim;
    private static HUD instance;
    public TMPro.TextMeshProUGUI interactText;
    public TMPro.TextMeshProUGUI itemNameText;


    public static HUD Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<HUD>();

                if (instance == null)
                {
                    Debug.LogError("No instance of HUD found in the scene.");
                }
            }

            return instance;
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void LostGame()
    {
        // SoundManager.Instance.PlayLostSound();
        // deadMenu.SetActive(true);
        Time.timeScale = 0.01f;
    }

    public void WonGame()
    {
    }

    public void Retry()
    {
        // int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        // SceneManager.LoadScene(currentSceneIndex);
    }
}
