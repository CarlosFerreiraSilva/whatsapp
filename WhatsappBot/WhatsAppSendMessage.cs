﻿using EasyAutomationFramework;
using sun.security.krb5.@internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsappBot
{
    public class WhatsAppSendMessage : Web
    {
        public void EnterSite()
        {
            //StartBrowser(TypeDriver.GoogleChorme);

            //Navigate("https://web.whatsapp.com/");

            //WaitForLoad();
        }
        public void SendMessage(string message, List<string> to)
        {
            StartBrowser(TypeDriver.GoogleChorme);

            Navigate("https://web.whatsapp.com/");

            WaitForLoad();

            Thread.Sleep(TimeSpan.FromSeconds(18));

            foreach (var item in to)
            {

                var elementSearch = AssignValue(TypeElement.Xpath, "//*[@id=\"side\"]/div[1]/div/div/div[2]/div/div[1]/p", item);

                elementSearch.element.Clear();

                elementSearch.element.SendKeys(OpenQA.Selenium.Keys.Enter);

                var elementMessage = AssignValue(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]", message);

                elementMessage.element.SendKeys(OpenQA.Selenium.Keys.Enter);
            }

        }
    }
}