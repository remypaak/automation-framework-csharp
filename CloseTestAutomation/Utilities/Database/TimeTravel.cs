using CloseTestAutomation.Utilities.Database.SystemParameter;
using CloseTestAutomation.Utilities.Database.CreditDossier;

namespace CloseTestAutomation.Utilities.Database
{
    public class TimeTravel
    {
        public static void TimeTravelToDate(DateTime date, string? dossierReference)
        {
            CreditDossierQuery.UpdateCreditDossiersInBatchError(dossierReference);
            SystemParameterQuery.UpdateFinancialTreatmentDate(date);
            SystemParameterQuery.UpdateTestSystemDate(date);
        }
    }
}
