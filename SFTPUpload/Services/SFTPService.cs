using Microsoft.Extensions.Options;
using SFTPUpload.Configuration;
using nsoftware.IPWorksSFTP;
using SFTPUpload.Models;

namespace SFTPUpload.Services;

public class SFTPService
{
    
        private readonly SFTPClient _sftp;
        private readonly SFTPServiceConfiguration _configuration;
        public SFTPService(IOptions<SFTPServiceConfiguration> configurationOptions)
        {
            _configuration = configurationOptions.Value;
            _sftp = new SFTPClient
            {
                SSHHost = _configuration.Host,
                SSHPort = _configuration.Port,
                SSHUser = _configuration.SSHUser,
                SSHPassword = _configuration.SSHPassword,
            };
            _sftp.Config($"SSHAcceptAnyServerHostKey={_configuration.SSHAcceptServerHostKey}");
        }

        public ServiceResponse UploadFile(IFormFile file, string remoteFile)
        {
            var response = new ServiceResponse();
            try
            {
                _sftp.Connect();
                
                var tempFilePath = Path.GetTempFileName();
                using (var stream = new FileStream(tempFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                
                _sftp.LocalFile = tempFilePath;
                _sftp.RemoteFile = remoteFile;

                _sftp.Upload();

                response.Message = "File uploaded successfully.";
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Error: {ex.Message}";
                response.Status = false;
                return response;
            }
            finally
            {
                _sftp.Disconnect();
            }
        }
    
}