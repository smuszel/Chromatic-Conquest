using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(SoundEffect)), CanEditMultipleObjects]
public class SoundEffectEditor: Editor
{
    [SerializeField] private AudioSource _previewer;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SoundEffect tgt = (SoundEffect)target;
        if (GUILayout.Button("Play Preview"))
        {
            if (_previewer == null)
            {
                _previewer = EditorUtility.CreateGameObjectWithHideFlags("Audio preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
            }
            tgt.Execute(_previewer);
        }
    }

    public void OnDisable()
    {
        if (_previewer != null)
        DestroyImmediate(_previewer.gameObject);
    }
}