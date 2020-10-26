using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundOptionMenuBehaviour : MonoBehaviour,ISoundOptionMenuBehaviour
{
	public AudioMixer controledMixeur;
	public string valueToChangeName;
	public void Start()
	{
		SetSliderToGoodValue();
	}
	void SetSliderToGoodValue()
	{
		float _controledMixeurVolume;
		controledMixeur.GetFloat(valueToChangeName,out _controledMixeurVolume);
		GetComponent<Slider>().value = _controledMixeurVolume;
	}
	public void SetAudioMixeurGroupVolume(Slider volume)
	{
		controledMixeur.SetFloat(valueToChangeName, volume.value);
	}

}
