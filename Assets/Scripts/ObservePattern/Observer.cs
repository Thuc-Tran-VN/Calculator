using UnityEngine;
using System.Collections;
using TMPro;

public abstract class Observer
{
    public abstract void OnNotify();
}

public class ButtonLabel: Observer
{
    public TextMeshProUGUI txtLabel;
    ChangeLabelEvents changeLabelEvents;

    public ButtonLabel(TextMeshProUGUI txtLabel, ChangeLabelEvents changeLabelEvents)
    {
        this.txtLabel = txtLabel;
        this.changeLabelEvents = changeLabelEvents;
    }

    public override void OnNotify()
    {
        ChangeLabel(changeLabelEvents.GetString());
    }

    void ChangeLabel(string label)
    {
        txtLabel.text = label;
    }
}
