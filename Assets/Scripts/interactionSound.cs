using UnityEngine;


public class interactionSound : MonoBehaviour 
{

	public static interactionSound instance;
	private AudioSource audioSource;
	
	void Awake () 
	{
		instance = this;
		audioSource = this.GetComponent<AudioSource>();
	}
	
	public void SetAudioPlay(int level)
	{
		audioSource.pitch = level;
		audioSource.Play();
	}
}
