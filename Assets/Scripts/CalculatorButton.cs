using TMPro;
using UnityEngine;

public class CalculatorButton : MonoBehaviour
{
    public TextMeshProUGUI label;

    public Manager calcManager
    {
        get
        {
            if (_calcManager == null)
                _calcManager = GetComponentInParent<Manager>();
            return _calcManager;

        }
    }
    static Manager _calcManager;

    public void OnBtnClick()
    {
        calcManager.BtnClick(label.text[0]);
    }

    public void OnSwichBtnClick()
    {
        calcManager.SwitchBtnClick();
    }
}
