using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public TextMeshProUGUI digitLabel;
    public TextMeshProUGUI operatorLabel;
    public TextMeshProUGUI resultLabel;

    public List<GameObject> lstNormalNumerals = new List<GameObject>();
    public List<string> lstLatinNumeralsChar = new List<string>();
    public List<string> lstNormalNumeralsChar = new List<string>();

    public AudioSource audioSource;
    public AudioClip audioClip;

    private bool errorDisplayed;
    private bool displayValid;
    private bool switchBtnClick;

    private double currentVal;
    private double storedVal;
    private double result;

    private char storedOperator;

    void Start()
    {
        BtnClick('c');
        switchBtnClick = false;
    }

    private void ClearCalc()
    {
        digitLabel.text = "0";
        operatorLabel.text = "";
        resultLabel.text = "0";
        displayValid = errorDisplayed = false;
        currentVal = result = storedVal = 0;
        storedOperator = ' ';
    }
    
    private void updateDigitLabel()
    {
        if (!errorDisplayed)
        {
            digitLabel.text = currentVal.ToString("");
            resultLabel.text = currentVal.ToString("");
        }  
        displayValid = false;
    }

    private void CalcResult(char activeOperator)
    {
        switch (activeOperator)
        {
            case '=':
                result = currentVal;
                break;
            case '+':
                result = storedVal + currentVal;
                break;
            case '-':
                result = storedVal - currentVal;
                break;
            case 'x':
                result = storedVal * currentVal;
                break;
            case '÷':
                if(currentVal != 0)
                {
                    result = storedVal / currentVal;
                }
                else
                {
                    errorDisplayed = true;
                    resultLabel.text = "ERROR";
                }    
                break;
            default:
                Debug.Log("Unknown: " + activeOperator);
                break;
        }
        currentVal = result;
        updateDigitLabel();
    }

    public void BtnClick(char caption)
    {
        audioSource.PlayOneShot(audioClip);
        if (errorDisplayed)
            ClearCalc();
        if((caption >= '0' && caption <= '9') || caption == '.')
        {
            if(digitLabel.text.Length < 15 || !displayValid)
            {
                if (!displayValid)
                    digitLabel.text = (caption == '.' ? "0" : "");
                else if (digitLabel.text == "0" && caption != '.')
                    digitLabel.text = "";
                digitLabel.text += caption;
                displayValid = true;
            }
        } 
        else if (caption == 'c')
        {
            ClearCalc();
        }
        else if (displayValid || storedOperator == '=')
        {
            currentVal = double.Parse(digitLabel.text);
            displayValid = false;
            if(storedOperator != ' ')
            {
                CalcResult(storedOperator);
                storedOperator = ' ';
            }
            operatorLabel.text = caption.ToString();
            storedOperator = caption;
            storedVal = currentVal;
            updateDigitLabel();
        }
    }

    public void SwitchBtnClick()
    {
        audioSource.PlayOneShot(audioClip);
        if (!switchBtnClick)
        {
            for (int i = 0; i < lstNormalNumerals.Count; i++)
            {
                lstNormalNumerals[i].GetComponentInChildren<TextMeshProUGUI>().text = lstLatinNumeralsChar[i];
            }
            switchBtnClick = true;
        }
        else
        {
            for (int i = 0; i < lstNormalNumerals.Count; i++)
            {
                lstNormalNumerals[i].GetComponentInChildren<TextMeshProUGUI>().text = lstNormalNumeralsChar[i];
            }
            switchBtnClick = false;
        }
        
    }
}
