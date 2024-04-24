using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Audio clips
    public AudioClip damageTickSound;
    public AudioClip attackSound;
    public AudioClip deathBalloonSound;
    // Add more audio clips as needed

    // Reference to the AudioSource component
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If there's no AudioSource component, add one
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Method to play the damage tick sound
    public void PlayDamageTickSound()
    {
        if (damageTickSound != null)
        {
            audioSource.PlayOneShot(damageTickSound);
        }
        else
        {
            Debug.LogWarning("Damage tick sound clip not assigned!");
        }
    }

    public void PlayDamageBulletSound()
    {
        if (attackSound != null)
        {
            audioSource.PlayOneShot(attackSound);
        }
    }

    public void PlayBalloonDeathSound()
    {
        if(deathBalloonSound != null)
        {
            audioSource.PlayOneShot(deathBalloonSound);
        }
    }

    // Add more methods to play other audio clips as needed
}
