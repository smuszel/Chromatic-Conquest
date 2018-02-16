using UnityEngine;

[CreateAssetMenu]
public class SoundEffect : ScriptableObject
{

    public AudioClip clip;
    [Range(0f, 100f)]
    public float volume = 100f;
	[Range(0f, 400f)]
    public float pitch = 100f;
    AudioSource src;

    public void Execute()
	{
        src = AudioManager.VacantSourceRequest();
        
        src.clip = clip;
        src.volume = volume/100;
        src.pitch = pitch/100;
        src.Play();
    }

    public void Execute(AudioSource provided)
    {
        provided.clip = clip;
        provided.volume = volume / 100;
        provided.pitch = pitch / 100;
        provided.Play();
    }
}
