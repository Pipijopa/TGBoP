using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonAnimKostScript : MonoBehaviour, ISelectHandler, IDeselectHandler, ISubmitHandler
{
    Text ButtonText;
    [SerializeField]string standartText;
    private MenuScript ms;
    private GSMenuScript gsms;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            ms = GameObject.Find("Canvas").GetComponent<MenuScript>();
        else
            gsms = GameObject.Find("HUD").GetComponent<GSMenuScript>();

        ButtonText = this.transform.GetChild(0).gameObject.GetComponent<Text>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            ms.setLSB(this.gameObject);
        else
            gsms.setLSB(this.gameObject);
        ButtonText.text = "[ " + standartText + " ]";
    }

    public void OnDeselect(BaseEventData eventData)
    {
        ButtonText.text = standartText;
    }

    public void OnSubmit(BaseEventData eventData)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            ButtonText.text = standartText;
    }
}
