using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CodecView : MonoBehaviour
{
    [SerializeField] private CodecSettingsSO codecSettings;
    private CodecSO _codecInfo;
    #region Document references
    
    private VisualElement _root, _mainDisplay, _leftSprite, _rightSprite, _radioWaves;
    private Label _radioNumberP1, _radioNumberP2, _dialogueText;
    #endregion
    #region Private Variables
    private AudioSource _sfxSource;
    private CharacterSO _leftCharacter, _rightCharacter;
    private bool _codecRunning;
    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        _sfxSource = GetComponent<AudioSource>();
        GetElements();
    }

    private void GetElements()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
        _mainDisplay = _root.Q<VisualElement>(CodecReference.MainDisplay);
        _leftSprite = _root.Q<VisualElement>(CodecReference.LeftCharacter);
        _rightSprite = _root.Q<VisualElement>(CodecReference.RightCharacter);
        _radioWaves = _root.Q<VisualElement>(CodecReference.RadioWaves);
        _radioNumberP1 = _root.Q<Label>(CodecReference.RadioNumberP1);
        _radioNumberP2 = _root.Q<Label>(CodecReference.RadioNumberP2);
        _dialogueText = _root.Q<Label>(CodecReference.DialogueText);
        _dialogueText.text = "";
    }
    public void Initialize(CodecSO cInfo)
    {
        _codecInfo = cInfo;
        _radioNumberP1.text = _codecInfo.RadioFrequencyP1;
        _radioNumberP2.text = _codecInfo.RadioFrequencyP2;
        _sfxSource.clip = codecSettings.OpeningSFX;
        _leftCharacter = _codecInfo.Character1;
        _rightCharacter = _codecInfo.Character2;
        _leftSprite.style.backgroundImage = new StyleBackground(_leftCharacter.CharacterImage);
        _rightSprite.style.backgroundImage = new StyleBackground(_rightCharacter.CharacterImage);
        StartCoroutine(ExecuteCodecCall());
    }

    /// <summary>
    /// The Codec Call is a coroutine that is going to spawn other coroutines that will handle animations.
    /// It will involve a bunch of steps:
    /// 1. Wait a half second.
    /// 2. Play some audio and show the character displays
    /// 3. Once finished, wait in idle for a second
    /// 4. Start playing animations
    /// 
    /// </summary>
    IEnumerator ExecuteCodecCall()
    {
        //Step 1: make display appear
        yield return new WaitForSeconds(codecSettings.OpeningWait);
        _mainDisplay.RemoveFromClassList(CodecReference.HideDisplayClass);
        yield return new WaitForSeconds(codecSettings.OpeningWait);
        //Step 2 play audio make characters appear
        _codecRunning = true; //do this so we actually keep track of the codec running so it can be tabbed out of
        var WaveAnimation = StartCoroutine(AnimateWaves());
        _sfxSource.Play();
        _leftSprite.RemoveFromClassList(CodecReference.HideCharacterClass);
        _rightSprite.RemoveFromClassList(CodecReference.HideCharacterClass);
        yield return new WaitForSeconds(codecSettings.CharacterAppearWait);
        
        //Step 2.5: pause before people start talking
        yield return new WaitForSeconds(codecSettings.PauseBeforeTalking);
        
        //step 3: play audio and display text
        yield return StartCoroutine(DialogueScenes());
        StartCoroutine(AnimateSprites(_leftSprite, _leftCharacter.GetAnimation(CharacterAnimationType.Idle)));
        StartCoroutine(AnimateSprites(_rightSprite, _rightCharacter.GetAnimation(CharacterAnimationType.Idle)));
        //step 4: wait a couple of seconds
        yield return new WaitForSeconds(codecSettings.ClosingWait);
        _sfxSource.clip = codecSettings.ClosingSFX;
        _sfxSource.Play();
        _mainDisplay.AddToClassList(CodecReference.HideDisplayClass);
        yield return new WaitForSeconds(codecSettings.ClosingWait);
        _codecInfo.AbleToSkip = true;
        Destroy(this.gameObject);

    }
    IEnumerator AnimateWaves()
    { 
        while (true)
        {
            var waveRange = Random.Range(0, codecSettings.WaveFrames.Length);
            for (int i = 0; i <= waveRange; i++)
            {
                _radioWaves.style.backgroundImage = codecSettings.WaveFrames[i];
                yield return new WaitForSeconds(codecSettings.WaveSpeed);
            }

            for (int i = waveRange; i >= 0; i--)
            {
                _radioWaves.style.backgroundImage = codecSettings.WaveFrames[i];
                yield return new WaitForSeconds(codecSettings.WaveSpeed);
            }
        }
        
        
    }
    IEnumerator DialogueScenes()
    {
        DialoguePosition currentPosition = DialoguePosition.Right;
        for(int i = 0; i < _codecInfo.Dialogue.Count; i++)
        {
            var dialogue = _codecInfo.Dialogue[i];
            _sfxSource.clip = dialogue.DialogueAudio;
            _sfxSource.Play();
            _dialogueText.text = dialogue.DialogueText; 
            
            CharacterSO talkingCharacter;
            CharacterSO idleCharacter;
            if (dialogue.Position == DialoguePosition.Neutral)
            {
                currentPosition = currentPosition == DialoguePosition.Left
                    ? DialoguePosition.Right
                    : DialoguePosition.Left;
            }
            else
            {
                currentPosition = dialogue.Position;
            }
            
            VisualElement talkingSprite, idleSprite;
            
            if (currentPosition == DialoguePosition.Left)
            {
                talkingCharacter = _leftCharacter;
                idleCharacter = _rightCharacter;
                talkingSprite = _leftSprite;
                idleSprite = _rightSprite;
            }
            else
            {
                talkingCharacter = _rightCharacter;
                idleCharacter = _leftCharacter;
                idleSprite = _leftSprite;
                talkingSprite = _rightSprite;
            }
            Coroutine talkingAnimation = StartCoroutine(AnimateSprites(talkingSprite, talkingCharacter.GetAnimation(CharacterAnimationType.Talking)));
            Coroutine idleAnimation =
                StartCoroutine(AnimateSprites(idleSprite, idleCharacter.GetAnimation(CharacterAnimationType.Idle)));
            yield return new WaitForSeconds(_sfxSource.clip.length);
            StopCoroutine(talkingAnimation);
            StopCoroutine(idleAnimation);
            yield return new WaitForSeconds(codecSettings.PauseBetweenSpeakers);//wait before next person starts talking
        }
        _dialogueText.text = "";

        
    }

    IEnumerator AnimateSprites(VisualElement element, AnimationData animation)
    {
        while (true)
        {
            foreach (CustomAnimationFrame frame in animation.AnimationFrames)
            {
                element.style.backgroundImage = new StyleBackground(frame.Animation);
                yield return new WaitForSeconds(frame.Delay / animation.AnimationSpeed);
            }
            
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (_codecInfo.AbleToSkip && _codecRunning)
            {
                StopAllCoroutines();
                _sfxSource.clip = codecSettings.ClosingSFX;
                _sfxSource.Play();
                _mainDisplay.AddToClassList(CodecReference.HideDisplayClass);
                _codecInfo.AbleToSkip = true;
                Destroy(this.gameObject, 2f);
            }
        }
    }
}


public static class CodecReference
{
    #region Reference IDs

    public const string MainDisplay = "displayBox";
    public const string LeftCharacter = "leftSprite";
    public const string RightCharacter = "rightSprite";
    public const string RadioWaves = "radioWavesHighlighted";
    public const string RadioNumberP1 = "radioNumber1";
    public const string RadioNumberP2 = "radioNumber2";
    public const string DialogueText = "codecText";
    
    #endregion

    #region  USS class references

    public const string HideCharacterClass = "characterHide";
    public const string HideDisplayClass = "displayHide";

    #endregion

}