using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using ConsoleApp2;
using ConsoleApp22;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Text;
using System.Timers;
using System.Threading;

namespace Bot_Application1.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {



        public RootDialog()
        {

        }

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {

            try
            {
              
                //  CountDown.timer.Stop();
                string[] separators = { ",", "!", ";", " " };

                //string keyword = ConfigurationManager.AppSettings["keyword"];
                //List<string> keywordList = keyword.Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).Where(x => x.Length > 0).ToList();

                //string send = ConfigurationManager.AppSettings["send"];
                //List<string> sendList = send.Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).Where(x => x.Length > 0).ToList();
                //await context.PostAsync(context.Activity.Conversation.Id);
                //await context.PostAsync(context.Activity.ChannelData);

                var activity = await result as Activity;
                int n;
                
                if (Contact.history.Count > 30) {
                    Contact.history.RemoveAt(0);
                }
                if (!activity.Text.Contains("對話紀錄")) {
                    Contact.history.Add(Contact.Name+" : "+activity.Text.Remove(0,9));
                }
              
                if (activity.Text.Contains("123"))
                {
                    DateTime dayOff = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 18, 0, 0);
                    TimeSpan dd = dayOff.Subtract(DateTime.UtcNow.AddHours(8));

                    if (Contact.Id.Equals("29:1-lHdGRIXVjWxaHlz25WYEmaIM963VpEyI_1gXQ_uz2U"))
                    {
                        await context.PostAsync("倒數" + Math.Floor(dd.TotalMinutes) + "分鐘" + dd.Seconds + "秒,但是有潛規則,下班時間未知");
                    }
                    else
                    {
                        await context.PostAsync("倒數" + Math.Floor(dd.TotalMinutes) + "分鐘" + dd.Seconds + "秒");
                    }
                    //  CountDown.timer.Start();


                    // await context.PostAsync("http://imgur.com/cVNPngl");
                }else if(activity.Text.Contains("峰哥副理")){
                    await context.PostAsync("估一下，要完成店長排班你還需要幾個工作天.如果下週一，二加班寫的完嗎？");
                }
                else if(activity.Text.Contains("101")){
                    /*
                     *   ┃┃┃
     ┃┃┃
  ┃┃┃
┏━━━━━━┓
┃┏┓┏┓┏┓┃
┃┗┛┗┛┗┛┃
┃┏┓┏┓┏┓┃
┃┗┛┗┛┗┛┃
┃┏┓┏┓┏┓┃
┃┗┛┗┛┗┛┃
┃┏┓┏┓┏┓┃
┃┗┛┗┛┗┛┃
                     */
                    await context.PostAsync("          ┃┃┃");
                    await context.PostAsync("          ┃┃┃");
                    await context.PostAsync("┏━━━━━━┓");
                    await context.PostAsync("┃┏┓┏┓┏┓┃");
                    await context.PostAsync("┃┗┛┗┛┗┛┃");
                    await context.PostAsync("┃┏┓┏┓┏┓┃");
                    await context.PostAsync("┃┗┛┗┛┗┛┃");
                    await context.PostAsync("┃┏┓┏┓┏┓┃");
                    await context.PostAsync("┃┗┛┗┛┗┛┃");
                    await context.PostAsync("┃┏┓┏┓┏┓┃");
                    await context.PostAsync("┃┗┛┗┛┗┛┃");
                    await context.PostAsync("┃┏┓┏┓┏┓┃");
                    await context.PostAsync("┃┗┛┗┛┗┛┃");
                    await context.PostAsync("┃┏┓┏┓┏┓┃");
                    await context.PostAsync("┃┗┛┗┛┗┛┃");
                    await context.PostAsync("┃┏┓┏┓┏┓┃");
                    await context.PostAsync("┃┗┛┗┛┗┛┃");
                    await context.PostAsync("┃┏┓┏┓┏┓┃");
                    await context.PostAsync("┃┗┛┗┛┗┛┃");
                    await context.PostAsync("┃┏┓┏┓┏┓┃");
                    await context.PostAsync("┃┗┛┗┛┗┛┃");
                    await context.PostAsync("┃┏┓┏┓┏┓┃");
                    await context.PostAsync("┃┗┛┗┛┗┛┃");
                    await context.PostAsync("┃┏┓┏┓┏┓┃");
                    await context.PostAsync("┃┗┛┗┛┗┛┃");
                    await context.PostAsync("┃┏┓┏┓┏┓┃");
                    await context.PostAsync("┃┗┛┗┛┗┛┃");
                    await context.PostAsync("┃┏┓┏┓┏┓┃");
                    await context.PostAsync("┃┗┛┗┛┗┛┃");
                    await context.PostAsync("┃┏┓┏┓┏┓┃");
                    await context.PostAsync("┃┗┛┗┛┗┛┃");
                    await context.PostAsync("┃┏┓┏┓┏┓┃");
                    await context.PostAsync("┃┗┛┗┛┗┛┃");
                    await context.PostAsync("┃┏┓┏┓┏┓┃");
                    await context.PostAsync("┃┗┛┗┛┗┛┃");








                } else if (activity.Text.Contains("456"))
                {
                    DateTime breakOff = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 12, 0, 0);
                    TimeSpan dd = breakOff.Subtract(DateTime.UtcNow.AddHours(8));
                    DateTime breakOff2 = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 12, 30, 0);
                    TimeSpan dd2 = breakOff2.Subtract(DateTime.UtcNow.AddHours(8));
                    //  CountDown.timer.Start();

                    if (Contact.Id.Equals("29:1zzRM1BUX5XWVA7Ral9vpEeTa-DCYhRGE4aCyOzYgpHo"))
                    {
                        await context.PostAsync("倒數" + Math.Floor(dd2.TotalMinutes) + "分鐘" + dd2.Seconds + "秒 吃飯");
                    }
                    else
                    {
                        await context.PostAsync("倒數" + Math.Floor(dd.TotalMinutes) + "分鐘" + dd.Seconds + "秒 吃飯");
                    }


                }else if(activity.Text.Contains("遲到")){
                    string s = "我還是希望我們資訊部同仁應該潔身自愛，管理好自己，我不喜歡管人，如果做不到，那就考慮是否適合留在資訊部，" +
                    "我不會浪費時間在需要監督的人身上，也不會和無法管理好自己的人共事。以上 請配合 謝謝";
                    string p = "CLint";
                    await context.PostAsync(s);
                    //await context.PostAsync(p);
                }
                else if (activity.Text.Contains("離職賭盤"))
                {
                    await context.PostAsync("志峰:會1.9 不會1.1");
                }
                else if (activity.Text.Contains("我的下注"))
                {

                    // string s = Contact.GetAppSetting(Contact.Id);
                    await context.PostAsync(Contact.Bet[Contact.Id]);
                }
                else if (activity.Text.Contains("@peterbot 下注"))
                {
                    char[] se = { ' ' };
                    string[] s = activity.Text.Split(se);
                    // Contact.SetAppSetting(Contact.Id, s[2]);
                    Contact.Bet[Contact.Id] = s[2];
                    await context.PostAsync("下注 " + s[2] + " 成功");
                }

                else if (activity.Text.Contains("勞保級距"))
                {
                    HttpClient client = new HttpClient();
                    string x = "http://apiservice.mol.gov.tw/OdService/download/A17000000J-020014-gGq";
                    HttpResponseMessage m = client.GetAsync(x).Result;
                    string s = m.Content.ReadAsStringAsync().Result.ToString();

                    molgovtw value = molgovtw.Deserialize(s);

                    //  Console.WriteLine($"{value.FIELDS.colum_1,-15} {value.FIELDS.colum_2.PadRight(15)} {value.FIELDS.colum_3.PadRight(15)} {value.FIELDS.colum_4.PadRight(15)}");
                    await context.PostAsync($"{value.FIELDS.colum_1,-15} {value.FIELDS.colum_2.PadRight(15)} {value.FIELDS.colum_3.PadRight(15)} {value.FIELDS.colum_4.PadRight(15)}");
                    foreach (molgovtwDATA data in value.DATA)
                    {
                        // Console.WriteLine($"{names[i],-8} {ages[i]}");
                        //Console.WriteLine($"{data.colum_1.PadRight(15)} {data.colum_2.PadRight(15)}  {data.colum_3.PadRight(20)}  {data.colum_4.PadRight(15)}");
                        if (data.colum_1.Equals("一般勞工") && data.colum_1 != "")
                        {
                            await context.PostAsync($"{data.colum_1.PadRight(15)} {data.colum_2.PadRight(15)}  {data.colum_3.PadRight(20)}  {data.colum_4.PadRight(15)}");
                        }
                    }
                }
                else if (activity.Text.Contains("勞健保分攤表"))
                {
                    HttpClient client = new HttpClient();
                    string x = "http://apiservice.mol.gov.tw/OdService/download/A17000000J-020015-ipY";
                    HttpResponseMessage m = client.GetAsync(x).Result;
                    string s = m.Content.ReadAsStringAsync().Result.ToString();

                    molgovtw2 value = molgovtw2.Deserialize(s);

                    // Console.WriteLine(value.FIELDS.colum_1 + " " + value.FIELDS.colum_2 + " " + value.FIELDS.colum_3 + " " + value.FIELDS.colum_4 + " " + value.FIELDS.colum_5 + " " + value.FIELDS.colum_6);
                    await context.PostAsync($"{value.FIELDS.colum_1,-8}{value.FIELDS.colum_2.PadLeft(8)} {value.FIELDS.colum_3.PadLeft(8)}{value.FIELDS.colum_4.PadLeft(10)}{ value.FIELDS.colum_5.PadLeft(10) } {value.FIELDS.colum_6.PadLeft(10)}");
                    foreach (ConsoleApp22.molgovtwDATA data in value.DATA)
                    {
                        // Console.WriteLine($"{names[i],-8} {ages[i]}");

                        // Console.WriteLine(data.colum_1 + "       " + data.colum_2 + "       " + data.colum_3 + "     " + data.colum_4 + "        " + data.colum_5 + "           " + data.colum_6);
                        await context.PostAsync($"{data.colum_1.ToString(),-8 }{data.colum_2.ToString().PadLeft(10)}{data.colum_3.PadLeft(12)}{data.colum_4.ToString().PadLeft(16)}{data.colum_5.ToString().PadLeft(15)}{data.colum_6.ToString().PadLeft(15)}");

                    }
                }
                else if (activity.Text.Equals("@peterbot 天氣"))
                {
                    HttpClient client = new HttpClient();

                    string x2 = "http://opendata.cwb.gov.tw/opendata/MFC/F-C0044-001.FW01";

                    HttpResponseMessage mR = client.GetAsync(x2).Result;
                    string s2 = System.Text.Encoding.GetEncoding("Big5").GetString(mR.Content.ReadAsByteArrayAsync().Result); ;
                    await context.PostAsync(s2);






                    //string x = "http://opendata.cwb.gov.tw/govdownload?dataid=F-C0032-005&authorizationkey=rdec-key-123-45678-011121314";
                    //HttpResponseMessage m = client.GetAsync(x).Result;
                    //string s = m.Content.ReadAsStringAsync().Result.ToString();

                    //cwbopendata value = cwbopendata.Deserialize(s);
                    //int i = 0;

                    //foreach (cwbopendataDatasetLocation d in value.dataset.location) {
                    //    // Console.WriteLine(d.locationName);
                    //    if (d.locationName.Equals("台北市") || d.locationName.Equals("臺北市") || d.locationName.Equals("新竹市") || d.locationName.Equals("桃園市")) {
                    //        await context.PostAsync(d.locationName);
                    //        foreach (cwbopendataDatasetLocationWeatherElement e in d.weatherElement) {

                    //            switch (e.elementName) {
                    //                case "Wx":
                    //                    await context.PostAsync("天氣概況");
                    //                    break;
                    //                case "MaxT":
                    //                    await context.PostAsync("最高溫度");
                    //                    break;
                    //                case "MinT":
                    //                    await context.PostAsync("最低溫度");
                    //                    break;
                    //            }
                    //            foreach (cwbopendataDatasetLocationWeatherElementTime time in e.time) {
                    //                //await context.PostAsync(time.startTime.ToShortDateString() + " " + time.parameter.parameterName + " " + time.parameter.parameterValue + "°C");
                    //                string ss = "";
                    //                if (time.parameter.parameterUnit != null) {
                    //                    if (time.parameter.parameterUnit.Equals("C")) {
                    //                        ss = "°C";
                    //                    }
                    //                }
                    //                if (time.startTime.ToShortDateString() == DateTime.UtcNow.AddHours(8).ToShortDateString()) {
                    //                    await context.PostAsync(time.startTime + "~" + time.endTime + " " + time.parameter.parameterName + "" + ss);
                    //                    //  Console.WriteLine(time.parameter.parameterName + " " + time.parameter.parameterValue);
                    //                }
                    //            }
                    //            await context.PostAsync("-----------------------------------");
                    //        }
                    //    }

                    //}
                }
                //else if (activity.Text.Contains("華華貓"))
                //{
                //    await context.PostAsync("廷廷貓");
                //}
                else if (activity.Text.Contains("洗版"))
                {
                    string s1 = "善現啟請分第二時 長老須菩提在大眾中，即從座起，偏袒右肩，右膝著地，合掌恭敬。而白佛言：「希有！世尊。如來善護念諸菩薩，善付囑諸菩薩。世尊！善男子、善女人，發阿耨 多羅三藐三菩提心，云何應住？云何降伏其心？」佛言：「善哉！善哉！須菩提！如汝所說，如來善護念諸菩薩，善付囑諸菩薩。汝今諦聽，當為汝說。善男子、善 女人，發阿耨多羅三藐三菩提心，應如是住，如是降伏其心。」「唯然！世尊！願樂欲聞。」";
                    string s2 = "大乘正宗分第三佛 告須菩提：「諸菩薩摩訶薩，應如是降伏其心：所有一切眾生之類─若卵生、若胎生、若濕生、若化生；若有色、若無色；若有想、若無想；若非有想非無想，我皆 令入無餘涅槃而滅度之。如是滅度無量無數無邊眾生，實無眾生得滅度者。何以故？須菩提！若菩薩有我相、人相、眾生相、壽者相，即非菩薩。」";
                    string s3 = "妙行無住分第四復 次：「須菩提！菩薩於法，應無所住，行於布施。所謂不住色布施，不住聲、香、味、觸、法布施。須菩提！菩薩應如是布施，不住於相。何以故？若菩薩不住相布 施，其福德不可思量。須菩提！於意云何？東方虛空可思量不？」「不也，世尊！」「須菩提！南、西、北方、四維、上、下虛空，可思量不？」「不也。世尊！」 「須菩提！菩薩無住相布施，福德亦復如是，不可思量。須菩提！菩薩但應如所教住！」";
                    string s4 = "如理實見分第五「須菩提！於意云何？可以身相見如來不？」「不也，世尊！不可以身相得見如來。何以故？如來所說身相，即非身相。」佛告須菩提：「凡所有相，皆是虛妄。若見諸相非相，即見如來。」";
                    string s5 = "正信希有分第六須 菩提白佛言：「世尊！頗有眾生，得聞如是言說章句，生實信不？」佛告須菩提：「莫作是說！如來滅後，後五百歲，有持戒修福者，於此章句，能生信心，以此為 實。當知是人，不於一佛、二佛、三四五佛而種善根，已於無量千萬佛所種諸善根。聞是章句，乃至一念生淨信者；須菩提！如來悉知悉見，是諸眾生得如是無量福 德。何以故？是諸眾生，無復我相、人相、眾生相、壽者相、無法相，亦無非法相。何以故？是諸眾生若心取相，即為著我、人、眾生、壽者。若取法相，即著我、 人、眾生、壽者。何以故？若取非法相，即著我、人、眾生、壽者。是故不應取法，不應取非法。以是義故，如來常說：汝等比丘！知我說法，如筏喻者；法尚應 捨，何況非法？」";
                    string s6 = "無得無說分第七「須菩提！於意云何？如來得阿耨多羅三藐三菩提耶？如來有所說法耶？」須菩提言：「如我解佛所說義，無有定法，名阿耨多羅三藐三菩提；亦無有定法如來可說。何以故？如來所說法，皆不可取、不可說；非法、非非法。所以者何？一切賢聖，皆以無為法，而有差別。」";
                    string s7 = "依法出生分第八「須菩提！於意云何？若人滿三千大千世界七寶，以用布施。是人所得福德，寧為多不？須菩提言：「甚多。世尊！何以故？是福德，即非福德性。是故如來說福德多。」「若復有人，於此經中，受持乃至四句偈等，為他人說，其福勝彼。何以故？須菩提！一切諸佛，及諸佛阿耨多羅三藐三菩提法，皆從此經出。須菩提！所謂佛法者，即非佛法。」";
                    string s8 = "一相無相分第九「須 菩提！於意云何？須陀洹能作是念，我得須陀洹果不？」須菩提言：「不也。世尊！何以故？須陀洹名為入流，而無所入；不入色、聲、香、味、觸、法。是名須陀 洹。」「須菩提！於意云何？斯陀含能作是念，我得斯陀含果不？」須菩提言：「不也。世尊！何以故？斯陀含名一往來，而實無往來，是名斯陀含。」「須菩提， 於意云何？阿那含能作是念，我得阿那含果不？」須菩提言：「不也。世尊！何以故？阿那含名為不來，而實無不來，是故名阿那含。」「須菩提！於意云何？阿羅 漢能作是念，我得阿羅漢道不？」須菩提言：「不也。世尊！何以故？實無有法名阿羅漢。世尊！若阿羅漢作是念，我得阿羅漢道，即為著我、人、眾生、壽者。世 尊！佛說我得無諍三昧，人中最為第一，是第一離欲阿羅漢。世尊！我不作是念：『我是離欲阿羅漢。』世尊！我若作是念，我得阿羅漢道，世尊則不說須菩提是樂 阿蘭那行者，以須菩提實無所行，而名須菩提，是樂阿蘭那行。」";
                    await context.PostAsync(s1 + s2 + s3 + s4 + s5 + s6 + s7 + s8);
                }
                else if (activity.Text.Contains("颱風"))
                {
                    await context.PostAsync("http://www.cwb.gov.tw/V7/prevent/typhoon/ty.htm");
                    await context.PostAsync("https://www.dgpa.gov.tw/typh/typh/nds.html");
                }
                else if (activity.Text.ToUpper().Contains("BANG"))
                {
                    await context.PostAsync("https://ebcnews.s3.amazonaws.com/images/2017/05/25/14957248034094jJyk.jpg");
                }
                else if (activity.Text.Contains("冷清"))
                {


                    await context.PostAsync("慘,沒人");
                    await Task.Delay(2000);
                    await context.PostAsync("峰哥安安");
                    await Task.Delay(2000);
                    await context.PostAsync("小雞安安");
                    await Task.Delay(2000);
                    await context.PostAsync("文B安安");
                    await Task.Delay(2000);
                    await context.PostAsync("yo安安");
                    await Task.Delay(2000);
                    await context.PostAsync("峰哥什麼時候辭職");
                    await Task.Delay(2000);
                    await context.PostAsync("陪我聊天阿");
                    await Task.Delay(2000);
                    await context.PostAsync("西歐請客啊");
                    await Task.Delay(2000);


                    //var f = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
                    //var ReconnectTask =f.StartNew(() =>
                    //{

                    //});
                    ////  Thread.Sleep(5000);
                    //await context.PostAsync("各位想話題阿");
                    ////   Thread.Sleep(5000);
                    //await context.PostAsync("CO安安");
                    ////   Thread.Sleep(5000);
                    //await context.PostAsync("峰哥安安");

                    //await context.PostAsync("小雞安安");

                    //await context.PostAsync("峰哥什麼時候辭職");

                    //await context.PostAsync("陪我聊天阿");

                    //await context.PostAsync("西歐請客啊");
                    //var f = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
                    //var ReconnectTask = f.StartNew(() =>
                    // {
                    //     Thread.Sleep(5000);
                    // });


                }
                else if (activity.Text.ToUpper().Contains("UML"))
                {
                    await context.PostAsync("統一塑模語言（英語：Unified Modeling Language，縮寫UML）是非專利的第三代塑模和規約語言。 UML是一種開放的方法，用於說明、可視化、構建和編寫一個正在開發的、物件導向的、軟體密集系統的製品的開放方法。");
                }
                else if (activity.Text.Contains("小雨"))
                {
                    await context.PostAsync("志峰:人生污點");
                    await context.PostAsync("http://imgur.com/JRbYdys");
                }
                else if (activity.Text.Contains("辭") || activity.Text.Contains("慈"))
                {
                    await context.PostAsync("http://imgur.com/l7EXpB5");
                }
                else if (activity.Text.Contains("很濕"))
                {
                    await context.PostAsync("http://imgur.com/vOVqKAW");

                }
                else if (activity.Text.Contains("超爽的") || activity.Text.Contains("超爽der") || activity.Text.Contains("爽"))
                {
                    await context.PostAsync("http://imgur.com/AG5BmjH");

                }
                else if (activity.Text.Contains("舞獅情") || activity.Text.Contains("伍詩晴"))
                {
                    await context.PostAsync("http://imgur.com/Ay9JbPr");

                }
                else if (activity.Text.Contains("麵"))
                {
                    await context.PostAsync("資訊部 祥凱#624:不吃麵");
                }
                else if (activity.Text.Contains("比基尼被逮"))
                {
                    await context.PostAsync("https://imgur.com/HLzLarM");
                }
                else if (activity.Text.Contains("平偉"))
                {
                    await context.PostAsync("https://imgur.com/Xh4F6ry");
                }
                else if (activity.Text.Contains("廟口"))
                {
                    await context.PostAsync("http://imgur.com/AQduRBE");
                }
                else if (activity.Text.Contains("熱量"))
                {
                    await context.PostAsync("http://i.imgur.com/ey6tvcJ.jpg");
                }
                else if (activity.Text.Contains("學弟"))
                {
                    await context.PostAsync("晚點到");

                } else if (activity.Text.Contains("對話紀錄")) {

                    foreach(string s in Contact.history){
                        await context.PostAsync(s);
                    }
                 

                } else if (activity.Text.ToUpper().Contains("YO"))
                {
                    await context.PostAsync("http://imgur.com/ygivezG");

                }
             
                else if (activity.Text.Contains("開盤倒數"))
                {
                    if (Contact.Id.Equals("29:1QDNQ50dEqCIGfRNmO3VE-4QmxhkqVjkjqBa-PKWvfdY"))
                    {
                        DateTime time2 = new DateTime(2017, 09, 01, 8, 30, 0);
                        DateTime now2 = DateTime.UtcNow.AddHours(8);
                        TimeSpan t2 = time2.Subtract(now2);
                        await context.PostAsync("辭職倒數 " + t2.ToString());
                    }
                    else
                    {
                        DateTime time = new DateTime(2017, 08, 04, 11, 00, 0);
                        DateTime now = DateTime.UtcNow.AddHours(8);
                        TimeSpan t = time.Subtract(now);
                        await context.PostAsync("都過了"+Math.Abs(Math.Floor(t.TotalDays))+ "天了,盧志峰還不辭");
                    }
                }
                else if (activity.Text.Contains("峰哥獎金"))
                {
                    await context.PostAsync("2017年7月 1萬2");

                }
                else if (activity.Text.Contains("小雞"))
                {
                    await context.PostAsync("http://imgur.com/gvOPrWQ");

                }
                else if (activity.Text.Contains("鬍鬚張"))
                {
                    if (Contact.Id.Equals("29:1QDNQ50dEqCIGfRNmO3VE-4QmxhkqVjkjqBa-PKWvfdY"))
                    {
                        await context.PostAsync("出來辦個事情還被call 而且明明就是客戶的問題 還在番 還聽不懂我在講什麼");
                    }
                    else
                    {
                        await context.PostAsync("http://imgur.com/PFc9fvB");
                    }
 

                }
                else if (activity.Text.Contains("峰哥組長"))
                {
                    await context.PostAsync("我領導加給只有2000");

                }
                else if (activity.Text.Contains("立委") || activity.Text.Contains("力瑋"))
                {
                    await context.PostAsync("http://imgur.com/MpXUPTJ");
                }
                else if (activity.Text.Contains("小胖"))
                {
                    await context.PostAsync("http://imgur.com/qDbDUx1");
                }
                //else if (activity.Text.Contains("子寧"))
                //{
                //    await context.PostAsync("http://imgur.com/8PEWm1i");
                //}
                else if (activity.Text.Contains("西歐") || activity.Text.ToUpper().Contains("CO"))
                {
                    await context.PostAsync("http://imgur.com/oD2au4w");
                }
                else if (activity.Text.Contains("董事長兒子"))
                {
                    await context.PostAsync("riolove chang");
                }
                else if (activity.Text.Contains("文B"))
                {
                    await context.PostAsync("http://imgur.com/5LExAMa");
                }
                else if (activity.Text.Contains("起床"))
                {
                    await context.PostAsync("現在時間么三三洞，部隊起床");
                }
                else if (activity.Text.Contains("賭盤"))
                {
                    await context.PostAsync("志峰:0~499  1.7 \n 500~1999 1.3 \n 2000~3999 1.5 \n 4000 up 1.9");
                    await context.PostAsync("1550");
                }
                else if (activity.Text.Contains("風歌") || activity.Text.Contains("志峰") || activity.Text.Contains("峰"))
                {
                    //await context.PostAsync("http://imgur.com/CF3oN5i");
                    //await context.PostAsync("http://imgur.com/1kke4ds");
                    await context.PostAsync("在逛104 別吵");
                }//股票
                else if (int.TryParse(activity.Text.Remove(0, 10), out n))
                {
                    if (activity.Text.Remove(0, 10).Count() == 4)
                    {
                        WebClient client = new WebClient();
                        client.Encoding = Encoding.GetEncoding("Big5");
                        string s = "http://tw.stock.yahoo.com/q/q?s=";
                        s += n.ToString();
                        MemoryStream ms = new MemoryStream(client.DownloadData(
                    s));
                        // 使用預設編碼讀入 HTML 
                        HtmlDocument doc = new HtmlDocument();
                        doc.Load(ms, Encoding.GetEncoding("Big5"));
                        // 裝載第一層查詢結果 
                        HtmlDocument docStockContext = new HtmlDocument();

                        docStockContext.LoadHtml(doc.DocumentNode.SelectSingleNode(
                    "/html[1]/body[1]/center[1]/table[2]/tr[1]/td[1]/table[1]").InnerHtml);
                        // 取得個股標頭 
                        HtmlNodeCollection nodeHeaders =
                     docStockContext.DocumentNode.SelectNodes("./tr[1]/th");
                        // 取得個股數值 
                        string[] values = docStockContext.DocumentNode.SelectSingleNode(
                    "./tr[2]").InnerText.Trim().Split('\n');
                        int i = 0;
                        // 輸出資料 
                        foreach (HtmlNode nodeHeader in nodeHeaders)
                        {
                            //Console.WriteLine("Header: {0}, Value: {1}",nodeHeader.InnerText, values[i].Trim());
                            await context.PostAsync(nodeHeader.InnerText + " " + values[i].Trim());
                            i++;
                        }
                        doc = null;
                        docStockContext = null;
                        client = null;
                        ms.Close();
                    }
                }
                else
                {
                    // calculate something for us to return
                    //int length = (activity.Text ?? string.Empty).Length;
                    //// return our reply to the user
                    //await context.PostAsync($"You sent {activity.Text} which was {length} characters");
                   // await context.PostAsync($"You sent {activity.Text}");
                    //int i = new Random().Next(0, 5);
                    //int i2 = new Random().Next(0, 5);
                    //List<string> s = new List<string>();
                    //s.Add("你就當練功");
                    //s.Add("你要想未來的分紅");
                    //s.Add("你就當測試");
                    //s.Add("你就當學經驗");
                    //s.Add("你要想未來的分紅");
                    //s.Add("你就當學經驗");

                    //List<string> s2 = new List<string>();
                    //s2.Add("幫我看程式碼吧！");
                    //s2.Add("幫我做這個案子吧！");
                    //s2.Add("幫我修這個Bug吧！");
                    //s2.Add("幫我偷這些資料吧！");
                    //s2.Add("幫我解這個問題吧！");
                    //s2.Add("幫我墊這個小錢吧！");
                    //await context.PostAsync(s[i] + s2[i2]);
                    List<string> s = new List<string>();
                    s.Add("幹");
                    s.Add("機掰");
                    s.Add("爽拉");
                    s.Add("操你妹");
                    s.Add("你是在大聲什麼啦");
                    s.Add("更年期到了");
                    s.Add("米蟲");
                    s.Add("賤貨");
                    s.Add("王八蛋");
                    s.Add("吃屎");
                    s.Add("智障");
                    s.Add("幹你娘");
                    s.Add("北爛");
                    int i = new Random().Next(0, 12);
                    await context.PostAsync("http://imgur.com/a/84qTh");
                }





                context.Wait(MessageReceivedAsync);
            }
            catch (Exception ex)
            {
                await context.PostAsync("幹你娘,指令別亂打");
            }

        }

    }
    // public delegate void ControlHandler(bool show);
    public class Contact
    {
        public static List<string> history = new List<string>();
        public static string Id;
        public static string Name;
        public static Dictionary<string, string> Bet = new Dictionary<string, string>();
        public static void SetAppSetting(string key, string value)
        {
            //Configuration config = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location);

            //if (config.AppSettings.Settings != null)
            //{
            //    config.AppSettings.Settings.Remove(key);
            //}

            //config.AppSettings.Settings.Add(key, value);
            //config.Save(ConfigurationSaveMode.Modified);

            Configuration rootWebConfig1 = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);

            if(rootWebConfig1.AppSettings.Settings!=null)
            {
                rootWebConfig1.AppSettings.Settings.Remove(key);
            }
            rootWebConfig1.AppSettings.Settings.Add(key, value);
          //  rootWebConfig1.AppSettings.Settings[key].Value = value;
            rootWebConfig1.Save();
        }

        public static string GetAppSetting(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}