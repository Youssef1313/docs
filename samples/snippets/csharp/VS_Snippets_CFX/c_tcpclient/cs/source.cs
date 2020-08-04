﻿//<snippet0>
using System;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Security.Permissions;
//</snippet0>
[assembly: SecurityPermission(
   SecurityAction.RequestMinimum, Execution = true)]
namespace Microsoft.Security.Samples
{
    internal class Service
    {
        static void Main(string[] args)
        {
            try
            {
                Service s = new Service();
                s.NetTcpSecurityWindows();
                Console.ReadLine();
            }
            catch (System.InvalidOperationException exc)
            {
                Console.WriteLine("Message: {0}", exc.Message);
            }
            catch (System.ServiceModel.AddressAlreadyInUseException exc)
            {
                Console.WriteLine("Message: {0}", exc.Message);
            }
            catch (System.ServiceModel.ProtocolException exc)
            {
                Console.WriteLine("Message: {0}", exc.Message);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.WriteLine(exc.InnerException.Message);
                Console.ReadLine();
            }
        }

        private void NetTcpSecurityWindows()
        {
            //<snippet1>
            // Create a NetTcpBinding and set its security properties. The
            // security mode is Message, and the client must be authenticated with
            // Windows. Therefore the client must be on the same Windows domain.
            NetTcpBinding b = new NetTcpBinding();
            b.Security.Mode = SecurityMode.Message;
            b.Security.Message.ClientCredentialType = MessageCredentialType.Windows;

            // Set a Type variable for use when constructing the endpoint.
            Type c = typeof(ICalculator);

            // Create a base address for the service.
            Uri tcpBaseAddress =
                new Uri("net.tcp://machineName.Domain.Contoso.com:8036/serviceName");
            // The base address is in an array of URI objects.
            Uri[] baseAddresses = new Uri[] { tcpBaseAddress };
            // Create the ServiceHost with type and base addresses.
            ServiceHost sh = new ServiceHost(typeof(CalculatorClient), baseAddresses);

            // Add an endpoint to the service using the service type and binding.
            sh.AddServiceEndpoint(c, b, "");
            sh.Open();
            string address = sh.Description.Endpoints[0].ListenUri.AbsoluteUri;
            Console.WriteLine("Listening @ {0}", address);
            Console.WriteLine("Press enter to close the service");
            Console.ReadLine();
            //</snippet1>
        }

        private void SecureHttp()
        {
            //<snippet2>
            // Create a WSHttpBinding and set its security properties. The
            // security mode is Message, and the client is authenticated with
            // a certificate.
            EndpointAddress ea = new EndpointAddress("http://contoso.com/");
            WSHttpBinding b = new WSHttpBinding();
            b.Security.Mode = SecurityMode.Message;
            b.Security.Message.ClientCredentialType =
                MessageCredentialType.Certificate;

            // Create the client with the binding and EndpointAddress.
            CalculatorClient cc = new CalculatorClient(b, ea);

            // Set the client credential value to a valid certificate.
            cc.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.CurrentUser,
                StoreName.TrustedPeople,
                X509FindType.FindBySubjectName,
                "client.com");
            //</snippet2>
        }
        private void SetCertificate_SubjectName()
        {
            //<snippet3>
            // Create a WSHttpBinding and set its security properties. The
            // security mode is Message, and the client is authenticated with
            // a certificate.
            EndpointAddress ea = new EndpointAddress("http://contoso.com/");
            WSHttpBinding b = new WSHttpBinding();
            b.Security.Mode = SecurityMode.Message;
            b.Security.Message.ClientCredentialType =
                MessageCredentialType.Certificate;

            // Create the client with the binding and EndpointAddress.
            CalculatorClient cc = new CalculatorClient(b, ea);

            // Set the client credential value to a valid certificate.
            cc.ClientCredentials.ClientCertificate.SetCertificate(
                "CN=MyName, OU=MyOrgUnit, C=US",
                StoreLocation.CurrentUser,
                StoreName.TrustedPeople);
            //</snippet3>
        }
    }

    //------------------------------------------------------------------------------
    // <auto-generated>
    //     This code was generated by a tool.
    //     Runtime Version:2.0.50727.42
    //
    //     Changes to this file may cause incorrect behavior and will be lost if
    //     the code is regenerated.
    // </auto-generated>
    //------------------------------------------------------------------------------

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://Microsoft.ServiceModel.Samples", ConfigurationName = "ICalculator")]
    public interface ICalculator
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://Microsoft.ServiceModel.Samples/ICalculator/Add", ReplyAction = "http://Microsoft.ServiceModel.Samples/ICalculator/AddResponse")]
        double Add(double n1, double n2);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ICalculatorChannel : ICalculator, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public class CalculatorClient : System.ServiceModel.ClientBase<ICalculator>, ICalculator
    {

        public CalculatorClient()
        {
        }

        public CalculatorClient(string endpointConfigurationName)
            :
                base(endpointConfigurationName)
        {
        }

        public CalculatorClient(string endpointConfigurationName, string remoteAddress)
            :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public CalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
            :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public CalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
            :
                base(binding, remoteAddress)
        {
        }

        public double Add(double n1, double n2)
        {
            return base.Channel.Add(n1, n2);
        }
    }
}
