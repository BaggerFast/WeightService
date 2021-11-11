﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// https://github.com/DanyloKD/EasySerial/blob/f09b2b5a3cf4d9c4ef951fa802f8b1a97443f39a/tests/EasySerial.Tests/Crc16MassaEntityTests.cs
// https://www.tahapaksu.com/crc/
// https://github.com/nullfx/NullFX.CRC

using NUnit.Framework;
using WeightCore.MassaK;

namespace HardwareTests.MassaK
{
    [TestFixture]
    internal class Crc16MassaEntityTests
    {
        private readonly BytesHelper _bytes = BytesHelper.Instance;
        private readonly MassaRequestHelper _massaRequest = MassaRequestHelper.Instance;
        // READ     F8 55 CE 0D 00 24 00 00 00 00 01 01 00 01 00 00 00 00 FC 23  -- 0.000 кг
        private readonly byte[] getMassaResponse = new byte[] { 0x24, 0x00, 0x00, 0x00, 0x00, 0x01, 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 };

        [Test]
        public void ComputeChecksum_AreEqual()
        {
            Utils.MethodStart();

            Assert.DoesNotThrow(() =>
            {
                byte[] request = new byte[] { 0xF8, 0x55, 0xCE, 0x01, 0x00, 0x23, 0x00, 0x00 };
                byte[] requestCheck = _massaRequest.MakeRequestCrcRecalc(request);
                Assert.AreEqual(requestCheck, new byte[] { 0xF8, 0x55, 0xCE, 0x01, 0x00, 0x23, 0x23, 0x00 });
                
                byte[] body = new byte[] { 0x23 };
                byte[] crc = _bytes.CrcGet(body);
                Assert.AreEqual(crc, new byte[] { 0x23, 0x00 });

                body = getMassaResponse;
                crc = _bytes.CrcGet(body);
                Assert.AreEqual(crc, new byte[] { 0xFC, 0x23 });
                requestCheck = _massaRequest.MakeRequestCrcAdd(body);
                Assert.AreEqual(requestCheck, new byte[] { 0xF8, 0x55, 0xCE, 0x0D, 0x00, 0x24, 0x00, 0x00, 0x00, 0x00, 0x01, 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0xFC, 0x23 });
            });

            Utils.MethodComplete();
        }
    }
}