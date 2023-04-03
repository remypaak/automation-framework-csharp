using BatchIntegrationServiceReference;
using CloseLoansIntegrationServiceReference;
using CloseTestAutomation.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CloseTestAutomation.Utilities.SOAP.Clients
{
    public class ClientFactory
    {
        public static CloseLoansIntegrationServiceClient CreateCloseLoansIntegrationServiceClient()
        {
            BasicHttpBinding binding = GetGeneralBinding();

            var address = new EndpointAddress(CloseConfig.GetCloseLoansIntegrationServiceEndPoint());
            var result = new CloseLoansIntegrationServiceClient(binding, address);

            result.ClientCredentials.UserName.UserName = CloseConfig.GetCloseBOSOAPUserName();
            result.ClientCredentials.UserName.Password = CloseConfig.GetCloseBOSOAPPassword();

            return result;
        }

        public static BatchServiceClient CreateBatchServiceClient()
        {
            BasicHttpBinding binding = GetGeneralBinding();

            var address = new EndpointAddress(CloseConfig.GetBatchIntegrationServiceEndPoint());
            var result = new BatchServiceClient(binding, address);

            result.ClientCredentials.UserName.UserName = CloseConfig.GetCloseBOSOAPUserName();
            result.ClientCredentials.UserName.Password = CloseConfig.GetCloseBOSOAPPassword();

            return result;
        }

        public static BasicHttpBinding GetGeneralBinding()
        {
            var clientCredentialType = HttpClientCredentialType.None;
            BasicHttpBinding binding = new BasicHttpBinding
            {
                CloseTimeout = new TimeSpan(0, 0, 5),
                OpenTimeout = new TimeSpan(0, 0, 10),
                Security = new BasicHttpSecurity
                {
                    Transport = new HttpTransportSecurity { ClientCredentialType = clientCredentialType },
                    Mode = BasicHttpSecurityMode.TransportWithMessageCredential
                },
                ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas
                {
                    MaxArrayLength = 2147483647,
                    MaxBytesPerRead = 2147483647,
                    MaxDepth = 2147483647,
                    MaxStringContentLength = 2147483647,
                    MaxNameTableCharCount = 2147483647
                },
                ReceiveTimeout = new TimeSpan(0, 20, 0),
                SendTimeout = new TimeSpan(0, 20, 0),
                MaxReceivedMessageSize = 2147483647,
                MaxBufferSize = 2147483647
            };
            return binding;
        }
    }
}
