using EasyAutomationFramework;
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
        private ListView listView;

        public WhatsAppSendMessage(ListView listView)
        {
            this.listView = listView;
        }

        public void EnterSite()
        {
            //StartBrowser(TypeDriver.GoogleChorme);

            //Navigate("https://web.whatsapp.com/");

            //WaitForLoad();
        }
        public void SendMessage(string message, List<string> to, List<string> nome)
        {
            foreach (var a in nome)
            {
                MessageBox.Show(a);
            }
            StartBrowser(TypeDriver.GoogleChorme);

            Navigate("https://web.whatsapp.com/");

            WaitForLoad();

            Thread.Sleep(TimeSpan.FromSeconds(18));

            var i = 0;
            foreach (var item in to)
            {

                try
                {

                    var elementSearch = AssignValue(TypeElement.Xpath, "//*[@id=\"side\"]/div[1]/div/div/div[2]/div/div[1]/p", item);

                    elementSearch.element.Clear();

                    elementSearch.element.SendKeys(OpenQA.Selenium.Keys.Enter);

                    string mensagemcustomizada = message.Replace("{nome}", nome[i]);

                    var elementMessage = AssignValue(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]", mensagemcustomizada);

                    ListViewItem newcontato = new ListViewItem();



                    if (elementMessage.Sucesso == false)
                    {
                        newcontato.SubItems.Add("Erro");
                    }
                    else
                    {
                        elementMessage.element.SendKeys(OpenQA.Selenium.Keys.Enter);
                        newcontato.SubItems.Add("Correto");
                    }


                }
                catch (NullReferenceException ex)
                {

                    MessageBox.Show("Erro");
                }
                i++;

            }

        }
    }
}