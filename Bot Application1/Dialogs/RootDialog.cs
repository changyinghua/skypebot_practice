using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;

namespace Bot_Application1.Dialogs {
    [Serializable]
    public class RootDialog : IDialog<object> {
        public Task StartAsync(IDialogContext context) {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result) {
            
            try{
                var activity = await result as Activity;

                string[] separators = { ",", "!", ";", " " };

                string keyword = ConfigurationManager.AppSettings["keyword"];
                List<string> keywordList = keyword.Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).Where(x => x.Length > 0).ToList();

                string send = ConfigurationManager.AppSettings["send"];
                List<string> sendList = send.Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).Where(x => x.Length > 0).ToList();

                if(activity.Text.Contains("123")){
                    DateTime dayOff = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 18, 0, 0);
                    double dd = dayOff.Subtract(DateTime.UtcNow.AddHours(8)).TotalMinutes;
                    await context.PostAsync("倒數"+dd.ToString()+"分鐘");
                }

                int index = keywordList.FindIndex(T => T.Contains(activity.Text));
                if (index != -1) {
                    await context.PostAsync(sendList[index]);
                } else {
                    // calculate something for us to return
                    int length = (activity.Text ?? string.Empty).Length;
                    // return our reply to the user
                    //await context.PostAsync($"You sent {activity.Text} which was {length} characters");
                    await context.PostAsync("test");
                }


                context.Wait(MessageReceivedAsync);
            } catch(Exception ex){
                await context.PostAsync(ex.Message);
            }
           
        }
    }
}