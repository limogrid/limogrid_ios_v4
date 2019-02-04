using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Diagnostics;
using limo_droid_v4.Models;

namespace limo_droid_v4.Data
{
    public class Map
    {
        static string url = "http://limogrid.com/api/ws_map.cfc?wsdl";
        public static string cache_action = "";
        public static int UpdateLocation(string lat, string lon, string status)
        {
            try
            {
                if (NetworkCheck.IsInternet())
                {
                    Driver driver = Data.User.driver;
                    int last_reserva = 0;
                    try
                    {
                        last_reserva = Data.Reservation.reservation.Id_reservation;
                    }
                    catch (Exception)
                    {
                        last_reserva = 0;
                    }
                    
                    int id_chauffeur = driver.Id_Chauffeur;
                    string xml = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:api=\"http://api\"> <soapenv:Header/> <soapenv:Body> <api:UpdateLocation> <api:lat>"+lat+"</api:lat> <api:lon>"+lon+"</api:lon> <api:driver_id>"+ id_chauffeur + "</api:driver_id> <api:status>"+status+ "</api:status> <api:last_reservation>" + last_reserva + "</api:last_reservation> </api:UpdateLocation> </soapenv:Body> </soapenv:Envelope>";
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
                    int retorno = 0;
                    foreach (XPathNavigator nav in navigator.Select("//STATUSCODE"))
                    {
                        try
                        {
                            retorno = Convert.ToInt32(nav.Value.ToString().Trim());
                        }
                        catch (Exception)
                        {
                            retorno = 0;
                        }

                    }
                    foreach (XPathNavigator nav in navigator.Select("//LAST_CLOSE"))
                    {
                       
                        try
                        {
                            if (Convert.ToInt32(nav.Value.ToString().Trim()) != 0) {
                                if(Convert.ToInt32(nav.Value.ToString().Trim()) == 2)
                                {
                                    retorno = -2;
                                }
                                else
                                {
                                    retorno = -1;
                                }
                                
                            }
                        }
                        catch (Exception)
                        {
                            retorno = 0;
                        }

                    }
                    foreach (XPathNavigator nav in navigator.Select("//ACTION"))
                    {

                        try
                        {
                            if (nav.Value.ToString().Trim() != "")
                            {
                                cache_action = nav.Value.ToString().Trim();
                                retorno = -50 - Convert.ToInt32(nav.Value.ToString().Trim().Split('@')[2]);
                            }
                        }
                        catch (Exception)
                        {
                            retorno = 0;
                        }

                    }
                    sr.Close();
                    res.Close();
                    if (retorno != 0)
                    {
                        Debug.WriteLine(retorno);
                        return retorno;
                    }
                    else
                    {
                        return retorno;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;
            }
        }
    }
    }
