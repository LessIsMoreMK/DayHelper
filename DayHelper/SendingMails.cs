﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DayHelper
{
    class SendingMails
    {
        public void sendmessage()
        {
            var smtpServerName = ConfigurationManager.AppSettings["SmtpServer"];
            var port = ConfigurationManager.AppSettings["Port"];
            var senderEmailId = ConfigurationManager.AppSettings["SenderEmailId"];
            var senderPassword = ConfigurationManager.AppSettings["SenderPassword"];

            //user
            var sendTo="";//= musimy z innej klasy podstawia pod w tą zm. użytkownika
            var sendSubject = "Test"; // Nagłówek
            var sendText = "Hi, it`s simply test";// text

            var smptClient = new SmtpClient(smtpServerName, Convert.ToInt32(port))
            {
                Credentials = new NetworkCredential(senderEmailId, senderPassword),
                EnableSsl = true
            };
            smptClient.Send(senderEmailId, sendTo, sendSubject, sendText);


        }
       


    }
}
