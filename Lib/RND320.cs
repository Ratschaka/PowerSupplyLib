class RND320 : Powersupply
{
    public void SetVoltage(double value)
    {
        WriteCommand("VSET1: " + value);
    }
    public void SetCurrent(double value)
    {
        WriteCommand("ISET1: " + value);
    }
    public void AskVoltage()
    {
        WriteCommand("VOUT1?");
    }
    public void AskCurrent()
    {
        WriteCommand("IOUT1?");
    }
    public void SwitchOn()
    {
        WriteCommand("OUT1");
    }
    public void SwitchOff()
    {
        WriteCommand("OUT0");
    }
}