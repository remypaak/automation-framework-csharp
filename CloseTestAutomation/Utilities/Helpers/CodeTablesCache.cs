using CloseLoansIntegrationServiceReference;


namespace CloseTestAutomation.Utilities.Helpers
{
    public class CodeTable
    {
        public Dictionary<string, GCTGetCodetableTranslations[]> TableTranslations { get; set; }
    }

    public static class CachedCodeTables
    {
        private static List<CodeTable> _codeTables;

        static CachedCodeTables()
        {
            _codeTables = new List<CodeTable>();
        }

        public static string GetTranslation(string tableName, string enumCaption)
        {

            if (!_codeTables.Any(ct => ct.TableTranslations.ContainsKey(tableName)))
            {
                GCTGetCodetableTranslationsRequest translationsRequest = new GCTGetCodetableTranslationsRequest() { Codetable = tableName, Language = LanguageEnum.English };
                var translations = CloseLoansIntegrationClient.ExecuteOperation(translationsRequest, (client, request) => client.GetCodetableTranslations(request));

                var codeTable = new CodeTable
                {
                    TableTranslations = new Dictionary<string, GCTGetCodetableTranslations[]>
                {
                    { tableName, translations.Translations }
                }
                };

                _codeTables.Add(codeTable);
            }
            var targetCodeTable = _codeTables.FirstOrDefault(ct => ct.TableTranslations.ContainsKey(tableName));
            var targetTranslation = targetCodeTable.TableTranslations[tableName].FirstOrDefault(t => t.Enum == enumCaption);
            return targetTranslation.Translation;
        }
    }
}

