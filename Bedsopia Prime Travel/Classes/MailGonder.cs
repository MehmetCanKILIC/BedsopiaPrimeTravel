using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;

using System.Net.Mail;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
//using Microsoft.Exchange.WebServices.Data;

/// <summary>
/// Summary description for MailGonder
/// </summary>
/// 



public class MailGonder
{


    public static string SendOutlookMail(string mailBaslik, string mailIcerik, string aliciPosta, object ekDosya = null)
    {

 
        string gonderimSonucu = "";
        //return gonderimSonucu;

        int mailAdresiSayisi = Regex.Matches(aliciPosta, ";").Count + 1;
        //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
        client.Port = 587;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("No-reply@primetravel.com.tr", "Pt2022*!");
        client.EnableSsl = true;
        client.Credentials = credentials;
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("No-reply@primetravel.com.tr", "Bedsopia Prime Travel"); //gönderici olarak görünen mail bilgileri
        mail.Priority = MailPriority.High;
        mail.Subject = mailBaslik;

        if (mailAdresiSayisi > 1)
        {
            string[] aliciPostaAdresleri = aliciPosta.Split(';');

            for (int i = 0; i < mailAdresiSayisi; i++)
            {
                string aliciPostaAdresi = aliciPostaAdresleri[i];
                if (aliciPostaAdresi!="")
                {
                    mail.To.Add(new MailAddress(aliciPostaAdresi, ""));
                }
            }
        }
        else
        {
            mail.To.Add(new MailAddress(aliciPosta, ""));
        }

        mail.Body = mailIcerik;
        mail.IsBodyHtml = true;

        if (ekDosya != null)
        {
            mail.Attachments.Add(new Attachment(ekDosya.ToString()));
        }

        //NetworkCredential girisIzni = new NetworkCredential("petlasb2b@zemzemgrup.com", "PetLas2450707");
        //client.EnableSsl = true;
        //client.Credentials = girisIzni;

        try
        {
            client.Send(mail);

            gonderimSonucu = "OK";
            return gonderimSonucu;
        }
        catch (Exception ex)
        {
            //ex.Message.ToString();
            gonderimSonucu = ex.Message;
            return gonderimSonucu;
        }
    }

   



    public static void SmtpNatro(string mailBaslik, string mailIcerik, string aliciPosta)
    {
        SmtpClient client = new SmtpClient("mail.timo-tech.com", 587);
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("noreply@timo-tech.com", "Timotech"); //gönderici olarak görünen mail bilgileri
        mail.Priority = MailPriority.High;
        mail.Subject = mailBaslik;
        mail.To.Add(new MailAddress(aliciPosta, ""));
        mail.Body = mailIcerik;
        mail.IsBodyHtml = true;

        NetworkCredential girisIzni = new NetworkCredential("noreply@timo-tech.com", "GWoh97Y1");
        //client.EnableSsl = true;
        client.Credentials = girisIzni;

        try
        {
            client.Send(mail);
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }


    public static void SmtpNatroEkli(string mailBaslik, string mailIcerik, string aliciPosta, List<string> listeDosya,object siparisNo)
    {
        SmtpClient client = new SmtpClient("mail.timo-tech.com", 587);
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("noreply@timo-tech.com", "Timotech"); //gönderici olarak görünen mail bilgileri
        mail.Priority = MailPriority.High;
        if (siparisNo!=null)
        {
            mail.Subject = mailBaslik + " " + siparisNo;

        }else
        {
            mail.Subject = mailBaslik;
        }
        mail.To.Add(new MailAddress(aliciPosta, ""));
        mail.Body = mailIcerik;
        mail.IsBodyHtml = true;

        if (listeDosya.Count > 0)
        {
            for (int i = 0; i < listeDosya.Count; i++)
            {
                string ekliDosya = listeDosya[i];

                mail.Attachments.Add(new Attachment(ekliDosya));
            }
        }

        NetworkCredential girisIzni = new NetworkCredential("noreply@timo-tech.com", "GWoh97Y1");
        //client.EnableSsl = true;
        client.Credentials = girisIzni;

        try
        {
            client.Send(mail);
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }



    private static bool RedirectionUrlValidationCallback(string redirectionUrl)
    {
        bool result = false;

        Uri redirectionUri = new Uri(redirectionUrl);

        if (redirectionUri.Scheme == "https")
        {
            result = true;
        }
        return result;
    }





}