using System;
using Xunit;
using BusinessLayer.Model;
using BusinessLayer.Model.Exceptions;

namespace TestProjectBusinessLayer
{
    public class UnitTest1
    {
        //Altijd iets dat lukt en iets dat niet lukt
        //Valid -> moet waar zijn
        //Invalid -> moet niet waar zijn
        //Fact == 1 // theory 1<

        [Fact]
        public void Test_ZetId_Valid()
        {
            //Kledingmaat kledingmaat, double prijs, string seizoen, Club club, Clubset clubset
            Truitje truitje = new Truitje(Kledingmaat.M, 15.25, "Testseizoen", new Club("Premier league", "City"), new Clubset(true, 1));
            truitje.ZetId(1);
            Assert.Equal(1, truitje.Id);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Test_ZetId_InValid(int id)
        {
            Truitje truitje = new Truitje(Kledingmaat.M, 15.25, "Testseizoen", new Club("Premier league", "City"), new Clubset(true, 1));
            var ex = Assert.Throws<VoetbaltruitjesException>(() => truitje.ZetId(id));
            Assert.Equal("Voetbaltruitje - invalid id", ex.Message);
        }

        [Fact]
        public void Test_ZetClub_ValidReference()
        {
            Truitje truitje = new Truitje(Kledingmaat.M, 15.25, "Testseizoen", new Club("Premier league", "City"), new Clubset(true, 1));
            Club club = new Club("Premier league", "Leicester");
            truitje.ZetClub(club);
            Assert.Equal(club, truitje.Club);
        }

        [Fact]
        public void Test_ZetClub_InValid()
        {
            Truitje truitje = new Truitje(Kledingmaat.M, 15.25, "Testseizoen", new Club("Premier league", "City"), new Clubset(true, 1));
            Assert.Throws<VoetbaltruitjesException>(() => truitje.ZetClub(null));
        }
    }
}
