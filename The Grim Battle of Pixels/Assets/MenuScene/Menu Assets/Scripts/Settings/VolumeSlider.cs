using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour, IDeselectHandler, IUpdateSelectedHandler
{
    
    private float volume = 100f;
    private float tempVolume = 100f;
    private string stringVolume;
    [SerializeField] private AudioMixer am;
    [SerializeField] private Text textValue;
    private bool musWokr = true;
    private MenuScript ms;




    void Start()
    {
        ms = GameObject.Find("Canvas").GetComponent<MenuScript>();
        if (volume != -80f && musWokr) //
        {
            am.GetFloat("masterVolume", out volume);
            //volume *= 100;
            this.gameObject.GetComponent<Slider>().value = volume;
            stringVolume = (((int)volume + 75) * 4 / 3).ToString() + " %";
            textValue.text = stringVolume;
        }
        else //
        {
            textValue.text = " - ";
        }
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        ms.setLSB(this.gameObject);
        //if (textValue.text != "[ " + stringVolume + " ]")
        if (volume != -80f) //
        {
         
            stringVolume = (((int)volume + 75)*4/3).ToString() + " %";
            textValue.text = "[ " + stringVolume + " ]";
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        textValue.text = stringVolume;
    }

    public void onChangeValue()
    {
        volume = this.gameObject.GetComponent<Slider>().value;
        if (volume != -80f) //
            am.SetFloat("masterVolume", volume);
    }

    public void onMute()
    {
        
        if (musWokr)
        { 
            tempVolume = volume;
            this.gameObject.GetComponent<Slider>().interactable = false;
            am.SetFloat("masterVolume", -80f);
            textValue.text = " - ";
        }
        else
        {
            volume = tempVolume;
            this.gameObject.GetComponent<Slider>().interactable = true;
            am.SetFloat("masterVolume", volume);

            stringVolume = (((int)volume + 75) * 4 / 3).ToString() + " %";
            textValue.text = stringVolume;
        }
        musWokr = !musWokr;
    }

}
