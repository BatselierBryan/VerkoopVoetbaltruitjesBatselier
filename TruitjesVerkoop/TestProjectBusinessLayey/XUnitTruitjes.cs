using System;
using Xunit;
using BusinessLayer.Model;
using BusinessLayer.Model.Exceptions;

namespace TestProjectBusinessLayer
{
    public class XUnitTruitjes
    {
        //Altijd iets dat lukt en iets dat niet lukt
        //Valid -> moet waar zijn
        //Invalid -> moet niet waar zijn
        //Fact == 1 // theory 1<

        [Fact]
        public void Test_ctor_noId_Valid()
        {
            Truitje truitje = new Truitje(Kledingmaat.M, 87, "2021-2022", new Club("premier league", "city"), new Clubset(true, 1));

            Assert.Equal("premier league", truitje.Club.Competitie);
            Assert.Equal("city", truitje.Club.Ploegnaam);
            Assert.Equal("2021-2022", truitje.Seizoen);
            Assert.Equal(87, truitje.Prijs);
            Assert.Equal(Kledingmaat.M, truitje.Kledingmaat);
            Assert.True(truitje.Clubset.Thuis);
            Assert.Equal(1, truitje.Clubset.Versie);
        }
        [Theory]
        [InlineData(-10.5)]
        [InlineData(-0.5)]
        [InlineData(0)]
        public void Test_ctor_noId_InValid(double prijs)
        {
            Assert.Throws<VoetbaltruitjesException>(() => new Truitje(Kledingmaat.M, prijs, "2021-2022", new Club("premier league", "city"), new Clubset(true, 1)));
        }
        [Fact]
        public void Test_ctor_noId_noClub_InValid()   
        {
            Assert.Throws<VoetbaltruitjesException>(() => new Truitje(Kledingmaat.M, 87, "2021-2022", null, new Clubset(true, 1)));
        }
        [Fact]
        public void Test_ctor_noId_noClubSet_InValid() 
        {
            Assert.Throws<VoetbaltruitjesException>(() => new Truitje(Kledingmaat.M, 87, "2021-2022", new Club("premier league", "city"), null));
        }
        [Fact]
        public void Test_ctor_Id_Valid()
        {
            Truitje truitje = new Truitje(10 ,Kledingmaat.M, 87, "2021-2022", new Club("premier league", "city"), new Clubset(true, 1)); ;
            Assert.Equal(10, truitje.Id);
            Assert.Equal("premier league", truitje.Club.Competitie);
            Assert.Equal("city", truitje.Club.Ploegnaam);
            Assert.Equal("2021-2022", truitje.Seizoen);
            Assert.Equal(87, truitje.Prijs);
            Assert.Equal(Kledingmaat.M, truitje.Kledingmaat);
            Assert.True(truitje.Clubset.Thuis);
            Assert.Equal(1, truitje.Clubset.Versie);
        }
        [Theory]
        [InlineData(10, -10.5)]
        [InlineData(10, -0.5)]
        [InlineData(10, 0)]
        [InlineData(-10, 100)]
        [InlineData(0, 100)]
        [InlineData(-1, 100)]
        [InlineData(-10, 0)]
        public void Test_ctor_Id_InValid(int id, double prijs)
        {
            Assert.Throws<VoetbaltruitjesException>(() => new Truitje(id, Kledingmaat.M, prijs, "2021-2022", new Club("premier league", "city"), new Clubset(true, 1)));
        }
        [Fact]
        public void Test_ctor_Id_noClub_InValid()
        {
            Assert.Throws<VoetbaltruitjesException>(() => new Truitje(10 ,Kledingmaat.M, 87, "2021-2022", null, new Clubset(true, 1)));
        }
        [Fact]
        public void Test_ctor_Id_noClubSet_InValid()
        {
            Assert.Throws<VoetbaltruitjesException>(() => new Truitje(10, Kledingmaat.M, 87, "2021-2022", new Club("premier league", "city"), null));
        }
        [Fact]
        public void Test_ZetId_Valid()
        {
            Truitje truitje = new Truitje(Kledingmaat.M, 87, "2021-2022", new Club("premier league", "city"), new Clubset(true, 1));
            truitje.ZetId(1);
            Assert.Equal(1, truitje.Id);
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Test_ZetId_InValid(int id)
        {
            Truitje truitje = new Truitje(Kledingmaat.M, 87, "2021-2022", new Club("premier league", "city"), new Clubset(true, 1));
            var ex = Assert.Throws<VoetbaltruitjesException>(() => truitje.ZetId(id));
            Assert.Equal("Truitje - invalid id", ex.Message);
        }
        [Fact]
        public void Test_ZetPrijs_Valid()
        {
            Truitje truitje = new Truitje(Kledingmaat.M, 87, "2021-2022", new Club("premier league", "city"), new Clubset(true, 1));
            truitje.ZetPrijs(10.5);
            Assert.Equal(10.5, truitje.Prijs);
        }
        [Theory]
        [InlineData(-10.5)]
        [InlineData(-0.5)]
        [InlineData(0)]
        public void Test_ZetPrijs_InValid(double prijs)
        {
            Truitje truitje = new Truitje(Kledingmaat.M, 87, "2021-2022", new Club("premier league", "city"), new Clubset(true, 1));
            var ex = Assert.Throws<VoetbaltruitjesException>(() => truitje.ZetPrijs(prijs));
            Assert.Equal("Truitje - invalid prijs", ex.Message);
        }
        [Fact]
        public void Test_ZetClub_ValidReference()
        {
            Truitje truitje = new Truitje(Kledingmaat.M, 87, "2021-2022", new Club("premier league", "city"), new Clubset(true, 1));
            Club club = new Club("premier league", "Leicester");
            truitje.ZetClub(club);
            Assert.Equal(club, truitje.Club);
        }
        [Fact]
        public void Test_ZetClub_ValidValue()
        {
            Truitje truitje = new Truitje(Kledingmaat.M, 87, "2021-2022", new Club("premier league", "city"), new Clubset(true, 1));
            Club club = new Club("premier league", "Leicester");
            truitje.ZetClub(club);

            Assert.Equal("premier league", truitje.Club.Competitie);
            Assert.Equal("Leicester", truitje.Club.Ploegnaam);
        }
        [Fact]
        public void Test_ZetClub_InValid()
        {
            Truitje truitje = new Truitje(Kledingmaat.M, 87, "2021-2022", new Club("premier league", "city"), new Clubset(true, 1));
            Assert.Throws<VoetbaltruitjesException>(() => truitje.ZetClub(null));
        }
        [Fact]
        public void Test_ZetClubSet_ValidReference()
        {
            Truitje truitje = new Truitje(Kledingmaat.M, 87, "2021-2022", new Club("premier league", "city"), new Clubset(true, 1));
            Clubset clubset = new Clubset(true, 1);
            truitje.ZetClubset(clubset);
            Assert.Equal(clubset, truitje.Clubset);
        }
        [Fact]
        public void Test_ZetClubSet_ValidValue()
        {
            Truitje truitje = new Truitje(Kledingmaat.M, 87, "2021-2022", new Club("premier league", "city"), new Clubset(true, 1));
            Clubset clubset = new Clubset(true, 1);
            truitje.ZetClubset(clubset);

            Assert.True(truitje.Clubset.Thuis);
            Assert.Equal(1, truitje.Clubset.Versie);
        }
        [Fact]
        public void Test_ZetClubSet_InValid()
        {
            Truitje truitje = new Truitje(Kledingmaat.M, 87, "2021-2022", new Club("premier league", "city"), new Clubset(true, 1));
            Assert.Throws<VoetbaltruitjesException>(() => truitje.ZetClubset(null));
        }

    }
}
