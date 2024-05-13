using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "SOs/UI/Characters/CharacterSO", order=1)]
public class CharacterSO : ScriptableObject
{
    //[Header("Character definitions")]
    
    [field: SerializeField]//Note: we need to use [field: SerializeField] in order to make a property visible in the inspector. We do not want these values to be changed during runtime. :)
    public string CharacterRef { get; private set; }
    [field: SerializeField]
    public string CharacterName { get; private set; }
    
   // [Header("Visual")]
    [field: SerializeField]
    public Sprite CharacterImage { get; private set; }

    [field: SerializeField]
    public List<AnimationData> CharacterAnimations
    {
        get;
        private set;
    }

    public AnimationData GetAnimation(CharacterAnimationType type)
    {
        foreach (AnimationData animation in CharacterAnimations)
        {
            if (animation.AnimationType == type)
                return animation;
        }

        return CharacterAnimations[0];
    }
}
[Serializable]
public struct AnimationData
{
    [field: SerializeField] public CharacterAnimationType AnimationType { get; private set; }
    [field: SerializeField] public List<CustomAnimationFrame> AnimationFrames { get; private set; }
    [field: SerializeField] public float AnimationSpeed { get; private set; } 
}

[Serializable]
public struct CustomAnimationFrame
{
    [field: SerializeField] public Sprite Animation { get; private set; }
    [field: SerializeField] public float Delay { get; private set; }
}
public enum CharacterAnimationType
{
    Idle, Talking
}