using UnityEngine;

public class ascript : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();


        if (audioClip != null && audioSource != null)
        {

            audioSource.clip = audioClip;

            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioClip or AudioSource is not assigned!");
        }
    }
}
