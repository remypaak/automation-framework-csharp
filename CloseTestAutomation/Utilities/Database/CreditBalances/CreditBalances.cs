using System.ComponentModel.DataAnnotations.Schema;

namespace CloseTestAutomation.Utilities.Database.CreditBalances
{
    [Table("creditbalances")]
    public class CreditBalancesDB
    {
        [Column("bonus")]
        public decimal Bonus { get; set; }
    }

    public static class CreditBalancesDBQuery { 

        public static CreditBalancesDB GetCreditBalancesByCreditReference(string creditExternalReference)
        {
            string sql = $"SELECT * FROM creditbalances WHERE creditfk in (select pkey from credit where externalreference = '{creditExternalReference}')";
            return DBClient.Select<CreditBalancesDB>(sql).FirstOrDefault();
        }
    }

    


}
