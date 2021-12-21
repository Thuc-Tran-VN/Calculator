using System.Collections;
using UnityEngine;

public abstract class ChangeLabelEvents
{
    public abstract string GetString();
}

public class ChangeNumber1 : ChangeLabelEvents
{
    public override string GetString()
    {
        return "I";
    }
}

public class ChangeNumber2 : ChangeLabelEvents
{
    public override string GetString()
    {
        return "II";
    }
}

public class ChangeNumber3 : ChangeLabelEvents
{
    public override string GetString()
    {
        return "III";
    }
}

public class ChangeNumber4 : ChangeLabelEvents
{
    public override string GetString()
    {
        return "IV";
    }
}

public class ChangeNumber5 : ChangeLabelEvents
{
    public override string GetString()
    {
        return "V";
    }
}

public class ChangeNumber6 : ChangeLabelEvents
{
    public override string GetString()
    {
        return "VI";
    }
}

public class ChangeNumber7 : ChangeLabelEvents
{
    public override string GetString()
    {
        return "VII";
    }
}

public class ChangeNumber8 : ChangeLabelEvents
{
    public override string GetString()
    {
        return "VIII";
    }
}

public class ChangeNumber9 : ChangeLabelEvents
{
    public override string GetString()
    {
        return "IX";
    }
}
