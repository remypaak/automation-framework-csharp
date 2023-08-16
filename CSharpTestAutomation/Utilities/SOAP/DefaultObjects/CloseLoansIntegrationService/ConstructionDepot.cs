using CloseLoansIntegrationServiceReference;
using CloseTestAutomation.Utilities.Database.SystemParameter;
using CloseTestAutomation.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseTestAutomation.Utilities.SOAP.DefaultObjects.CloseLoansIntegrationService
{
    public static class DefaultConstructionDepot
    {
        public static ConstructionDepot CreateDefaultConstructionDepot()
        {
            return new ConstructionDepot
            {
                ConstructionDepotType = ConstructionDepotTypeEnum.NewConstructionDepot,
                DepotStatus = DepotStatusEnum.Active,
                EndDate = SystemParameterQuery.SelectSystemParameter("FinancialTreatmentDate").DateTimeValue.Value.AddMonths(6),
                ExternalRef = Randomizer.GetRandomNumberString(10),
                FixedCalcDay = 1,
                InitialAmount = 5000M,
                InterestEndDate = SystemParameterQuery.SelectSystemParameter("FinancialTreatmentDate").DateTimeValue.Value.AddMonths(6),
                InterestPercentage = 1.00M,
                IsBlocked = false,
                StartDate = SystemParameterQuery.SelectSystemParameter("FinancialTreatmentDate").DateTimeValue.Value,
                UseOutstandingForPrepaymentAllowed = true,

            };
        }
    }
}
