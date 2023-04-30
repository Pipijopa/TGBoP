using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GuideBackButton : MonoBehaviour, IDeselectHandler, IUpdateSelectedHandler
{
    [SerializeField] private GameObject abliText;
    [SerializeField] private GameObject ultText;
    [SerializeField] private GameObject backText;
    private MenuScript ms;

    void Start()
    {
        ms = GameObject.Find("Canvas").GetComponent<MenuScript>();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        abliText.SetActive(true);
        ultText.SetActive(true);
        backText.SetActive(false);
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        ms.setLSB(this.gameObject);
        abliText.SetActive(false);
        ultText.SetActive(false);
        backText.SetActive(true);
    }
}
