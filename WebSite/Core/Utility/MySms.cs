using IPE.SmsIrClient;
using IPE.SmsIrClient.Models.Requests;

namespace WebSite.Core.Utility
{
    public class MySms
    {
        private long fromNumber = 30002101003516;
        private string userApiKey = "KKp9wFaYJYiZ8hv0a9PUxXSdWUAcxRdFaBRY0wWHZQyvzODfhS8aOTYeY2zFCVHQ";

        public async Task<bool> SendSms(string toNumber, string smsBody)
        {
            SmsIr smsIr = new SmsIr(userApiKey);
            try
            {
                var bulkSendResult = await smsIr.BulkSendAsync(fromNumber, smsBody, new string[] { toNumber });
            }
            catch 
            {
                //log
            }

            return true;
        }

        public async Task<bool> SendOneTimePassword(string toNumber, string password)
        {
            SmsIr smsIr = new SmsIr(userApiKey);
            var templateId = 988761;
            var verifyParameters = new VerifySendParameter[]
            {
                new VerifySendParameter("PASSWORD", password)
            };
            var verificationSendResult = await smsIr.VerifySendAsync(toNumber, templateId, verifyParameters);

            return true;
        }

        public async Task<bool> SendNewPassword(string toNumber, string password)
        {
            SmsIr smsIr = new SmsIr(userApiKey);
            var templateId = 738498;
            var verifyParameters = new VerifySendParameter[]
            {
                new VerifySendParameter("PASSWORD", password)
            };
            var verificationSendResult = await smsIr.VerifySendAsync(toNumber, templateId, verifyParameters);

            return true;
        }
        public async Task<bool> SendVerifyCode(string toNumber, string code)
        {
            SmsIr smsIr = new SmsIr(userApiKey);
            var templateId = 153992;
            var verifyParameters = new VerifySendParameter[]
            {
                new VerifySendParameter("CODE", code)
            };
            var verificationSendResult = await smsIr.VerifySendAsync(toNumber, templateId, verifyParameters);

            return true;
        }

    }
}