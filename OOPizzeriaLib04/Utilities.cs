using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPizzeriaLib04.Utilities;

namespace OOPizzeriaLib04
{
    public static class Utilities
    {
        public struct SizeType
        {
            public const string Personal = "Personal";
            public const string Small = "Small";
            public const string Medium = "Medium";
            public const string Large = "Large";
            public const string ExtraLarge = "Extra Large";
            public const string Party = "Party";
        }

        public static class PizzaPrice 
        {
            public const int NewYorkBasePrice = 9;
            public const int ChicagoBasePrice = 7;
            public const int CaliforniaBasePrice = 7;
        }

        //public enum PizzaPrice : int
        //{
        //    NYPersonalCheese = 9,
        //    NYSmallCheese = NYPersonalCheese + 2,
        //    NYMediumCheese = NYPersonalCheese + 4,
        //    NYLargeCheese = NYPersonalCheese + 6,
        //    NYExtraLargeCheese = NYPersonalCheese + 8,
        //    NYPartyCheese = NYPersonalCheese + 10,

        //    NYPersonalPepperoni = 10,
        //    NYSmallPepperoni = NYPersonalPepperoni + 2,
        //    NYMediumPepperoni = NYPersonalPepperoni + 4,
        //    NYLargePepperoni = NYPersonalPepperoni + 6,
        //    NYExtraLargePepperoni = NYPersonalPepperoni + 8,
        //    NYPartyPepperoni = NYPersonalPepperoni + 10,

        //    NYPersonalHawaiian = 11,
        //    NYSmallHawaiian = NYPersonalHawaiian + 2,
        //    NYMediumHawaiian = NYPersonalHawaiian + 4,
        //    NYLargeHawaiian = NYPersonalHawaiian + 6,
        //    NYExtraLargeHawaiian = NYPersonalHawaiian + 8,
        //    NYPartyHawaiian = NYPersonalHawaiian + 10,

        //    NYPersonalGreek = 15,
        //    NYSmallGreek = NYPersonalGreek + 2,
        //    NYMediumGreek = NYPersonalGreek + 4,
        //    NYLargeGreek = NYPersonalGreek + 6,
        //    NYExtraLargeGreek = NYPersonalGreek + 8,
        //    NYPartyGreek = NYPersonalGreek + 10,

        //    NYPersonalVegeterian = 13,
        //    NYSmallVegeterian = NYPersonalVegeterian + 2,
        //    NYMediumVegeterian = NYPersonalVegeterian + 4,
        //    NYLargeVegeterian = NYPersonalVegeterian + 6,
        //    NYExtraLargeVegeterian = NYPersonalVegeterian + 8,
        //    NYPartyVegeterian = NYPersonalVegeterian + 10,

        //    NYPersonalClam = 16,
        //    NYSmallClam = NYPersonalClam + 2,
        //    NYMediumClam = NYPersonalClam + 4,
        //    NYLargeClam = NYPersonalClam + 6,
        //    NYExtraLargeClam = NYPersonalClam + 8,
        //    NYPartyClam = NYPersonalClam + 10,

        //    ChicagoPersonalCheese = 7,
        //    ChicagoSmallCheese = ChicagoPersonalCheese + 2,
        //    ChicagoMediumCheese = ChicagoPersonalCheese + 4,
        //    ChicagoLargeCheese = ChicagoPersonalCheese + 6,
        //    ChicagoExtraLargeCheese = ChicagoPersonalCheese + 8,
        //    ChicagoPartyCheese = ChicagoPersonalCheese + 10,

        //    ChicagoPersonalPepperoni = 9,
        //    ChicagoSmallPepperoni = ChicagoPersonalPepperoni + 2,
        //    ChicagoMediumPepperoni = ChicagoPersonalPepperoni + 4,
        //    ChicagoLargePepperoni = ChicagoPersonalPepperoni + 6,
        //    ChicagoExtraLargePepperoni = ChicagoPersonalPepperoni + 8,
        //    ChicagoPartyPepperoni = ChicagoPersonalPepperoni + 10,

        //    ChicagoPersonalHawaiian = 12,
        //    ChicagoSmallHawaiian = ChicagoPersonalHawaiian + 2,
        //    ChicagoMediumHawaiian = ChicagoPersonalHawaiian + 4,
        //    ChicagoLargeHawaiian = ChicagoPersonalHawaiian + 6,
        //    ChicagoExtraLargeHawaiian = ChicagoPersonalHawaiian + 8,
        //    ChicagoPartyHawaiian = ChicagoPersonalHawaiian + 10,

        //    ChicagoPersonalGreek = 14,
        //    ChicagoSmallGreek = ChicagoPersonalGreek + 2,
        //    ChicagoMediumGreek = ChicagoPersonalGreek + 4,
        //    ChicagoLargeGreek = ChicagoPersonalGreek + 6,
        //    ChicagoExtraLargeGreek = ChicagoPersonalGreek + 8,
        //    ChicagoPartyGreek = ChicagoPersonalGreek + 10,

        //    ChicagoPersonalVegeterian = 13,
        //    ChicagoSmallVegeterian = ChicagoPersonalVegeterian + 2,
        //    ChicagoMediumVegeterian = ChicagoPersonalVegeterian + 4,
        //    ChicagoLargeVegeterian = ChicagoPersonalVegeterian + 6,
        //    ChicagoExtraLargeVegeterian = ChicagoPersonalVegeterian + 8,
        //    ChicagoPartyVegeterian = ChicagoPersonalVegeterian + 10,

        //    ChicagoPersonalClam = 15,
        //    ChicagoSmallClam = ChicagoPersonalClam + 2,
        //    ChicagoMediumClam = ChicagoPersonalClam + 4,
        //    ChicagoLargeClam = ChicagoPersonalClam + 6,
        //    ChicagoExtraLargeClam = ChicagoPersonalClam + 8,
        //    ChicagoPartyClam = ChicagoPersonalClam + 10,

        //    CaliforniaPersonalCheese = 10,
        //    CaliforniaSmallCheese = CaliforniaPersonalCheese + 2,
        //    CaliforniaMediumCheese = CaliforniaPersonalCheese + 4,
        //    CaliforniaLargeCheese = CaliforniaPersonalCheese + 6,
        //    CaliforniaExtraLargeCheese = CaliforniaPersonalCheese + 8,
        //    CaliforniaPartyCheese = CaliforniaPersonalCheese + 10,

        //    CaliforniaPersonalPepperoni = 11,
        //    CaliforniaSmallPepperoni = CaliforniaPersonalPepperoni + 2,
        //    CaliforniaMediumPepperoni = CaliforniaPersonalPepperoni + 4,
        //    CaliforniaLargePepperoni = CaliforniaPersonalPepperoni + 6,
        //    CaliforniaExtraLargePepperoni = CaliforniaPersonalPepperoni + 8,
        //    CaliforniaPartyPepperoni = CaliforniaPersonalPepperoni + 10,

        //    CaliforniaPersonalHawaiian = 12,
        //    CaliforniaSmallHawaiian = CaliforniaPersonalHawaiian + 2,
        //    CaliforniaMediumHawaiian = CaliforniaPersonalHawaiian + 4,
        //    CaliforniaLargeHawaiian = CaliforniaPersonalHawaiian + 6,
        //    CaliforniaExtraLargeHawaiian = CaliforniaPersonalHawaiian + 8,
        //    CaliforniaPartyHawaiian = CaliforniaPersonalHawaiian + 10,

        //    CaliforniaPersonalGreek = 16,
        //    CaliforniaSmallGreek = CaliforniaPersonalGreek + 2,
        //    CaliforniaMediumGreek = CaliforniaPersonalGreek + 4,
        //    CaliforniaLargeGreek = CaliforniaPersonalGreek + 6,
        //    CaliforniaExtraLargeGreek = CaliforniaPersonalGreek + 8,
        //    CaliforniaPartyGreek = CaliforniaPersonalGreek + 10,

        //    CaliforniaPersonalVegeterian = 14,
        //    CaliforniaSmallVegeterian = CaliforniaPersonalVegeterian + 2,
        //    CaliforniaMediumVegeterian = CaliforniaPersonalVegeterian + 4,
        //    CaliforniaLargeVegeterian = CaliforniaPersonalVegeterian + 6,
        //    CaliforniaExtraLargeVegeterian = CaliforniaPersonalVegeterian + 8,
        //    CaliforniaPartyVegeterian = CaliforniaPersonalVegeterian + 10,

        //    CaliforniaPersonalClam = 16,
        //    CaliforniaSmallClam = CaliforniaPersonalClam + 2,
        //    CaliforniaMediumClam = CaliforniaPersonalClam + 4,
        //    CaliforniaLargeClam = CaliforniaPersonalClam + 6,
        //    CaliforniaExtraLargeClam = CaliforniaPersonalClam + 8,
        //    CaliforniaPartyClam = CaliforniaPersonalClam + 10,
        //}

    }
    public class PizzaSize()
    {
        public int Id;
        public string Size { get; set; } = SizeType.Medium;
    }

}
