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
using Bot_Application1.Model;

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
                SkypeDAO dao = new SkypeDAO();
                dao.Open();
                string[] separators = { ",", "!", ";", " " };
                var activity = await result as Activity;
                int n;

                List<Quotation> log5 = dao.GetQuotations(activity.Text.Remove(0,10));
                StringBuilder sb5 = new StringBuilder();
                if (log5.Count > 0) {
                    foreach (var item in log5) {
                        sb5.Append(item.Value + " \n\n");
                    }
                    await context.PostAsync(sb5.ToString());
                }


                if (activity.Text.Contains("對話紀錄")) {
                    //Contact.history.Add(Contact.Name + " : " + activity.Text.Remove(0, 9));
                    List<MessageLog> log = dao.GetMessageLog();
                    StringBuilder sb = new StringBuilder();
                    if (log.Count > 0) {
                        foreach (var item in log) {
                            sb.Append(item.Name + " " + item.Log + " " + item.Time.ToString("yyyy-MM-dd HH:mmss") + " \n\n");
                        }
                    }
                    await context.PostAsync(sb.ToString());
                }

                if (activity.Text.ToUpper().Contains("新增")) {
                    string[] sql = activity.Text.Split(';');

                    dao.InsertQuotations(sql[1], sql[2]);
                    StringBuilder sb = new StringBuilder();
                    await context.PostAsync("Execute success");


                }


                if (activity.Text.Contains("123")) {
                    DateTime dayOff = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 18, 0, 0);
                    TimeSpan dd = dayOff.Subtract(DateTime.UtcNow.AddHours(8));

                    if (Contact.Id.Equals("29:1-lHdGRIXVjWxaHlz25WYEmaIM963VpEyI_1gXQ_uz2U")) {
                        await context.PostAsync("倒數" + Math.Floor(dd.TotalMinutes) + "分鐘" + dd.Seconds + "秒,但是有潛規則,下班時間未知");
                    } else {
                        await context.PostAsync("倒數" + Math.Floor(dd.TotalMinutes) + "分鐘" + dd.Seconds + "秒");
                    }
                }

                if (activity.Text.Contains("456")) {
                    DateTime breakOff = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 12, 0, 0);
                    TimeSpan dd = breakOff.Subtract(DateTime.UtcNow.AddHours(8));
                    DateTime breakOff2 = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 12, 30, 0);
                    TimeSpan dd2 = breakOff2.Subtract(DateTime.UtcNow.AddHours(8));
                    //  CountDown.timer.Start();

                    if (Contact.Id.Equals("29:1zzRM1BUX5XWVA7Ral9vpEeTa-DCYhRGE4aCyOzYgpHo")) {
                        await context.PostAsync("倒數" + Math.Floor(dd2.TotalMinutes) + "分鐘" + dd2.Seconds + "秒 吃飯");
                    } else {
                        await context.PostAsync("倒數" + Math.Floor(dd.TotalMinutes) + "分鐘" + dd.Seconds + "秒 吃飯");
                    }


                } else if (activity.Text.Equals("@peterbot 天氣")) {
                    HttpClient client = new HttpClient();
                    string x2 = "http://opendata.cwb.gov.tw/opendata/MFC/F-C0044-001.FW01";
                    HttpResponseMessage mR = client.GetAsync(x2).Result;
                    string s2 = System.Text.Encoding.GetEncoding("Big5").GetString(mR.Content.ReadAsByteArrayAsync().Result); ;
                    await context.PostAsync(s2);
                }

                if (activity.Text.Contains("冷清")) {
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
                }
                dao.InsertMessageLog(Contact.Name, activity.Text, DateTime.UtcNow.AddHours(8).ToString("yyyy-MM-dd HH:mm:ss"));
                context.Wait(MessageReceivedAsync);
            } catch (Exception ex) {
             //   await context.PostAsync("https://imgur.com/a/dfzNA");
             //   await context.PostAsync(ex.Message);
            }

        }

    }
    // public delegate void ControlHandler(bool show);
    public class Contact {
        public static List<string> history = new List<string>();
        public static string Id;
        public static string Name;
        public static Dictionary<string, string> Bet = new Dictionary<string, string>();
        public static void SetAppSetting(string key, string value) {
            //Configuration config = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location);

            //if (config.AppSettings.Settings != null)
            //{
            //    config.AppSettings.Settings.Remove(key);
            //}

            //config.AppSettings.Settings.Add(key, value);
            //config.Save(ConfigurationSaveMode.Modified);

            Configuration rootWebConfig1 = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);

            if (rootWebConfig1.AppSettings.Settings != null) {
                rootWebConfig1.AppSettings.Settings.Remove(key);
            }
            rootWebConfig1.AppSettings.Settings.Add(key, value);
            //  rootWebConfig1.AppSettings.Settings[key].Value = value;
            rootWebConfig1.Save();
        }

        public static string GetAppSetting(string key) {
            try {
                return ConfigurationManager.AppSettings[key];
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}