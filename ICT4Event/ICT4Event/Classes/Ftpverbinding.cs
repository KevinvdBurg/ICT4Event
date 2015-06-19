using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;

namespace ICT4Event.Classes
{
    public class Ftpverbinding
    {

        public  void UploadFileToFtp(string map, string filePath, string username, string password)
        {
            var fileName = Path.GetFileName(filePath);
            var request = (FtpWebRequest)WebRequest.Create(/*url*/"ftp://192.168.21.145/" +  map + fileName);

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


        public void DownloadFtpFile( string savePath, string fileName, string map)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://192.168.21.145/" + map + fileName);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential("Administrator", "Admin123");
            savePath = savePath +  "\\" + fileName;
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