using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    #region Singleton
    protected static ButtonManager instance;
    public static ButtonManager Instance
    {
        get
        {
            if (instance == null)
            {
                var gO = new GameObject();
                instance = gO.AddComponent<ButtonManager>();
            }
            return instance;
        }
    }
    #endregion

    public TextMeshProUGUI digitLabel;
    public TextMeshProUGUI operatorLabel;
    public TextMeshProUGUI resultLabel;

    public List<TextMeshProUGUI> lstNormalNumerals = new List<TextMeshProUGUI>();

    Subject subject = new Subject();

    private bool errorDisplayed;
    private bool displayValid;
    private bool switchBtnClick;

    private double currentVal;
    private double storedVal;
    private double result;

    private char storedOperator;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        Init();
        //BtnClick('c');
        switchBtnClick = false;
    }

    private void Init()
    {
        ButtonLabel btn1 = new ButtonLabel(lstNormalNumerals[0], new ChangeNumber1());
        ButtonLabel btn2 = new ButtonLabel(lstNormalNumerals[1], new ChangeNumber2());
        ButtonLabel btn3 = new ButtonLabel(lstNormalNumerals[2], new ChangeNumber3());
        ButtonLabel btn4 = new ButtonLabel(lstNormalNumerals[3], new ChangeNumber4());
        ButtonLabel btn5 = new ButtonLabel(lstNormalNumerals[4], new ChangeNumber5());
        ButtonLabel btn6 = new ButtonLabel(lstNormalNumerals[5], new ChangeNumber6());
        ButtonLabel btn7 = new ButtonLabel(lstNormalNumerals[6], new ChangeNumber7());
        ButtonLabel btn8 = new ButtonLabel(lstNormalNumerals[7], new ChangeNumber8());
        ButtonLabel btn9 = new ButtonLabel(lstNormalNumerals[8], new ChangeNumber9());

        subject.AddObserver(btn1);
        subject.AddObserver(btn2);
        subject.AddObserver(btn3);
        subject.AddObserver(btn4);
        subject.AddObserver(btn5);
        subject.AddObserver(btn6);
        subject.AddObserver(btn7);
        subject.AddObserver(btn8);
        subject.AddObserver(btn9);
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
    
    private void UpdateLabel()
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
        UpdateLabel();
    }

    public void BtnClick(char caption)
    {
        AudioManager.Instance.PlayAudio(AudioManager.Instance.audioClip);
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
            UpdateLabel();
        }
    }

    public void SwitchBtnClick()
    {
        AudioManager.Instance.PlayAudio(AudioManager.Instance.audioClip);
        subject.Notify();
    }


    private void OnDestroy()
    {
        instance = null;
    }
}
