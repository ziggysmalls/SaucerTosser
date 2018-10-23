using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AudioEvent), true)]
public class EditorAudioEvent : Editor
{
	private AudioSource audioSourcePreview;

	public void OnEnable()
	{
		audioSourcePreview = EditorUtility.CreateGameObjectWithHideFlags("Audio preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
	}

	public void OnDisable()
	{
		DestroyImmediate(audioSourcePreview.gameObject);
	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		
		EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
		if (GUILayout.Button("Preview"))
			((AudioEvent) target).PlayPreview(audioSourcePreview);
		EditorGUI.EndDisabledGroup();
	}
}