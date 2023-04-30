using UnityEngine;
using UnityEngine.UI;

public class CaptureBar : MonoBehaviour
{
    private Image cptFlagImgP1;
    private Image cptFlagImgP2;
    private Capture fillStatus;
    private float speedTransformation = 50f;
    private int time_win = 25;
    void Start()
    {
        cptFlagImgP1 = GameObject.Find("FCFillP1").GetComponent<Image>();
        cptFlagImgP2 = GameObject.Find("FCFillP2").GetComponent<Image>();
        fillStatus = GameObject.Find("Flag").transform.GetComponent<Capture>();

        cptFlagImgP1.fillAmount = fillStatus.getTime1();
        cptFlagImgP2.fillAmount = fillStatus.getTime2();
    }

    void Update()
    {
        cptFlagImgP1.fillAmount = Mathf.Lerp(cptFlagImgP1.fillAmount, (float)fillStatus.getTime1() / time_win, Time.deltaTime * speedTransformation);
        cptFlagImgP2.fillAmount = Mathf.Lerp(cptFlagImgP2.fillAmount, (float)fillStatus.getTime2() / time_win, Time.deltaTime * speedTransformation);
    }
}
