using UnityEngine;

public static class AudioManager
{
    public static int totalSources = 15;

    public static readonly string soundBoxName = "SoundBox";

    public static AudioSource backgroundSource;

    public static AudioSource[] sharedSources = new AudioSource[totalSources];

    public static GameObject soundBox;
    public static void EnsureAudioPresence() 
	{
        backgroundSource = soundBox?.GetComponent<AudioSource>();
        
        if (soundBox == null)
        {
            Debug.Log(soundBoxName + " not found, loading one");
            soundBox = Object.Instantiate(Resources.Load(soundBoxName), Vector3.zero, Quaternion.identity) as GameObject;
            backgroundSource = soundBox.GetComponent<AudioSource>();

            PopulateSources(soundBox);
            Object.DontDestroyOnLoad(soundBox);
        }
    }

    public static void PopulateSources(GameObject go)
    {
        for (int i = 0; i < totalSources; i++)
        {
            sharedSources[i] = go.AddComponent<AudioSource>();
        }
    }
    public static void StopBackgroundRequest()
    {
        EnsureAudioPresence();
        backgroundSource.Stop();
    }

    public static void PlayBackgroundRequest()
    {
        EnsureAudioPresence();

        if (!backgroundSource.isPlaying)
        {
            backgroundSource.Play();
        }
    }

    public static AudioSource VacantSourceRequest()
    {
        EnsureAudioPresence();
        foreach (AudioSource src in sharedSources)
        {
            if (!src.isPlaying)
            {
                return src;
            }
        }

        Debug.Log("Provided amount of source was too small passing oldest");
        return sharedSources[0];
    }
}
