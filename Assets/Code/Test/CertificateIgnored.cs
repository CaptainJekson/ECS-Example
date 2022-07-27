using UnityEngine;
using UnityEngine.Networking;

namespace Code.Test
{
    public class CertificateIgnored : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)   
        {                 
            return true;                                                      
        }                                                                     
    }
}

