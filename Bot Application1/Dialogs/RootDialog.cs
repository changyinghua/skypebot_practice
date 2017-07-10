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

                if(activity.Text.Contains("123")){
                    DateTime dayOff = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 18, 0, 0);
                    double dd = dayOff.Subtract(DateTime.UtcNow.AddHours(8)).TotalMinutes;
                    await context.PostAsync("倒數"+dd.ToString()+"分鐘");
                }
                
                
                if(activity.Text.Contains("冷清")){
                    await context.PostAsync("慘");
                }
                if (activity.Text.Contains("小雨")) {
                    await context.PostAsync("志峰:人生污點");
                }
                if (activity.Text.Contains("辭")|| activity.Text.Contains("慈")) {
                    await context.PostAsync("志峰:這次認真沒有4000一定走");
                }
                if (activity.Text.Contains("很濕")) {
                    await context.PostAsync("西歐:很濕真的很舒服");
                }


             
                    //else {
                    //    // calculate something for us to return
                    //    int length = (activity.Text ?? string.Empty).Length;
                    //    // return our reply to the user
                    //    //await context.PostAsync($"You sent {activity.Text} which was {length} characters");
                     
                    //    await context.PostAsync("test");
                    //}
                

                context.Wait(MessageReceivedAsync);
            } catch(Exception ex){
                await context.PostAsync(ex.Message);
            }
           
        }
    }
}