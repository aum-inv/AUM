using OM.PP.Chakra.Ctx;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OM.Upaya.Chakra.ExApi
{
    public static class TelegramBotApi
    {
        //https://api.telegram.org/bot845988614:AAHDCaynmltJlqfQ0WbzeovmtlcsO1pQyjo/getUpdates
        private static string id = "845988614:AAHDCaynmltJlqfQ0WbzeovmtlcsO1pQyjo";
        public static async Task SendMessageAsync(string msg)
        {
            try
            {
                //var bot = new TelegramBotClient("690049:7dd9517017a16854ddaaa23852711407");
                var bot = new TelegramBotClient(id);

                var me = bot.GetMeAsync();

                var result = await bot.SendTextMessageAsync(new Telegram.Bot.Types.ChatId(729502769), msg);
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        private static TelegramBotClient receiveBot = null;
        public static void StartReceiving()
        {
            if (receiveBot == null)
            {
                receiveBot = new TelegramBotClient(id);

                receiveBot.StartReceiving();

                receiveBot.OnUpdate += ReceiveBot_OnUpdate;
            }
        }

        private static void ReceiveBot_OnUpdate(object sender, Telegram.Bot.Args.UpdateEventArgs e)
        {
            string msg = e.Update.Message.Text;

            if (msg.ToUpper() == "/HELP")
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("/ord:Item:Position(1or2):Qty");
                sb.AppendLine("/app:xingapp:loginIndex(0-3)");

                var task = SendMessageAsync(sb.ToString());
            }
            else
            {
                if (msg.StartsWith("/"))
                {
                    var command = msg.Substring(1, 3).ToUpper();
                    if (command == "ORD")
                    {
                        //   /ORD:CL:1:1
                        string commandStr = msg.Substring(5);
                        string[] commandSplit = commandStr.Split(':');
                        string itemCode = commandSplit[0];
                        string position = commandSplit[1];
                        string quantity = commandSplit[2];

                        if ((itemCode.Length == 2 || itemCode.Length == 3)
                           && position.Length == 1
                           && (quantity.Length > 0 && quantity.Length < 4))
                            SellBuy(itemCode, position, quantity);
                    }
                    else if (command == "APP")
                    {
                        string commandStr = msg.Substring(5);
                        string[] commandSplit = commandStr.Split(':');
                        string appName = commandSplit[0].ToUpper().Trim();
                        string loginIndex = commandSplit[1];
                        if (appName == "XINGAPP")
                        {
                            //C:\ABCProject\AUM\OM.PP\OM.PP.XingApp\bin\Debug\OM.PP.XingApp.exe 0
                            foreach (var process in Process.GetProcessesByName("OM.PP.XingApp"))
                            {
                                process.Kill();
                            }

                            System.Threading.Thread.Sleep(100);
                            var p = new System.Diagnostics.Process();
                            p.StartInfo.FileName = @"C:\ABCProject\AUM\OM.PP\OM.PP.XingApp\bin\Debug\OM.PP.XingApp.exe";
                            p.StartInfo.Arguments = loginIndex;
                            p.Start();
                        }
                    }
                }
            }
        }

        private static async void SellBuy(string itemCode, string position, string quantity)
        {
            try
            {
                ExApi.XingApi.Order("메신저주문", itemCode, position, quantity);              
                await SendMessageAsync("메신저 주문완료");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
