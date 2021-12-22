using UnityEngine;

public class CalculatorButton : MonoBehaviour
{
    public char value;

    public void OnClickBtn()
    {
        ButtonManager.Instance.BtnClick(value);

    }
}
