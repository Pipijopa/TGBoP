using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAnimKost2Script : MonoBehaviour, ISelectHandler, IDeselectHandler, IUpdateSelectedHandler
{
    Text ButtonText;
    [SerializeField] string standartText;
    private MenuScript ms;

    void Start()
    {
        ms = GameObject.Find("Canvas").GetComponent<MenuScript>();
        ButtonText = this.transform.GetChild(0).gameObject.GetComponent<Text>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        ms.setLSB(this.gameObject);
        ButtonText.text = "[ " + standartText + " ]";
    }

    public void OnDeselect(BaseEventData eventData)
    {
        ButtonText.text = standartText;
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        if (ButtonText.text != "[ " + standartText + " ]")
            ButtonText.text = "[ " + standartText + " ]";
    }
}
