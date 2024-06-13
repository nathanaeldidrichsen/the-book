using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource musicAudioSource;

    public AudioClip doorSound;
    public float doorVol;
    public AudioClip enemyHurtSound;
    public float enemyHurtVol;

    public AudioClip flashlightSound;
    public float flashlightVol;

    public List<AudioClip> footStepSounds;
    public float footStepVol;

    public AudioClip pickupSound;
    public float pickupVol;
    public List<AudioClip> typewriterSounds; // List to hold multiple typewriter sound clips
    public float typewriterVol;

        public AudioClip castleSound;
    public float castleVol;

            public AudioClip wonSound;
    public float wonVol;
                public AudioClip lostSound;
    public float lostVol = 0.3f;

                    public AudioClip worldMapUpgradeTowerSound;
    public float worldMapUpgradeTowerVol = 0.3f;




    [HideInInspector] public AudioSource audioSource; //A primary audioSource a large portion of game sounds are passed through
    private static SoundManager instance;

    // Public property to access the instance
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();

                if (instance == null)
                {
                    Debug.LogError("No instance of GameManager found in the scene.");
                }
            }

            return instance;
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayTypewriterSound()
    {
        // Select a random clip from the list
        AudioClip clipToPlay = typewriterSounds[Random.Range(0, typewriterSounds.Count)];
        
        // Set a random pitch variation
        audioSource.pitch = 1.0f + Random.Range(-0.1f, 0.1f);

        // Play the selected clip with the specified volume and pitch
        audioSource.PlayOneShot(clipToPlay, typewriterVol);
    }
    public void PlayWorldMapUpgradeTower()
    {
        audioSource.PlayOneShot(worldMapUpgradeTowerSound, worldMapUpgradeTowerVol);
    }
        public void PlayCastleSound()
    {
        audioSource.PlayOneShot(castleSound, castleVol);
    }

            public void PlayWonSound()
    {
        audioSource.PlayOneShot(wonSound, wonVol);
    }

                public void PlayLostSound()
    {
        musicAudioSource.enabled = false;
        audioSource.PlayOneShot(lostSound, lostVol);
    }


    public void PlayPickupSound()
    {
        audioSource.PlayOneShot(pickupSound, pickupVol);
    }

    public void PlayFlashlightSound()
    {
        audioSource.PlayOneShot(flashlightSound, flashlightVol);
    }

    public void PlayFootstepSound(float pitchVariation)
    {
        if (footStepSounds.Count == 0)
        {
            Debug.LogWarning("No footstep audio clips assigned!");
            return;
        }

        int randomIndex = Random.Range(0, footStepSounds.Count);
        AudioClip clip = footStepSounds[randomIndex];

        audioSource.pitch = 1f + Random.Range(-pitchVariation, pitchVariation);
        audioSource.PlayOneShot(clip, footStepVol);
    }

    public void PlayShootSound()
    {
         audioSource.PlayOneShot(doorSound, doorVol);
    }

        public void PlayHurtSound()
    {
        audioSource.PlayOneShot(enemyHurtSound, enemyHurtVol);
    }
}
