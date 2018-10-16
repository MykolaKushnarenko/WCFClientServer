﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.SenderObject
{
    class DataExchangeWithServer
    {
        private const string _serverAdresess = "http://localhost:50373/Home/";
        private readonly string _adresess;
        private readonly string _method;
        private readonly string _paramSend;
        private readonly string _contentType;
        private readonly bool _returnData;
        public DataExchangeWithServer() { }

        public DataExchangeWithServer(string adresess, string method, string param, string contentType, bool returnData)
        {
            _adresess = adresess;
            _method = method;
            _paramSend = param;
            _contentType = contentType;
            _returnData = returnData;
        }

        public Task<string> SendToServer()
        {
            return Task.Run(() =>
            {
                try
                {
                    WebRequest request = WebRequest.Create(_serverAdresess + _adresess);
                    request.Method = _method;
                    request.ContentType = _contentType;
                    if (_method == "POST")
                    {
                        byte[] data = Encoding.UTF8.GetBytes(_paramSend);
                        request.ContentLength = data.Length;
                        using (Stream stream = request.GetRequestStream())
                        {
                            stream.Write(data, 0, data.Length);
                        }
                    }

                    WebResponse response = request.GetResponse();
                    string res;
                    using (Stream inputStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(inputStream))
                        {
                            res = reader.ReadToEnd();
                        }
                    }

                    return res;
                }
                catch (WebException e)
                {
                    if (e.Status == WebExceptionStatus.ConnectFailure)
                    {
                        MessageBox.Show("NOT CONECCTION !", "ERROR", MessageBoxButton.OK);
                    }
                    else if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        MessageBox.Show("Problem in date send", "ERROR", MessageBoxButton.OK);
                    }
                    else
                    {
                        MessageBox.Show("Sorry, this function not work. Send message to suppurt");
                    }
                    return null;
                }
                catch
                {
                    MessageBox.Show("Sorry, this function not work. Send message to suppurt");
                    return null;
                }

            });
        }
    }
}
