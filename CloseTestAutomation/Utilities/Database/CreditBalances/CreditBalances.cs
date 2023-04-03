using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseTestAutomation.Utilities.Database.CreditBalances
{
    public class CreditBalancesDB
    {
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
