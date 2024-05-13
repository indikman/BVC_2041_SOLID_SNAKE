using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CodecCallX", menuName = "SOs/UI/Codec/Codec", order = 1)]
public class CodecSO : ScriptableObject
{
    [field: SerializeField]
    public CharacterSO Character1 { get; private set; }
    [field: SerializeField]
    public CharacterSO Character2 { get; private set; }
    [field: SerializeField]
    public List<DialogueData> Dialogue { get; private set; }
    [field: SerializeField]
    public string RadioFrequencyP1 { get; private set; }
    [field: SerializeField]
    public string RadioFrequencyP2 { get; private set; }
    [field: SerializeField]
    public bool AbleToSkip { get; set; }
}

[Serializable]
public struct DialogueData
{
    [field: SerializeField]
    public DialoguePosition Position { get; private set; }
    [field: SerializeField]
    public CharacterSO Talker { get; private set; }
    [field: SerializeField]
    public string DialogueText { get; private set; }
    [field: SerializeField]
    public AudioClip DialogueAudio { get; private set; }
}
[Serializable]
public enum DialoguePosition
{
    Neutral, Left, Right
}

