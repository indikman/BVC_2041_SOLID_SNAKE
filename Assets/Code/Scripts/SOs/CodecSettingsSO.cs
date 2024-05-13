using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "CodecSettings", menuName = "SOs/UI/Codec/CodecSettings", order = 0)]
public class CodecSettingsSO : ScriptableObject
{
    #region Private variables
    
    private StyleBackground[] _waveFrames;

    #endregion
    [field: SerializeField,Header("Audio")] public AudioClip OpeningSFX { get; private set; }
    [field: SerializeField] public AudioClip RingingSFX { get; private set; }
    [field: SerializeField] public AudioClip ClosingSFX { get; private set; }
    [field: SerializeField, Range(.25f, 10f)] public float PauseBeforeTalking { get; private set; }
    [field: SerializeField, Range(.25f, 10f)] public float PauseBetweenSpeakers { get; private set; }
    
    [field: SerializeField, Header("Radio Waves")] private Sprite[] waveSprites;
    [field: SerializeField] public GameObject CodecPrefab { get; private set; }
    [field: SerializeField] public CodecCallSO CodecCallSo { get; private set; }
    
    
    /// <summary>
    /// Unity needs StyleBackgrounds for the backgrounds in UIToolkit, and not sprites, so we create them the first time they are referenced, rather than constantly create them for animations
    /// </summary>
    [HideInInspector]
    public StyleBackground[] WaveFrames
    {
        get
        {
            if (_waveFrames == null && waveSprites != null) 
            {
                WaveFrames = new StyleBackground[waveSprites.Length];
            }
            return _waveFrames;
        }
        private set
        {
            _waveFrames = value;
            for (int i = 0; i < _waveFrames.Length; i++) _waveFrames[i] = new StyleBackground(waveSprites[i]);
        }
    }

    [field: SerializeField, Range(.01f,.5f) ] public float WaveSpeed { get; private set; }
    
    [field: SerializeField, Header("Transition Waits"), Range(0f, 2.5f)] public float OpeningWait { get; private set; }
    [field: SerializeField, Range(0f, 2.5f)] public float CharacterAppearWait { get; private set; }
    [field: SerializeField, Range(0f, 2.5f)] public float ClosingWait { get; private set; }
    [field: SerializeField, Range(0f, 1.5f)] public float CharacterDiscussionWait { get; private set; }
    
}
