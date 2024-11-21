# SFTP File Transfer Client

This project demonstrates an SFTP file transfer client using `nsoftware.IPWorksSFTP` to upload files to an SFTP server. The client bypasses the server's host key verification for testing purposes.

## Prerequisites

1. Ensure you have downloaded and installed the trial version of `nsoftware.IPWorksSFTP`.
2. Verify the SFTP server credentials and connection details.

---

## Configuration

Update the `appsettings.json` file with the correct SFTP server information:

```json
{
  "SFTP": {
    "Host": "your-sftp-host",          // Replace with your SFTP server address (e.g., "test.rebex.net")
    "Port": 22,                        // Replace with your SFTP server port (default is 22)
    "SSHUser": "your-username",        // Replace with your SFTP username
    "SSHPassword": "your-password",     // Replace with your SFTP password
     "SSHAcceptServerHostKey" : true    
  }
}
