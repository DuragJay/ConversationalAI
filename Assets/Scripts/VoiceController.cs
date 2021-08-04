using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.UI;
public class VoiceController : MonoBehaviour
{
    [SerializeField]
    Text uiText;
    private void Start()
    {
        Setup(LANG_CODE);
        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
    }

    #region Speech to Text

    public void StartLisening()
    {
        SpeechToText.instance.StartRecording();
    }
    public void StopLisenting()
    {
        SpeechToText.instance.StopRecording();
    }

    void OnFinalSpeechResult(string result)
    {
        uiText.text = result;
    }




    #endregion
    const string LANG_CODE = "en-US";
    void Setup(string code)
    {
        TextToSpeech.instance.Setting(code, 1, 1);
        SpeechToText.instance.Setting(code);
    }
}