namespace SFTPUpload.Configuration;

public class SFTPServiceConfiguration
{
    public static string Name { get; set; } = "SFTPServiceConfig";
    public string Host { get; set; }
    public int Port { get; set; }
    public string SSHUser { get; set; }
    public string SSHPassword { get; set; }
    public bool SSHAcceptServerHostKey { get; set; }
}