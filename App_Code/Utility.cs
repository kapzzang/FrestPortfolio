using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Mail;

namespace proTns
{
    public class Utility
    {
        static EventLog _appLog = new EventLog();
        /// <summary>
        /// 이벤트 로그 쓰기
        /// </summary>
        /// <param name="sLog">로그</param>
        public static void WriteEventLog(string sLog, EventLogEntryType eType)
        {
            string _source = "AzuliMS";
            // Create the source, if it does not already exist.
            if (!EventLog.SourceExists(_source))
            {
                //An event log source should not be created and immediately used.
                //There is a latency time to enable the source, it should be created
                //prior to executing the application that uses the source.
                //Execute this sample a second time to use the new source.
                EventLog.CreateEventSource(_source, "Application");
            }

            // Create an EventLog instance and assign its source.

            _appLog.Source = _source;
            _appLog.WriteEntry(sLog, eType);
        }


        #region SMS Message
        // https://aspdotnet.tistory.com/2233
        // http://protnsdev-jc.intra.protns.co.kr:8080/browse/VDIX-20

        /// <summary>
        /// SMS 발송
        /// </summary>
        /// <param name="SenderNum">SMS 송신번호</param>
        /// <param name="ReceiverNum">SMS 수신번호 only one (ex : 01012345678)</param>
        /// <param name="SMSSubject">SMS 메시지 제목</param>
        /// <param name="SMSMsg">SMS 메시지 내용</param>
        public bool SMSSend(string SenderNum, string ReceiverNum, string SMSSubject, string SMSMsg)
        {
            try
            {
                Dictionary<string, string> list = new Dictionary<string, string>();

                // SMS Send Info -> 추후 MinorCode화
                string SMSURL = "http://210.122.10.171:8080/notification";
                string sOrganizationName = "HOSTWAY-GSSHOP";
                string sAccountName = "gsshop_sbc";
                string sType = "sms";

                string sOriginator = string.IsNullOrEmpty(SenderNum) ? "1544-2233" : SenderNum;             // 1544-2233
                string sRecipient = "\"" + ReceiverNum.Trim() + "\"";                                       // "\"01073275523\",\"01087558371\"";
                string sSubject = SMSSubject;                                                               // "GS SHOP SMS TEST(프로티앤에스)";
                string sMessage = SMSMsg;                                                                   // "Hello there TEST5(프로티앤에스)" + "프로티앤에스" + DateTime.Now.ToString() + "Hello!!!";
                
                string JSONData = "{";
                JSONData += "\"Originator\":\"" + HttpUtility.JavaScriptStringEncode(sOriginator) + "\"";
                JSONData += ",\"OrganizationName\":\"" + HttpUtility.JavaScriptStringEncode(sOrganizationName) + "\"";
                //JSONData += ",\"Recipient\":[\"" + HttpUtility.JavaScriptStringEncode(sRecipient) + "\"]";                          // []로 묶여야 한다. [\"01073275523\"]
                JSONData += ",\"Recipient\":[" + sRecipient + "]";                                                              // []로 묶여야 한다. [\"01073275523\"]
                JSONData += ",\"Message\":\"" + HttpUtility.JavaScriptStringEncode(sMessage) + "\"";
                JSONData += ",\"AccountName\":\"" + HttpUtility.JavaScriptStringEncode(sAccountName) + "\"";
                JSONData += ",\"Type\":\"" + HttpUtility.JavaScriptStringEncode(sType) + "\"";
                JSONData += ",\"Subject\":\"" + HttpUtility.JavaScriptStringEncode(sSubject) + "\"";
                JSONData += "}";

                return SendPostMsg(SMSURL, JSONData);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SendPostMsg(string SendURL, string jsonStr)
        {
            // 출처: https://blog.gangslab.com/entry/C-HttpWebRequest-클래스를-이용한-POST-전송하기 [Gangslab]
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(SendURL);
            byte[] sendData = Encoding.GetEncoding("UTF-8").GetBytes(jsonStr);
            httpWebRequest.ContentType = "application/json; charset=UTF-8";

            httpWebRequest.Method = "POST";
            // Set the content length of the string being posted.
            httpWebRequest.ContentLength = sendData.Length;
            Stream requestStream = httpWebRequest.GetRequestStream();
            requestStream.Write(sendData, 0, sendData.Length);
            requestStream.Close();

            string result = "";
            try
            {
                using (var response = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    if (httpWebRequest.HaveResponse && response != null)
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
                return true;
            }
            catch (WebException e)
            {
                if (e.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)e.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            string error = reader.ReadToEnd();
                            result = error;
                        }
                    }
                }
                return false;
            }
        }

        #endregion

    }

    #region Mail Message
    /// <summary>
    /// 메일 전송 클래스
    /// </summary>
    public class SMTP_Protns
    {
        string SMTPServerIP;
        string SenderMailAddress;

        /// <summary>
        /// 기본 생성자
        /// </summary>
        /// <param name="smtpIP">SMTP 서버 IP</param>
        /// <param name="SenderMailAddress">보내는 사람 메일주소</param>
        public SMTP_Protns(string smtpIP, string SenderMailAddress)
        {
            this.SMTPServerIP = smtpIP;
            this.SenderMailAddress = SenderMailAddress;
        }

        /// <summary>
        /// 메일 보내기
        /// </summary>
        /// <param name="ReceiverMailAddress">메일 수신자</param>
        /// <param name="Subject">메일 제목</param>
        /// <param name="MailContent">메일 본문</param>
        /// <remarks>
        /// 메일 본문은 HTML 로 지정됨
        /// </remarks>
        public void Send(string ReceiverMailAddress, string Subject, string MailContent)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            //System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(new MailAddress(SenderMailAddress), new MailAddress(ReceiverMailAddress));

            msg.IsBodyHtml = true;
            //msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.Sender = new MailAddress(SenderMailAddress);
            msg.From = new MailAddress(SenderMailAddress);
            //MailAddressCollection recs = new MailAddressCollection();
            //recs.Add(new MailAddress(ReceiverMailAddress));
            // 멀티 메일 추가
            string[] arrTO = ReceiverMailAddress.Split(';');
            if (arrTO.Length > 1)
            {
                foreach (string addr in arrTO)
                {
                    if (addr.Length > 0)
                        msg.To.Add(new MailAddress(addr));
                }


            }
            else
            {
                ReceiverMailAddress = ReceiverMailAddress.Replace(";", "");
                msg.To.Add(ReceiverMailAddress);
            }
            msg.Subject = Subject;
            msg.Body = MailContent;

            System.Net.Mail.SmtpClient sc = new SmtpClient(SMTPServerIP);
            //sc.Credentials = new System.Net.NetworkCredential("corp\\200300258", "rlrk@222");
            sc.UseDefaultCredentials = true;
            sc.Send(msg);
        }
    }
    #endregion
}