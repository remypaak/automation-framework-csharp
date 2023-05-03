using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseTestAutomation.Utilities.Database.CreditDossier
{
    [Table("systemparameter")]
    public class CreditDossierDB
    {
        [Column("datetimevalue")]
        public bool? HasBatchError { get; set; }
    }

    public static class CreditDossierQuery
    {

        public static CreditDossierDB SelectCreditDossierByReference(string dossierReference)
        {
            string sql = $"SELECT * FROM creditdossier WHERE externalreference = '{dossierReference}'";
            return DBClient.Select<CreditDossierDB>(sql).FirstOrDefault();

        }

        public static void UpdateCreditDossiersInBatchError(string? dossierReference)
        {
            string sql = $"UPDATE creditdossier SET hasbatcherror = true WHERE externalreference not in ('{dossierReference}')";
            DBClient.Update(sql);
        }
    }
}
