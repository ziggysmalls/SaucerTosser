using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/Audio Event")]
public class AudioEvent : ScriptableObject
{
	public static List<AudioSource> audioSourcePool;
	public static int poolSize = 100;

	public AudioEventData data;

	public static void InitalizePool()
	{
		if (audioSourcePool != null)
			return;

		audioSourcePool = new List<AudioSource>();
		for (int i = 0; i < poolSize; i++)
		{
			AudioSource audioSource = new GameObject("AudioSourcePoolObject" + i).AddComponent<AudioSource>();
			audioSource.gameObject.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
			audioSourcePool.Add(audioSource);
		}
	}

	public void PlayPreview(AudioSource audioSource)
	{
		SetData(audioSource,true);
	}

	public void Play(Vector3 worldPosition)
	{
		InitalizePool();

		foreach(AudioSource i in audioSourcePool)
		{
			if (!i.isPlaying)
			{
				i.gameObject.transform.position = worldPosition;
				SetData(i,false);
				return;
			}
		}
	}

	private void SetData(AudioSource source,bool isPreview)
	{
		if (data.audioClips.Length <= 0) return;

		source.clip = data.audioClips[Random.Range(0,data.audioClips.Length)];
		source.priority = Random.Range((int)data.priority.minValue,(int)data.priority.maxValue);
		source.volume = Random.Range(data.volume.minValue,data.volume.maxValue);
		source.pitch = Random.Range(data.pitch.minValue,data.pitch.maxValue);
		source.spatialBlend = Random.Range(data.spatialBlend.minValue,data.spatialBlend.maxValue);
		source.reverbZoneMix = Random.Range(data.reverbZoneMix.minValue,data.reverbZoneMix.maxValue);
		source.dopplerLevel = Random.Range(data.dopplerLevel.minValue,data.dopplerLevel.maxValue);
		source.spread = Random.Range(data.spread.minValue,data.spread.maxValue);

		if (isPreview)
			source.spatialBlend = 0;

		source.PlayDelayed(Random.Range(data.delay.minValue,data.delay.maxValue));
	}

	[System.Serializable]
	public struct AudioEventData
	{
		[Header("Clips")]
		public AudioClip[] audioClips;
		
		[Header("Main")]
		public RangedFloat delay;
		[AttributeMinMaxRange(0,256)]
		public RangedFloat priority;
		public RangedFloat volume;
		[AttributeMinMaxRange(0,2)]
		public RangedFloat pitch;
		[AttributeMinMaxRange(-1,1)]
		public RangedFloat spatialBlend;
		[AttributeMinMaxRange(0,1.1f)]
		public RangedFloat reverbZoneMix;

		[Header("3D Settings")]
		[AttributeMinMaxRange(0,5)]
		public RangedFloat dopplerLevel;
		[AttributeMinMaxRange(0,360)]
		public RangedFloat spread;
	}
}