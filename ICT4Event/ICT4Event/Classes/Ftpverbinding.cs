// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ftpverbinding.cs" company="">
//   
// </copyright>
// <summary>
//   The ftpverbinding.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;

namespace ICT4Event.Classes
{
    /// <summary>
    /// The ftpverbinding.
    /// </summary>
    public class Ftpverbinding
    {
        /// <summary>
        /// The upload file to ftp.
        /// </summary>
        /// <param name="map">
        /// The map.
        /// </param>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        public void UploadFileToFtp(string map, string filePath, string username, string password)
        {
            var fileName = Path.GetFileName(filePath);
            var request = (FtpWebRequest)WebRequest.Create( /*url*/"ftp://192.168.21.145/" + map + fileName);

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = false;
            request.UseBinary = true;
            request.KeepAlive = false;

            using (var fileStream = File.OpenRead(filePath))
            {
                using (var requestStream = request.GetRequestStream())
                {
                    fileStream.CopyTo(requestStream);
                    requestStream.Close();
                }
            }

            var response = (FtpWebResponse)request.GetResponse();
            Console.WriteLine("Upload done: {0}", response.StatusDescription);
            response.Close();
        }

        /// <summary>
        /// The download ftp file.
        /// </summary>
        /// <param name="savePath">
        /// The save path.
        /// </param>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <param name="map">
        /// The map.
        /// </param>
        public void DownloadFtpFile(string savePath, string fileName, string map)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://192.168.21.145/" + map + fileName);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential("Administrator", "Admin123");
            savePath = savePath + "\\" + fileName;
            request.UsePassive = false;
            request.UseBinary = true;
            request.KeepAlive = false;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                using (Stream rs = response.GetResponseStream())
                {
                    using (FileStream ws = new FileStream(savePath, FileMode.Create))
                    {
                        byte[] buffer = new byte[2048];
                        int bytesRead = rs.Read(buffer, 0, buffer.Length);

                        while (bytesRead > 0)
                        {
                            ws.Write(buffer, 0, bytesRead);
                            bytesRead = rs.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
    }
}