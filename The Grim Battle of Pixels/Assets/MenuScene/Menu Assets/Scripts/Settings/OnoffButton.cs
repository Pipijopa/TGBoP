using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class OnoffButton : MonoBehaviour, IDeselectHandler, IUpdateSelectedHandler, ISubmitHandler
{
    Text ButtonText;
    [SerializeField] string onText;
    [SerializeField] string offText;
    bool onSwitch = true;
    [SerializeField] private AudioMixer am;
    private MenuScript ms;

    void Start()
    {
        ms = GameObject.Find("Canvas").GetComponent<MenuScript>();
        ButtonText = this.transform.GetChild(0).gameObject.GetComponent<Text>();
        float temp;
        am.GetFloat("masterVolume", out temp);
        if (temp == -80f)
            ButtonText.text = "[ ¬€ À ]";
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        ms.setLSB(this.gameObject);
        if (onSwitch)
        {
            if (ButtonText.text != "[ " + onText + " ]")
                ButtonText.text = "[ " + onText + " ]";
        }
        else
        {
            if(ButtonText.text != "[ " + offText + " ]")
                ButtonText.text = "[ " + offText + " ]";
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (onSwitch)
            ButtonText.text = onText;
        else
            ButtonText.text = offText;
    }

    public void OnSubmit(BaseEventData eventData)
    {
        onSwitch = !onSwitch;
    }

}
