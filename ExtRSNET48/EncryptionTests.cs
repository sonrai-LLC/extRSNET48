using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sonrai.ExtRSNET48.UnitTests
{
    [TestClass]
    public class EncryptionTests
    {
        [TestMethod]
        public void EncryptUrlSucceeds()
        {
            Assert.IsTrue(Services.EncryptionService.Encrypt("some clear text", "secr3tk3y") == "nNVA3kA4w+Imz4fyhK7/qsF7IUSLMZ/bsa42vAPkFPk=");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void EncryptUrlFails()
        {
            Services.EncryptionService.Encrypt(null, null);
        }

        [TestMethod]
        public void DecryptUrlSucceeds()
        {
            Assert.IsTrue(Services.EncryptionService.Decrypt("nNVA3kA4w+Imz4fyhK7/qsF7IUSLMZ/bsa42vAPkFPk=", "secr3tk3y") == "some clear text");
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void DecryptUrlFails()
        {
            Services.EncryptionService.Decrypt(null, null);
        }
    }
}
