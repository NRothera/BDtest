using BDApiTest.Interfaces;
using Ninject;
using TechTalk.SpecFlow;
using RestSharp;
using BDApiTest.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using BDApiTest.Helpers;

namespace BDApiTest.BaseTest
{
    [Binding]
    public class BaseTestCommon
    {
        protected BaseTestCommon()
        {

        }

        #region Fields    

        protected static IKernel Kernel;
        public static ClientHelper clientHelper;
        #endregion

        #region Restsharp Properties

        public static IRestRequest Request { get; set; }
        public static IRestResponse Response { get; set; }
        public static RestClient Client { get; set; }

        #endregion

        #region Model Properties

        public static Posts PostContent { get; set; }
        public static Comments[] CommentsList { get; set; }

        #endregion

        #region Properties

        public static int Id { get; set; }
        public static string Url { get; set; }
        public static long ResponseTime { get; set; }
        

        #endregion

        public static ITestConfiguration testConfiguration;

        //[TestInitialize]
        public static void TestSetupInit()
        {
            Kernel = new StandardKernel(new BDApiTestModule());
            var config = Kernel.Get<ITestConfiguration>();
            testConfiguration = config;

            //helpers 
            clientHelper = Kernel.Get<ClientHelper>();
        }

        //[TestCleanup]
        public static void TearDown()
        {
            Kernel?.Dispose();
        }
       
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                System.Console.WriteLine($"{email}: email is in incorrect format");
                return false;
            }
        }

        public string GetResponseHeader(string header)
        {
            var headerValue = Response.Headers
                .Where(x => x.Name == header)
                .Select(x => x.Value)
                .FirstOrDefault().ToString();

            return headerValue;
        }
    }
}
