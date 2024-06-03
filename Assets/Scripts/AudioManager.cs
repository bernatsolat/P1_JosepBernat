using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source -------- ")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Audio Clip -------- ")]
    public AudioClip background;
    public AudioClip attack;
    public AudioClip enemyDamaged;
    public AudioClip playerDamaged;
    public AudioClip background2;
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
