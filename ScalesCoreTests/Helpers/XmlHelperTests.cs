﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NUnit.Framework;
using ScalesCore.Helpers;
using ScalesCore.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace ScalesCoreTests.Helpers
{
    internal class XmlHelperTests
    {
        // Помощник XML.
        private readonly XmlHelper _xmlHelp = XmlHelper.Instance;
        // Имя существующего файла.
        private const string TestFile = @"c:\Program Files\Common Files\microsoft shared\ink\Content.xml";
        // Помощник настроек.
        private readonly SettingsHelper _settingsHelp = SettingsHelper.Instance;

        /// <summary>
        /// Setup private fields.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Setup)} start.");
            //
            TestContext.WriteLine($@"{nameof(Setup)} complete.");
        }

        /// <summary>
        /// Reset private fields to default state.
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Teardown)} start.");
            //
            TestContext.WriteLine($@"{nameof(Teardown)} complete.");
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
        }

        [Test]
        public void Checks_Throws_Exception()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Checks_Throws_Exception)} start.");
            var sw = Stopwatch.StartNew();

            Assert.Throws<FileNotFoundException>(() => _xmlHelp.Checks("test", new Collection<XmlTag>() { new XmlTag(null) }));
            Assert.Throws<FileNotFoundException>(() => _xmlHelp.Checks("test", new Collection<XmlTag>() { new XmlTag(null) }, "test"));
            Assert.Throws<FileNotFoundException>(() => _xmlHelp.Checks("test", new Collection<XmlTag>() { new XmlTag("test", "test") }, "test"));

            Assert.Throws<ArgumentNullException>(() => _xmlHelp.Checks(TestFile, new Collection<XmlTag>() { new XmlTag(null) } ));
            Assert.Throws<ArgumentNullException>(() => _xmlHelp.Checks(TestFile, new Collection<XmlTag>() { new XmlTag(string.Empty, string.Empty) }, string.Empty));
            Assert.Throws<ArgumentNullException>(() => _xmlHelp.Checks(TestFile, new Collection<XmlTag>() { new XmlTag("", "") }, ""));
            Assert.Throws<ArgumentNullException>(() => _xmlHelp.Checks(TestFile, new Collection<XmlTag>() { new XmlTag(null) } ));
            Assert.Throws<ArgumentNullException>(() => _xmlHelp.Checks(TestFile, new Collection<XmlTag>() { new XmlTag(null) }, "test"));
            //Assert.Throws<ArgumentNullException>(() => _xml.Checks(TestFile, new Collection<XmlAttribute>() { new XmlAttribute("test", "test", null) }, null));
            
            Assert.DoesNotThrow(() => _xmlHelp.Checks(TestFile, new Collection<XmlTag>() { new XmlTag("test", "test") }));
            Assert.DoesNotThrow(() => _xmlHelp.Checks(TestFile, new Collection<XmlTag>() { new XmlTag("test", "test") }, "test"));
            
            sw.Stop();
            TestContext.WriteLine($@"{nameof(Checks_Throws_Exception)} complete. Elapsed time: {sw.Elapsed}");
        }

        [Test]
        public void Read_AreEqual()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Read_AreEqual)} start.");
            var sw = Stopwatch.StartNew();

            var actual = _xmlHelp.Read(TestFile, new Collection<XmlTag>()
            {
                new XmlTag("Wizard", "name", "SavedWIZ"),
                new XmlTag("Page", "resID", "IDR_DUI_SAVED"),
                new XmlTag("Item", "name", "group2Link"),
            }, "enabled");
            TestContext.WriteLine(@"Wizard name=""SavedWIZ""");
            TestContext.WriteLine(@"  Page resID=""IDR_DUI_SAVED""");
            TestContext.WriteLine(@"    Item name=""group2Link""");
            TestContext.WriteLine($@"      enabled=""{actual.Value}""");
            
            TestContext.WriteLine("----------------------------------------------");
            TestContext.WriteLine(string.Join(Environment.NewLine, actual.Str));
            TestContext.WriteLine("----------------------------------------------");

            Assert.AreEqual(actual.NoError ? "NOT IsPersonalizationRestricted()" : string.Empty, actual.Value);

            sw.Stop();
            TestContext.WriteLine($@"{nameof(Read_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
        }

        [Test]
        public void ReadScalesUI_ConnectionString_AreEqual()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(ReadScalesUI_ConnectionString_AreEqual)} start.");
            var sw = Stopwatch.StartNew();

            if (File.Exists(_settingsHelp.GetScalesConfigFileName()))
            {
                var actual = _xmlHelp.Read(_settingsHelp.GetScalesConfigFileName(), new Collection<XmlTag>()
                {
                    new XmlTag("connectionStrings"),
                    new XmlTag("add", "name", "ScalesUI.Properties.Settings.ConnectionString"),
                }, "connectionString");
                TestContext.WriteLine($@"ConnectionString=""{actual.Value}""");
                TestContext.WriteLine($@"actual.NoError=""{actual.NoError}""");

                TestContext.WriteLine("----------------------------------------------");
                TestContext.WriteLine(string.Join(Environment.NewLine, actual.Str));
                TestContext.WriteLine("----------------------------------------------");

                Assert.AreEqual(
                    actual.NoError
                        ? @"Server=192.168.5.80\DVLP;Database=ScalesDB;Uid=scale01;Pwd=1q2w3e4r;"
                        : string.Empty, actual.Value);
            }
            else
                Assert.AreEqual(string.Empty, string.Empty);

            sw.Stop();
            TestContext.WriteLine($@"{nameof(ReadScalesUI_ConnectionString_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
        }

        [Test]
        public void ReadScalesUI_ScalesID_AreEqual()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(ReadScalesUI_ScalesID_AreEqual)} start.");
            var sw = Stopwatch.StartNew();

            if (File.Exists(_settingsHelp.GetScalesConfigFileName()))
            {
                var actual = _xmlHelp.Read(_settingsHelp.GetScalesConfigFileName(), new Collection<XmlTag>()
                {
                    new XmlTag("applicationSettings"),
                    new XmlTag("ScalesUI.Properties.Settings"),
                    new XmlTag("setting", "name", "ScalesID"),
                    new XmlTag("value"),
                });
                TestContext.WriteLine($@"ScalesID=""{actual.Value}""");
                TestContext.WriteLine($@"actual.NoError=""{actual.NoError}""");

                TestContext.WriteLine("----------------------------------------------");
                TestContext.WriteLine(string.Join(Environment.NewLine, actual.Str));
                TestContext.WriteLine("----------------------------------------------");

                Assert.AreEqual(actual.NoError ? @"F1A90176-894E-11EA-9E4C-4CCC6A93A440" : string.Empty, actual.Value);
            }
            else
                Assert.AreEqual(string.Empty, string.Empty);

            sw.Stop();
            TestContext.WriteLine($@"{nameof(ReadScalesUI_ScalesID_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
        }
    }
}
