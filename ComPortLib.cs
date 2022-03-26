//use the "Command Palette" with the nuget package manager to install "System.IO.Ports" v6.0
using System.IO.Ports;
public class Powersupply
{
    private string portname;
    private int baudrate;
    private int timeouttime;
    private string received;
    private SerialPort pwrsply = new SerialPort();
    public Powersupply()
    {
        portname = "COM1";
        baudrate = 9600;
        timeouttime = 2500;
        received = "";
    }
    public string Portname
    {
        get {return portname;}
        set {portname = value;}
    }  
    public int Baudrate
    {
        get {return baudrate;}
        set {baudrate = value;}
    }
    public int Timeouttime
    {
        get {return timeouttime;}
        set {timeouttime = value;}        
    }
    public bool OpenSerialPort()
    {
        try
        {
            pwrsply.BaudRate = baudrate;
            pwrsply.StopBits = StopBits.One;
            pwrsply.DataBits = 8;
            pwrsply.ReadTimeout = timeouttime;
            pwrsply.WriteTimeout = timeouttime;
            pwrsply.Parity = 0;
            pwrsply.PortName = portname;
        }
        catch(Exception e)
        {
            Console.WriteLine("Com initilization failed: " + e);
            return false;
        }
        pwrsply.DataReceived += new SerialDataReceivedEventHandler(Data);
        try
        {
            pwrsply.Open();
            Console.WriteLine("Com port " + pwrsply.PortName + "successfully opened");
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occured while opening com port: " + e);
            return false;
        }
    }
    public void WriteCommand(string command)
    {  
        pwrsply.WriteLine(command);
    }
    public string DataOut()
    {
        return received;
    }
    private void Data(object sender, SerialDataReceivedEventArgs e)
    {    
        try
        {
            SerialPort sp = (SerialPort)sender;
            received = sp.ReadLine();
        }
        catch (System.Exception b)
        {
            Console.WriteLine("Error occured while recevieing input: " + b);
        }
        Thread.Sleep(500);
    }
}