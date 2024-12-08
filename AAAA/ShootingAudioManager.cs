using UnityEngine;

public class ShootingAudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource shootingAudioSource; // Аудиоисточник для выстрела

    // Метод для воспроизведения звука выстрела
    public void PlayShootingSound()
    {
        if (shootingAudioSource != null)
        {
            shootingAudioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource не назначен в AudioManager!");
        }
    }
}
