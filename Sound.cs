using UnityEngine;

public class Sound : MonoBehaviour 
{
    public AudioClip rainingThunder;
    public AudioClip lightningStrike;

	// Use this for initialization

    void Awake()
    {
        audio.clip = rainingThunder;
        audio.Play();
        audio.loop = true;
       
    }
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButton(0))
        {
            if (audio.clip == rainingThunder)
            {
                audio.loop = false;
                audio.clip = lightningStrike;
                audio.volume = 0.2F;
                audio.Play();
                audio.volume = 1;
            }
        }

        if (!audio.isPlaying)
        {
            audio.clip = rainingThunder;
            audio.loop = true;
            audio.Play();
        }
	}
}
