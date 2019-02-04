using limo_droid_v4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace limo_droid_v4.Data
{
    public class User
    {
        static string url = "http://limogrid.com/api/ws_user.cfc?wsdl";
        public static Driver driver = new Driver();
        public static bool CheckCredentials(string username, string pass, string device, string company)
        {
            try
            {
                if (NetworkCheck.IsInternet())
                {
                    string xml = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:api=\"http://api\"> <soapenv:Header/> <soapenv:Body> <api:GetUser> <api:company>" + company + "</api:company> <api:username>" + username+"</api:username> <api:password>"+pass+ "</api:password> <api:device>" + device + "</api:device> </api:GetUser> </soapenv:Body> </soapenv:Envelope>";
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                    Debug.WriteLine(xml);
                    Debug.WriteLine(url);
                    //string s = "id="+Server.UrlEncode(xml);
                    byte[] requestBytes = System.Text.Encoding.ASCII.GetBytes(xml);
                    req.Method = "POST";
                    req.ContentType = "text/xml;charset=utf-8";
                    req.ContentLength = requestBytes.Length;
                    Stream requestStream = req.GetRequestStream();
                    requestStream.Write(requestBytes, 0, requestBytes.Length);
                    requestStream.Close();

                    HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                    StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default);
                    string backstr = sr.ReadToEnd();
                    string xmlres = backstr.Replace("&lt;", "<").Replace("&#xd;", "");
                    Debug.WriteLine(xmlres);
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xmlres);

                    XPathNavigator navigator = xmlDoc.CreateNavigator();
                    int id = 0;
                    foreach (XPathNavigator nav in navigator.Select("//ID_USER"))
                    {
                        try
                        {
                            id = Convert.ToInt32(nav.Value.ToString().Trim());
                        }
                        catch (Exception)
                        {
                            id = 0;
                        }

                    }
                    sr.Close();
                    res.Close();
                    if (id != 0)
                    {
                        Debug.WriteLine(id);
                        PreencherDriver(navigator);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool VerificarLoginAnterior(string device)
        {
            try
            {
                if (NetworkCheck.IsInternet())
                {
                    string xml = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:api=\"http://api\"> <soapenv:Header/> <soapenv:Body> <api:GetLastLogin> <api:device>" + device + "</api:device> </api:GetLastLogin> </soapenv:Body> </soapenv:Envelope>";
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                    Debug.WriteLine(xml);
                    Debug.WriteLine(url);
                    //string s = "id="+Server.UrlEncode(xml);
                    byte[] requestBytes = System.Text.Encoding.ASCII.GetBytes(xml);
                    req.Method = "POST";
                    req.ContentType = "text/xml;charset=utf-8";
                    req.ContentLength = requestBytes.Length;
                    Stream requestStream = req.GetRequestStream();
                    requestStream.Write(requestBytes, 0, requestBytes.Length);
                    requestStream.Close();

                    HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                    StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default);
                    string backstr = sr.ReadToEnd();
                    string xmlres = backstr.Replace("&lt;", "<").Replace("&#xd;", "");
                    Debug.WriteLine(xmlres);
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xmlres);

                    XPathNavigator navigator = xmlDoc.CreateNavigator();
                    int id = 0;
                    foreach (XPathNavigator nav in navigator.Select("//ID_USER"))
                    {
                        try
                        {
                            id = Convert.ToInt32(nav.Value.ToString().Trim());
                        }
                        catch (Exception)
                        {
                            id = 0;
                        }

                    }
                    sr.Close();
                    res.Close();
                    if (id != 0)
                    {
                        Debug.WriteLine(id);
                        PreencherDriver(navigator);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static void PreencherDriver(XPathNavigator navigator)
        {
            
            int id = 0;
            int id_chauffeur = 0;
            string email = "";
            string first_name = "";
            string last_name = "";
            string phone = "";
            string city = "";
            string company_id = "";

            foreach (XPathNavigator nav in navigator.Select("//ID_USER"))
            {
                try
                {
                    id = Convert.ToInt32(nav.Value.ToString().Trim());
                }
                catch (Exception)
                {
                    id = 0;
                }
            }
            foreach (XPathNavigator nav in navigator.Select("//ID_CHAUFFEUR"))
            {
                try
                {
                    id_chauffeur = Convert.ToInt32(nav.Value.ToString().Trim());
                }
                catch (Exception)
                {
                    id_chauffeur = 0;
                }
            }
            foreach (XPathNavigator nav in navigator.Select("//EMAIL"))
            {
                email = nav.Value.ToString();
            }
            foreach (XPathNavigator nav in navigator.Select("//FIRST_NAME"))
            {
                first_name = nav.Value.ToString();
            }
            foreach (XPathNavigator nav in navigator.Select("//LAST_NAME"))
            {
                last_name = nav.Value.ToString();
            }
            foreach (XPathNavigator nav in navigator.Select("//PHONE"))
            {
                phone = nav.Value.ToString();
            }
            foreach (XPathNavigator nav in navigator.Select("//CITY"))
            {
                city = nav.Value.ToString();
            }
            foreach (XPathNavigator nav in navigator.Select("//COMPANY_ID"))
            {
                company_id = nav.Value.ToString();
            }

            driver.Id = id;
            driver.Email = email;
            driver.First_Name = first_name;
            driver.Last_Name = last_name;
            driver.Phone = phone;
            driver.City = city;
            driver.Company_Id = company_id;
            driver.Id_Chauffeur = id_chauffeur;
        }

    }
}
