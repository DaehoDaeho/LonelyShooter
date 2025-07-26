using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource bullet;
    public AudioSource hit;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayBullet()
    {
        bullet.Play();
    }

    public void PlayHit()
    {
        hit.Play();
    }
}
