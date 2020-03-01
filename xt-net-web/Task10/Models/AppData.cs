using System.Web.Configuration;
using Task06.BLL;
using Task06.BLL.Interfaces;
using Task06.DAL;
using Task11.DAL;

namespace Task10.Models
{
    public static class AppData
    {
        static AppData()
        {
            string dal = WebConfigurationManager.AppSettings["dal"];
            switch (dal)
            {
            case "sql":
                SqlDaoCommon.ConnectionString = WebConfigurationManager.
                ConnectionStrings["sqlDatabase"].ConnectionString;

                UserLogic = new UserLogic(new SqlUserDao(),
                    new SqlUserAwardTableDao());
                AwardLogic = new AwardLogic(new SqlAwardDao());
                break;

            case "file":
                UserLogic = new UserLogic(new UserDao(),
                    new UserAwardTableDao());
                AwardLogic = new AwardLogic(new AwardDao());
                break;

            default:
                throw new System.ArgumentException();
            }
        }

        public static IUserLogic UserLogic
        {
            get;
        }

        public static IAwardLogic AwardLogic
        {
            get;
        }
    }
}