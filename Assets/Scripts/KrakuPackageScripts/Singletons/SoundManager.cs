using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
	[Header("AudioSources")]
	public AudioSource _aSourceSFX, _aSourceMusic;
	float _originalpitch=0.9f;
	public float _sfxVolume;
	static public SoundManager Instance { get; private set; }
	public List<AudioClipStruct> _soundEffects = new List<AudioClipStruct>();
	[Header("Listof sound effect clips")]
	Dictionary<string, AudioClip> _soundEffectsDict = new Dictionary<string, AudioClip>();
	
	[System.Serializable]
	public struct AudioClipStruct
	{
		public string name;
		public AudioClip clip;
	}
	private void Update()
	{
		_aSourceSFX.outputAudioMixerGroup.audioMixer.SetFloat("SFXCompleteSFXVolume", _sfxVolume); 
	}
	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		
		Instance = this;
		DontDestroyOnLoad(gameObject);
		GenerateSoundEffectDict();
	}
	private void OnEnable()
	{
		SceneManager.sceneLoaded += StartBasicSceneMusic;
	}
	void StartBasicSceneMusic(Scene scene, LoadSceneMode loadSceneMode)
	{
		switch (scene.buildIndex)
		{
			case 0:
				ChangeMusic("MainMenuMusic");
				break;
			case 1:
				ChangeMusic("GameMusic");
				break;
			case 2:
				ChangeMusic("EndSceneMusic");
				break;
			default:
				ChangeMusic("GameMusic");
				break;
		}
	}
	void GenerateSoundEffectDict()
	{
		foreach (AudioClipStruct audioClip in _soundEffects)
		{
			_soundEffectsDict.Add(audioClip.name, audioClip.clip);
		}
	}
	public void PlaySoundEffect(string clipName , float pitch=1,float volume=0)
	{
		_aSourceSFX.outputAudioMixerGroup.audioMixer.SetFloat("SFXCompleteSFXPitch",pitch);
		_aSourceSFX.outputAudioMixerGroup.audioMixer.SetFloat("SFXCompleteSFXVolume", volume);
		_aSourceSFX.PlayOneShot(_soundEffectsDict[clipName]);
	}
	public void ChangeMusicPitch(float pitch)
	{
		_aSourceMusic.outputAudioMixerGroup.audioMixer.SetFloat("MusicCompleteMusicPitch", pitch);
		_originalpitch = pitch;
	}
	public void ChangeMusic(string clipName,float pitch=1,float volume=0)
	{
		_aSourceMusic.outputAudioMixerGroup.audioMixer.SetFloat("MusicCompleteMusicPitch", pitch);
		_aSourceMusic.outputAudioMixerGroup.audioMixer.SetFloat("MusicCompleteMusicVolume", volume);
		_aSourceMusic.clip = _soundEffectsDict[clipName];
		_aSourceMusic.Play();
	}
	public void lowerMusicPitch(float duration)
	{
		StartCoroutine(LowerMusicPitchCoroutine(duration));
	}
	IEnumerator LowerMusicPitchCoroutine(float duration)
	{
		float time = 0;

		while (time<=duration)
		{
			float tRatio = time / duration;
			_aSourceMusic.outputAudioMixerGroup.audioMixer.SetFloat("MusicCompleteMusicPitch", Mathf.Lerp(_originalpitch, 0, tRatio));
			time += Time.deltaTime;
			yield return null;
		}
		_aSourceMusic.outputAudioMixerGroup.audioMixer.SetFloat("MusicCompleteMusicPitch",0);
	}
	public void ReturnAtOriginalMusicPitch()
	{
		_aSourceMusic.outputAudioMixerGroup.audioMixer.SetFloat("MusicCompleteMusicPitch", _originalpitch);
	}
	public void ApplyReverbToMusic(float dryLevel=0, float room=-10000, float roomHF=0)
	{
		_aSourceMusic.outputAudioMixerGroup.audioMixer.SetFloat("MusicMasterReverbDryLevel",dryLevel);
		_aSourceMusic.outputAudioMixerGroup.audioMixer.SetFloat("MusicMasterReverbRoom",room);
		_aSourceMusic.outputAudioMixerGroup.audioMixer.SetFloat("MusicMasterReverbRoomHF",roomHF);
	}
}
