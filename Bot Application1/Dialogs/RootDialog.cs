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
                    TimeSpan dd = dayOff.Subtract(DateTime.UtcNow.AddHours(8));

                    await context.PostAsync("倒數"+Math.Floor(dd.TotalMinutes)+"分鐘"+dd.Seconds+"秒");
                }
                
                
                else if(activity.Text.Contains("冷清")){
                    await context.PostAsync("慘");
                }
                else if (activity.Text.Contains("小雨")) {
                    await context.PostAsync("志峰:人生污點");
                }
                else if (activity.Text.Contains("辭")|| activity.Text.Contains("慈")) {
                    await context.PostAsync("志峰:這次認真沒有4000一定走");
                }
                else if(activity.Text.Contains("很濕")) {
                    await context.PostAsync("西歐:很濕真的很舒服");
                    await context.PostAsync("西歐:一下子就進去");
                    await context.PostAsync("西歐:各種包覆");
                }

                else if(activity.Text.Contains("麵")){
                    await context.PostAsync("資訊部 祥凱#624:不吃麵");
                } else if (activity.Text.Contains("學弟")) {
                    await context.PostAsync("晚點到");

                } else if (activity.Text.Contains("董事長兒子")) {
                    await context.PostAsync("riolove chang");
                } else if (activity.Text.Contains("文B")) {
                    await context.PostAsync("打醬油");
                } else if (activity.Text.Contains("風歌")|| activity.Text.Contains("志峰") || activity.Text.Contains("峰")) {
                    await context.PostAsync("開開");
                } else {
                    // calculate something for us to return
                    int length = (activity.Text ?? string.Empty).Length;
                    // return our reply to the user
                    //await context.PostAsync($"You sent {activity.Text} which was {length} characters");
                    int i = new Random().Next(0, 5);
                    List<string> s = new List<string>();
                    s.Add("你就當練功幫我修這個Bug吧！");
                    s.Add("你要想未來的分紅幫我修這個Bug吧！");
                    s.Add("你就當測試幫我做這個案子吧！");
                    s.Add("你就當學經驗幫我偷這些資料吧！");
                    s.Add("你要想未來的分紅幫我墊這個小錢吧！");
                    s.Add("你就當學經驗幫我解這個問題吧！");
                    await context.PostAsync(s[i]);
                }


                context.Wait(MessageReceivedAsync);
            } catch(Exception ex){
                await context.PostAsync(ex.Message);
            }
           
        }
    }
}