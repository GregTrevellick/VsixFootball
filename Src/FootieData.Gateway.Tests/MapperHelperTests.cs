﻿using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FootieData.Gateway.Tests
{
    [TestClass]
    public class MapperHelperTests
    {
        [TestMethod]
        public void MapExternalTeamNameToInternalTeamNameTest()
        {
            Assert.AreEqual("Unknown", MapperHelper.MapExternalTeamNameToInternalTeamName(null));
            Assert.AreEqual("Unknown", MapperHelper.MapExternalTeamNameToInternalTeamName(""));
            Assert.AreEqual("Manchester United", MapperHelper.MapExternalTeamNameToInternalTeamName("ManU"));
            Assert.AreEqual("Arsenal", MapperHelper.MapExternalTeamNameToInternalTeamName("Arsenal"));
        }

        [TestMethod]
        public void GetTimeTest()
        {
            //https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings

            //Arrange
            var date = new DateTime(2001, 12, 31, 13, 45, 30);

            //Act/Assert
            Assert.AreEqual("1:45 PM", MapperHelper.GetTime(date, new CultureInfo("en-US")));
            Assert.AreEqual("13:45", MapperHelper.GetTime(date, new CultureInfo("en-GB")));
            Assert.AreEqual("13:45", MapperHelper.GetTime(date, new CultureInfo("hr-HR")));
            Assert.AreEqual("01:45 م", MapperHelper.GetTime(date, new CultureInfo("ar-EG")));            
        }

        [TestMethod]
        public void GetDateTest()
        {
            //Arrange
            var date = new DateTime(2001,12,31,04,05,06);

            //Act/Assert
            Assert.AreEqual("12/31/2001", MapperHelper.GetDate(date, new CultureInfo("en-US")));
            Assert.AreEqual("31/12/2001", MapperHelper.GetDate(date, new CultureInfo("en-GB")));
            Assert.AreEqual("31/12/2001", MapperHelper.GetDate(date, new CultureInfo("fr-FR")));
            Assert.AreEqual("31.12.2001", MapperHelper.GetDate(date, new CultureInfo("de-DE")));
        }
    }
}
