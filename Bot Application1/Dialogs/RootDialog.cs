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

namespace Bot_Application1.Dialogs {
    [Serializable]
    public class RootDialog : IDialog<object> {

       
        
        public RootDialog() {
          
        }

        public Task StartAsync(IDialogContext context) {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result) {

            try {
              //  CountDown.timer.Stop();
                var activity = await result as Activity;
                int n;

                if (activity.Text.Contains("123")) {
                    DateTime dayOff = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 18, 0, 0);
                    TimeSpan dd = dayOff.Subtract(DateTime.UtcNow.AddHours(8));
                    CountDown.timer.Interval = 5000;
                    CountDown.timer.Elapsed += Timer_Elapsed;
                    CountDown.context = context;
                  //  CountDown.timer.Start();
                    await context.PostAsync(CountDown.no.ToString());
                    await context.PostAsync("倒數" + Math.Floor(dd.TotalMinutes) + "分鐘" + dd.Seconds + "秒");
                } else if (activity.Text.Contains("勞保級距")) {
                    HttpClient client = new HttpClient();
                    string x = "http://apiservice.mol.gov.tw/OdService/download/A17000000J-020014-gGq";
                    HttpResponseMessage m = client.GetAsync(x).Result;
                    string s = m.Content.ReadAsStringAsync().Result.ToString();

                    molgovtw value = molgovtw.Deserialize(s);

                    //  Console.WriteLine($"{value.FIELDS.colum_1,-15} {value.FIELDS.colum_2.PadRight(15)} {value.FIELDS.colum_3.PadRight(15)} {value.FIELDS.colum_4.PadRight(15)}");
                    await context.PostAsync($"{value.FIELDS.colum_1,-15} {value.FIELDS.colum_2.PadRight(15)} {value.FIELDS.colum_3.PadRight(15)} {value.FIELDS.colum_4.PadRight(15)}");
                    foreach (molgovtwDATA data in value.DATA) {
                        // Console.WriteLine($"{names[i],-8} {ages[i]}");
                        //Console.WriteLine($"{data.colum_1.PadRight(15)} {data.colum_2.PadRight(15)}  {data.colum_3.PadRight(20)}  {data.colum_4.PadRight(15)}");
                        if (data.colum_1.Equals("一般勞工") && data.colum_1 != "") {
                            await context.PostAsync($"{data.colum_1.PadRight(15)} {data.colum_2.PadRight(15)}  {data.colum_3.PadRight(20)}  {data.colum_4.PadRight(15)}");
                        }
                    }
                } else if (activity.Text.Contains("勞健保分攤表")) {
                    HttpClient client = new HttpClient();
                    string x = "http://apiservice.mol.gov.tw/OdService/download/A17000000J-020015-ipY";
                    HttpResponseMessage m = client.GetAsync(x).Result;
                    string s = m.Content.ReadAsStringAsync().Result.ToString();

                    molgovtw2 value = molgovtw2.Deserialize(s);

                    // Console.WriteLine(value.FIELDS.colum_1 + " " + value.FIELDS.colum_2 + " " + value.FIELDS.colum_3 + " " + value.FIELDS.colum_4 + " " + value.FIELDS.colum_5 + " " + value.FIELDS.colum_6);
                    await context.PostAsync($"{value.FIELDS.colum_1,-8}{value.FIELDS.colum_2.PadLeft(8)} {value.FIELDS.colum_3.PadLeft(8)}{value.FIELDS.colum_4.PadLeft(10)}{ value.FIELDS.colum_5.PadLeft(10) } {value.FIELDS.colum_6.PadLeft(10)}");
                    foreach (ConsoleApp22.molgovtwDATA data in value.DATA) {
                        // Console.WriteLine($"{names[i],-8} {ages[i]}");

                        // Console.WriteLine(data.colum_1 + "       " + data.colum_2 + "       " + data.colum_3 + "     " + data.colum_4 + "        " + data.colum_5 + "           " + data.colum_6);
                        await context.PostAsync($"{data.colum_1.ToString(),-8 }{data.colum_2.ToString().PadLeft(10)}{data.colum_3.PadLeft(12)}{data.colum_4.ToString().PadLeft(16)}{data.colum_5.ToString().PadLeft(15)}{data.colum_6.ToString().PadLeft(15)}");

                    }
                } else if (activity.Text.Equals("@peterbot 天氣")) {
                    HttpClient client = new HttpClient();

                    string x2 = "http://opendata.cwb.gov.tw/opendata/MFC/F-C0044-001.FW01";

                    HttpResponseMessage mR = client.GetAsync(x2).Result;
                    string s2 = System.Text.Encoding.GetEncoding("Big5").GetString(mR.Content.ReadAsByteArrayAsync().Result); ;
                    await context.PostAsync(s2);






                    string x = "http://opendata.cwb.gov.tw/govdownload?dataid=F-C0032-005&authorizationkey=rdec-key-123-45678-011121314";
                    HttpResponseMessage m = client.GetAsync(x).Result;
                    string s = m.Content.ReadAsStringAsync().Result.ToString();

                    cwbopendata value = cwbopendata.Deserialize(s);
                    int i = 0;

                    foreach (cwbopendataDatasetLocation d in value.dataset.location) {
                        // Console.WriteLine(d.locationName);
                        if (d.locationName.Equals("台北市") || d.locationName.Equals("臺北市") || d.locationName.Equals("新竹市") || d.locationName.Equals("桃園市")) {
                            await context.PostAsync(d.locationName);
                            foreach (cwbopendataDatasetLocationWeatherElement e in d.weatherElement) {

                                switch (e.elementName) {
                                    case "Wx":
                                        await context.PostAsync("天氣概況");
                                        break;
                                    case "MaxT":
                                        await context.PostAsync("最高溫度");
                                        break;
                                    case "MinT":
                                        await context.PostAsync("最低溫度");
                                        break;
                                }
                                foreach (cwbopendataDatasetLocationWeatherElementTime time in e.time) {
                                    //await context.PostAsync(time.startTime.ToShortDateString() + " " + time.parameter.parameterName + " " + time.parameter.parameterValue + "°C");
                                    string ss = "";
                                    if (time.parameter.parameterUnit != null) {
                                        if (time.parameter.parameterUnit.Equals("C")) {
                                            ss = "°C";
                                        }
                                    }
                                    if (time.startTime.ToShortDateString() == DateTime.UtcNow.AddHours(8).ToShortDateString()) {
                                        await context.PostAsync(time.startTime + "~" + time.endTime + " " + time.parameter.parameterName + "" + ss);
                                        //  Console.WriteLine(time.parameter.parameterName + " " + time.parameter.parameterValue);
                                    }
                                }
                                await context.PostAsync("-----------------------------------");
                            }
                        }

                    }
                } else if (activity.Text.Contains("華華貓")) {
                    await context.PostAsync("廷廷貓");
                } else if (activity.Text.Contains("冷清")) {
                    await context.PostAsync("慘");
                } else if (activity.Text.Contains("UML")){
                    await context.PostAsync("統一塑模語言（英語：Unified Modeling Language，縮寫UML）是非專利的第三代塑模和規約語言。 UML是一種開放的方法，用於說明、可視化、構建和編寫一個正在開發的、物件導向的、軟體密集系統的製品的開放方法。");
                } else if (activity.Text.Contains("小雨")) {
                    await context.PostAsync("志峰:人生污點");
                } else if (activity.Text.Contains("辭") || activity.Text.Contains("慈")) {
                    await context.PostAsync("志峰:這次認真沒有4000一定走");
                } else if (activity.Text.Contains("很濕")) {
                    await context.PostAsync("西歐:很濕真的很舒服");
                    await context.PostAsync("西歐:一下子就進去");
                    await context.PostAsync("西歐:各種包覆");
                } else if (activity.Text.Contains("麵")) {
                    await context.PostAsync("資訊部 祥凱#624:不吃麵");
                } else if (activity.Text.Contains("學弟")) {
                    await context.PostAsync("晚點到");

                } else if (activity.Text.Contains("yo")) {
                    await context.PostAsync("買steam囉");

                } else if (activity.Text.Contains("開盤倒數")) {
                    DateTime time = new DateTime(2017, 08, 04, 9, 40, 0);
                    DateTime now = DateTime.UtcNow.AddHours(8);
                    TimeSpan t = time.Subtract(now);
                    await context.PostAsync(t.ToString());

                } else if (activity.Text.Contains("峰哥獎金")) {
                    await context.PostAsync("2017年7月 1萬2");

                } else if (activity.Text.Contains("小雞")) {
                    await context.PostAsync("資訊部 祥凱#624:安安");

                } else if (activity.Text.Contains("鬍鬚張")) {
                    await context.PostAsync("志峰:幹你娘鬍鬚張");

                } else if (activity.Text.Contains("峰哥組長")) {
                    await context.PostAsync("我領導加給只有2000");

                } else if (activity.Text.Contains("董事長兒子")) {
                    await context.PostAsync("riolove chang");
                } else if (activity.Text.Contains("文B")) {
                    await context.PostAsync("打醬油");
                } else if (activity.Text.Contains("起床")) {
                    await context.PostAsync("現在時間么三三洞，部隊起床");
                } else if (activity.Text.Contains("賭盤")) {
                    await context.PostAsync("志峰:0~499  1.7 \n 500~1999 1.3 \n 2000~3999 1.5 \n 4000 up 1.9");
                } else if (activity.Text.Contains("風歌") || activity.Text.Contains("志峰") || activity.Text.Contains("峰")) {
                    await context.PostAsync("上頭看得到");
                } else if (int.TryParse(activity.Text.Remove(0, 10), out n)) {
                    if (activity.Text.Remove(0, 10).Count() == 4) {
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
                        foreach (HtmlNode nodeHeader in nodeHeaders) {
                            //Console.WriteLine("Header: {0}, Value: {1}",nodeHeader.InnerText, values[i].Trim());
                            await context.PostAsync(nodeHeader.InnerText + " " + values[i].Trim());
                            i++;
                        }
                        doc = null;
                        docStockContext = null;
                        client = null;
                        ms.Close();
                    }
                } else {
                    // calculate something for us to return
                    int length = (activity.Text ?? string.Empty).Length;
                    // return our reply to the user
                    await context.PostAsync($"You sent {activity.Text} which was {length} characters");
                    int i = new Random().Next(0, 5);
                    int i2 = new Random().Next(0, 5);
                    List<string> s = new List<string>();
                    s.Add("你就當練功");
                    s.Add("你要想未來的分紅");
                    s.Add("你就當測試");
                    s.Add("你就當學經驗");
                    s.Add("你要想未來的分紅");
                    s.Add("你就當學經驗");

                    List<string> s2 = new List<string>();
                    s2.Add("幫我看程式碼吧！");
                    s2.Add("幫我做這個案子吧！");
                    s2.Add("幫我修這個Bug吧！");
                    s2.Add("幫我偷這些資料吧！");
                    s2.Add("幫我解這個問題吧！");
                    s2.Add("幫我墊這個小錢吧！");
                    await context.PostAsync(s[i] + s2[i2]);
                }





                context.Wait(MessageReceivedAsync);
            } catch (Exception ex) {
                await context.PostAsync(ex.Message);
            }

        }

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e) {
           await  CountDown.context.PostAsync("沒人");
        }
    }
}