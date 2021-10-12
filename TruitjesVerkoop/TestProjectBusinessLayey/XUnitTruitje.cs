using System;
using Xunit;
using BusinessLayer.Exceptions;
using BusinessLayer;
using BusinessLayer.Model;

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
            Trui truitje = new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, new ClubSet(true, 1));

            Assert.Equal("premier league", truitje.Club.Competitie);
            Assert.Equal("city", truitje.Club.PloegNaam);
            Assert.Equal("2021-2022", truitje.Seizoen);
            Assert.Equal(87, truitje.Prijs);
            Assert.Equal(Maat.M, truitje.Kledingmaat);
            Assert.True(truitje.ClubSet.Thuis);
            Assert.Equal(1, truitje.ClubSet.Versie);
        }
        [Theory]
        [InlineData(-10.5)]
        [InlineData(-0.5)]
        [InlineData(0)]
        public void Test_ctor_noId_InValid(double prijs)
        {
            Assert.Throws<TruiException>(() => new Trui(new Club("premier league", "city"), "2021-2022", prijs, Maat.M, new ClubSet(true, 1)));
        }
        [Fact]
        public void Test_ctor_noId_noClub_InValid()
        {
            Assert.Throws<TruiException>(() => new Trui(null, "2021-2022", 87, Maat.M, new ClubSet(true, 1)));
        }
        [Fact]
        public void Test_ctor_noId_noClubSet_InValid()
        {
            Assert.Throws<TruiException>(() => new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, null));
        }
        [Fact]
        public void Test_ctor_Id_Valid()
        {
            Trui truitje = new Trui(10, new Club("premier league", "city"), "2021-2022", 87, Maat.M, new ClubSet(true, 1)); ;
            Assert.Equal(10, truitje.Id);
            Assert.Equal("premier league", truitje.Club.Competitie);
            Assert.Equal("city", truitje.Club.PloegNaam);
            Assert.Equal("2021-2022", truitje.Seizoen);
            Assert.Equal(87, truitje.Prijs);
            Assert.Equal(Maat.M, truitje.Kledingmaat);
            Assert.True(truitje.ClubSet.Thuis);
            Assert.Equal(1, truitje.ClubSet.Versie);
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
            Assert.Throws<TruiException>(() => new Trui(id, new Club("premier league", "city"), "2021-2022", prijs, Maat.M, new ClubSet(true, 1)));
        }
        [Fact]
        public void Test_ctor_Id_noClub_InValid()
        {
            Assert.Throws<TruiException>(() => new Trui(10, null, "2021-2022", 87, Maat.M, new ClubSet(true, 1)));
        }
        [Fact]
        public void Test_ctor_Id_noClubSet_InValid()
        {
            Assert.Throws<TruiException>(() => new Trui(10, new Club("premier league", "city"), "2021-2022", 87, Maat.M, null));
        }
        [Fact]
        public void Test_ZetId_Valid()
        {
            Trui truitje = new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, new ClubSet(true, 1));
            truitje.ZetId(1);
            Assert.Equal(1, truitje.Id);
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Test_ZetId_InValid(int id)
        {
            Trui truitje = new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, new ClubSet(true, 1));
            var ex = Assert.Throws<TruiException>(() => truitje.ZetId(id));
            Assert.Equal("Trui - invalid id", ex.Message);
        }
        [Fact]
        public void Test_ZetPrijs_Valid()
        {
            Trui truitje = new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, new ClubSet(true, 1));
            truitje.ZetPrijs(10.5);
            Assert.Equal(10.5, truitje.Prijs);
        }
        [Theory]
        [InlineData(-10.5)]
        [InlineData(-0.5)]
        [InlineData(0)]
        public void Test_ZetPrijs_InValid(double prijs)
        {
            Trui truitje = new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, new ClubSet(true, 1));
            var ex = Assert.Throws<TruiException>(() => truitje.ZetPrijs(prijs));
            Assert.Equal("Trui - invalid prijs", ex.Message);
        }
        [Fact]
        public void Test_ZetClub_ValidReference()
        {
            Trui truitje = new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, new ClubSet(true, 1));
            Club club = new Club("premier league", "Leicester");
            truitje.ZetClub(club);
            Assert.Equal(club, truitje.Club);
        }
        [Fact]
        public void Test_ZetClub_ValidValue()
        {
            Trui truitje = new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, new ClubSet(true, 1));
            Club club = new Club("premier league", "Leicester");
            truitje.ZetClub(club);

            Assert.Equal("premier league", truitje.Club.Competitie);
            Assert.Equal("Leicester", truitje.Club.PloegNaam);
        }
        [Fact]
        public void Test_ZetClub_InValid()
        {
            Trui truitje = new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, new ClubSet(true, 1));
            Assert.Throws<TruiException>(() => truitje.ZetClub(null));
        }
        [Fact]
        public void Test_ZetClubSet_ValidReference()
        {
            Trui truitje = new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, new ClubSet(true, 1));
            ClubSet clubset = new ClubSet(true, 1);
            truitje.ZetClubSet(clubset);
            Assert.Equal(clubset, truitje.ClubSet);
        }
        [Fact]
        public void Test_ZetClubSet_ValidValue()
        {
            Trui truitje = new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, new ClubSet(true, 1));
            ClubSet clubset = new ClubSet(true, 1);
            truitje.ZetClubSet(clubset);

            Assert.True(truitje.ClubSet.Thuis);
            Assert.Equal(1, truitje.ClubSet.Versie);
        }
        [Fact]
        public void Test_ZetClubSet_InValid()
        {
            Trui truitje = new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, new ClubSet(true, 1));
            Assert.Throws<TruiException>(() => truitje.ZetClubSet(null));
        }

    }
}
