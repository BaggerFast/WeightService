﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// http://srecord.sourceforge.net/crc16-ccitt.html

using NUnit.Framework;
using System;
using System.Linq;
using WeightCore.MassaK;

namespace HardwareTests.MassaK
{
    [TestFixture]
    internal class Crc16MassaKTests
    {
        // CMD_GET_MASSA
        // IRP_MJ_WRITE	F8 55 CE 01 00 23 23 00
        // IRP_MJ_READ	F8 55 CE 0D 00 24 00 00 00 00 01 01 00 01 00 00 00 00 FC 23

        private byte[] getMassaRequest = MassaUtils.Cmd.Get.CMD_GET_MASSA.Skip(5).Take(1).ToArray();
        private byte[] getMassaResponse = new byte[] { 0x24, 0x00, 0x00, 0x00, 0x00, 0x01, 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 };

        [Test]
        public void ComputeChecksum_AreEqual()
        {
            Utils.MethodStart();

            Assert.DoesNotThrow(() =>
            {
                byte[] data = getMassaRequest;
                ushort crc = 0;
                .
                foreach (NullFX.CRC.Crc16Algorithm algorithm in (NullFX.CRC.Crc16Algorithm[])Enum.GetValues(typeof(NullFX.CRC.Crc16Algorithm)))
                {
                    crc = NullFX.CRC.Crc16.ComputeChecksum(algorithm, data);
                    TestContext.WriteLine($"{nameof(algorithm)}: {algorithm}. {nameof(data)}: {data}. {nameof(crc)}: {crc}");
                }

                Assert.AreEqual(0x2300, 0x2300);
            });

            Utils.MethodComplete();
        }
    }
}
