using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pers.Domain;

namespace Pers.DAL
{
    public class SiteContentManagementRepository : ISiteContentManagementRepository
    {
        private string _connectionString;

        public SiteContentManagementRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<ISiteContent> GetSiteContent()
        {
            string cmdText = "SELECT * FROM [SiteContent]";
            return ExecuteReader(cmdText,CommandType.Text);
        }

        public void EditSiteContent(int textId, string homepageWelcome, string homepageWhatsNew, string homepageWhatsUpLately)
        {
            string cmdText = "UPDATE [SiteContent] SET [Homepage_Welcome] = @Homepage_Welcome, "+
                "[Homepage_WhatsNew] = @Homepage_WhatsNew, [Homepage_WhatsUpLately] = @Homepage_WhatsUpLately "+
                "WHERE [TextId] = @TextId";

            ExecuteNonQuery(cmdText, CommandType.Text, 
                new SqlParameter("@Homepage_Welcome",homepageWelcome),
                new SqlParameter("@Homepage_WhatsNew",homepageWhatsNew),
                new SqlParameter("@Homepage_WhatsUpLately",homepageWhatsUpLately),
                new SqlParameter("@TextId", textId));
        }

        private IList<ISiteContent> ExecuteReader(string cmdText, CommandType commandType)
        {
            return Pers.Utilities.SqlDBUtils.ExecuteReader<ISiteContent>(_connectionString, cmdText, commandType, (r) => CreateSiteContent(r));
        }

        private int ExecuteNonQuery(string cmdText, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            return Pers.Utilities.SqlDBUtils.ExecuteNonQuery(_connectionString, cmdText, commandType, sqlParameters);
        }

        private ISiteContent CreateSiteContent(SqlDataReader reader)
        {
            return new SiteContent((int)reader["TextId"],
                (string)reader["Homepage_Welcome"], (string)reader["Homepage_WhatsNew"], (string)reader["Homepage_WhatsUpLately"]);
        }
    }
}
