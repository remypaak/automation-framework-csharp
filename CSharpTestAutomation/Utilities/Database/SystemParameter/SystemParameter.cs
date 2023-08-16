using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseTestAutomation.Utilities.Database.SystemParameter
{
    [Table("systemparameter")]
    public class SystemParameterDB
    {
        [Column("datetimevalue")]
        public DateTime? DateTimeValue { get; set; }
    }

    public static class SystemParameterQuery
    {

        public static SystemParameterDB SelectSystemParameter(string parameter)
        {
            string sql = $"SELECT * FROM systemparameter WHERE parametername = '{parameter}'";
            return DBClient.Select<SystemParameterDB>(sql).FirstOrDefault();

        }

        public static void UpdateFinancialTreatmentDate(DateTime date)
        {
           string sql = $"UPDATE systemparameter SET datetimevalue = '{date}' Where parametername = 'FinancialTreatmentDate'";
           DBClient.Update(sql);
        }

        public static void UpdateTestSystemDate(DateTime date)
        {
            string sql = $"UPDATE systemparameter SET datetimevalue = '{date}' Where parametername = 'TestSystemDate'";
            DBClient.Update(sql);
        }
    }
}
