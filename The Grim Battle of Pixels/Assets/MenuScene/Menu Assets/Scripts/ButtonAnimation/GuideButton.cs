using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GuideButton : MonoBehaviour, IDeselectHandler, IUpdateSelectedHandler
{
    [SerializeField] private GameObject infoPanel;
    private MenuScript ms;

    void Start()
    {
        ms = GameObject.Find("Canvas").GetComponent<MenuScript>();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        infoPanel.SetActive(false);
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        ms.setLSB(this.gameObject);
        infoPanel.SetActive(true);
    }
}
