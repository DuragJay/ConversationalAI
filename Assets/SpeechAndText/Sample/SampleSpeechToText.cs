using UnityEngine;
using UnityEngine.UI;
using TextSpeech;

using OpenAI_Unity;

public class SampleSpeechToText : MonoBehaviour
{
    public GameObject loading;
    public GameObject aiGameObject;
    public Text uiText;
 
    void Start()
    {
        Setting("en-US");
        loading.SetActive(false);
        SpeechToText.instance.onResultCallback = OnResultSpeech;

    }
    

    public void StartRecording()
    {
#if UNITY_EDITOR
#else
        SpeechToText.instance.StartRecording("Speak any");
#endif
    }

    public void StopRecording()
    {
#if UNITY_EDITOR
        OnResultSpeech("Not support in editor.");
#else
        SpeechToText.instance.StopRecording();
#endif
#if UNITY_IOS
        loading.SetActive(true);
#endif
    }
    void OnResultSpeech(string _data)
    {
        uiText.text = _data;
        var ai = aiGameObject.GetComponent<OAICharacter>();
        
#if UNITY_IOS
        loading.SetActive(false);
#endif
    }
    public void OnClickSpeak()
    {
        TextToSpeech.instance.StartSpeak(uiText.text);
    }
    public void  OnClickStopSpeak()
    {
        TextToSpeech.instance.StopSpeak();
    }
    public void Setting(string code)
    {
        TextToSpeech.instance.Setting(code, 1, 1);
        SpeechToText.instance.Setting(code);
       
    }
    
}
