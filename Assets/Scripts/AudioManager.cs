using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource playerBullet;
    public AudioSource hitEnemy;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayPlayerBullet()
    {
        playerBullet.Play();
    }

    public void PlayHitEnemy()
    {
        hitEnemy.Play();
    }
}
