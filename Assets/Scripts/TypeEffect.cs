using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    string targetMessage;
    public int CherPerSeconds;
    public GameObject EndCursor;
    Text msgText;
    AudioSource audioSource;
    int index;
    float interval;
    public bool isAnimation;

    private void Awake()
    {
        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }

    public void SetMessage(string message)
    {
        if (isAnimation)
        {
            msgText.text = targetMessage;
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            targetMessage = message;
            EffectStart();
        }
    }

    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        EndCursor.SetActive(false);

        interval = 1.0f/CherPerSeconds;
        isAnimation = true;
        Invoke("Effecting", interval);
    }
    void Effecting()
    {
        if(msgText.text == targetMessage)
        {
            EffectEnd();
            return;
        }

        msgText.text += targetMessage[index];
        if (targetMessage[index] != ' ' || targetMessage[index] != '.')
            audioSource.Play();
        index++;
            
        Invoke("Effecting", interval);
    }
    void EffectEnd()
    {
        isAnimation = false;
        EndCursor.SetActive(true);
    }


}
