using System;
using Xunit;
using BusinessLayer.Model;
using BusinessLayer.Model.Exceptions;

namespace TestProjectBusinessLayer
{
    public class XUnitClub
    {
        [Fact]
        public void Test_ctor_noId_Valid()
        {
            Club club = new Club("Premier league", "City");

            Assert.Equal("Premier league", club.Competitie);
            Assert.Equal("City", club.Ploegnaam);
        }
    }
}
