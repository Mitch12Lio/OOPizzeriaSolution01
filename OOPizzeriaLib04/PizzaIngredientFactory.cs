using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPizzeriaLib04;

namespace OOPizzeriaLib04
{
    public interface IPizzaTopping
    {
        string Name { get; }
    }
    public interface IPizzaIngredientFactory
    {
        public Dough CreateDough();
        public Sauce CreateSauce();
        public Cheese CreateCheese();
        //public Cheese CreateExtras();
        public List<Vegetables> CreateVegetarianList();
        public Pepperoni CreatePepperoni();
        public Clam CreateClam();
        public Ham CreateHam();
        public List<Fruit> CreateFruitList();
        public Bacon CreateBacon();
    }

    public abstract class Dough : IPizzaTopping { public abstract string Name { get; } }
    public abstract class Sauce : IPizzaTopping { public abstract string Name { get; } }
    public abstract class Cheese : IPizzaTopping { public abstract string Name { get; } }
    public abstract class Vegetables : IPizzaTopping { public abstract string Name { get; } }
    public abstract class Pepperoni : IPizzaTopping { public abstract string Name { get; } }
    public abstract class Clam : IPizzaTopping { public abstract string Name { get; } }
    public abstract class Ham : IPizzaTopping { public abstract string Name { get; } }
    public abstract class Fruit : IPizzaTopping { public abstract string Name { get; } }
    public abstract class Bacon : IPizzaTopping { public abstract string Name { get; } }

    public class NYPizzaIngredientFactory : IPizzaIngredientFactory
    {
        public Dough CreateDough()
        {
            return new ThinCrustDough();
        }

        public Sauce CreateSauce()
        {
            return new MarinaraSauce();
        }
        public Cheese CreateCheese()
        {
            return new ReggianoCheese();
        }

        public Clam CreateClam()
        {
            return new FreshClam();
        }

        public Pepperoni CreatePepperoni()
        {
            return new SlicedPepperoni();
        }

        public List<Vegetables> CreateVegetarianList()
        {
            List<Vegetables> vegetarianList = [new Mushroom(), new Garlic(), new Tomato()];
            return vegetarianList;
        }
        public List<Fruit> CreateFruitList()
        {
            List<Fruit> fruitList = [new Pineapple()];
            return fruitList;
        }

        public Ham CreateHam()
        {
            return new CountryHam();
        }

        public Bacon CreateBacon()
        {
            return new BackBacon();
        }
    }

    public class ChicagoPizzaIngredientFactory : IPizzaIngredientFactory
    {
        public Cheese CreateCheese()
        {
            return new MozzarellaCheese();
        }

        public Clam CreateClam()
        {
            return new FrozenClam();
        }

        public Dough CreateDough()
        {
            return new ThickCrustDough();
        }

        public Pepperoni CreatePepperoni()
        {
            return new SpicyPepperoni();
        }

        public Sauce CreateSauce()
        {
            return new MamaRosaSauce();
        }
        public List<Vegetables> CreateVegetarianList()
        {
            List<Vegetables> vegetarianList = [new GreenPepper(), new Garlic(), new Mushroom()];
            return vegetarianList;
        }

        public List<Fruit> CreateFruitList()
        {
            List<Fruit> fruitList = [new Pineapple()];
            return fruitList;
        }

        public Ham CreateHam()
        {
            return new Prosciutto();
        }

        public Bacon CreateBacon()
        {
            return new BackBacon();
        }

    }

    public class CaliforniaPizzaIngredientFactory : IPizzaIngredientFactory
    {
        public Cheese CreateCheese()
        {
            return new ProvoloneCheese();
        }

        public Clam CreateClam()
        {
            return new FreshClam();
        }

        public Dough CreateDough()
        {
            return new StuffedCrustDough();
        }

        public Pepperoni CreatePepperoni()
        {
            return new SlicedPepperoni();
        }

        public Sauce CreateSauce()
        {
            return new PlumTomatoSauce();
        }

        public List<Vegetables> CreateVegetarianList()
        {
            List<Vegetables> vegetarianList = [new Onions(), new Tomato()];
            return vegetarianList;
        }

        public List<Fruit> CreateFruitList()
        {
            List<Fruit> fruitList = [new Pineapple()];
            return fruitList;
        }
        public Ham CreateHam()
        {
            return new BlackForestHam();
        }

        public Bacon CreateBacon()
        {
            return new CanadianBacon();
        }
    }


    public class ThickCrustDough : Dough { public override string Name { get => "Thick Crust Dough"; } }
    public class ThinCrustDough : Dough { public override string Name { get => "Thin Crust Dough"; } }
    public class StuffedCrustDough : Dough { public override string Name { get => "Stuffed Crust Dough"; } }

    public class PlumTomatoSauce : Sauce { public override string Name { get => "Plum Tomato Sauce"; } }
    public class MarinaraSauce : Sauce { public override string Name { get => "Marinara Sauce"; } }
    public class MamaRosaSauce : Sauce { public override string Name { get => "Mama Rosa Sauce"; } }

    public class MozzarellaCheese : Cheese { public override string Name { get => "Mozzarella Cheese"; } }
    public class ReggianoCheese : Cheese { public override string Name { get => "Reggiano Cheese"; } }
    public class FetaCheese : Cheese { public override string Name { get => "Feta Cheese"; } }
    public class ProvoloneCheese : Cheese { public override string Name { get => "Provolone Cheese"; } }

    public class FrozenClam : Clam { public override string Name { get => "Frozen Clam"; } }
    public class FreshClam : Clam { public override string Name { get => "Fresh Clam"; } }

    public class SlicedPepperoni : Pepperoni { public override string Name { get => "Sliced Pepperoni"; } }
    public class CaliforniaSweetPepperoni : Pepperoni { public override string Name { get => "California Sweet Pepperoni"; } }
    public class SpicyPepperoni : Pepperoni { public override string Name { get => "Spicy Pepperoni"; } }

    public class Onions : Vegetables { public override string Name { get => "Onion"; } }
    public class GreenPepper : Vegetables { public override string Name { get => "Green Pepper"; } }
    public class Tomato : Vegetables { public override string Name { get => "Tomato"; } }
    public class Garlic : Vegetables { public override string Name { get => "Garlic"; } }
    public class Mushroom : Vegetables { public override string Name { get => "Mushroom"; } }
    public class BlackOlives : Vegetables { public override string Name { get => "Black Olives"; } }

    public class Pineapple : Fruit { public override string Name { get => "Pineapple"; } }

    public class CountryHam : Ham { public override string Name { get => "Country Ham"; } }
    public class BlackForestHam : Ham { public override string Name { get => "Black Forest Ham"; } }
    public class Prosciutto : Ham { public override string Name { get => "Prosciutto"; } }

    public class CanadianBacon : Bacon { public override string Name { get => "Canadian Bacon"; } }
    public class BackBacon : Bacon { public override string Name { get => "Back Bacon"; } }

}
