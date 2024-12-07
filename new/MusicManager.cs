using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource;  // Поле для источника музыки
    public AudioSource sfxSource;    // Поле для источника звуковых эффектов

    void Start()
    {
        PlayMusic();  // Пример вызова метода, который может начать воспроизведение музыки
    }

    public void PlayMusic()
    {
        if (musicSource != null && !musicSource.isPlaying)
        {
            musicSource.Play(); // Воспроизводим музыку, если источник установлен и не играет
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (sfxSource != null)
        {
            sfxSource.PlayOneShot(clip); // Воспроизводим звук эффекта
        }
    }
}