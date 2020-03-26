using OM.PP.Chakra.Ctx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OM.Atman.Chakra.App.Alerts
{
    public class TelegramUtil
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
            
            var command = msg.Split(':');

            if (command.Length == 3)
            {
                string itemCode = command[0];
                string position = command[1];
                string quantity = command[2];

                if((itemCode.Length == 2 || itemCode.Length == 3)
                    && position.Length == 1
                    && (quantity.Length > 0 && quantity.Length < 4))
                    SellBuy(itemCode, position, quantity);
            }
        }

        private static async void SellBuy(string itemCode, string position, string quantity)
        {
            try
            {
                XingContext.Instance.ClientContext.OrderBuySell(itemCode, position, "1", "0", quantity);

                await SendMessageAsync("메신저 주문완료");
            }
            catch (Exception)
            {
            }
        }
    }
}
