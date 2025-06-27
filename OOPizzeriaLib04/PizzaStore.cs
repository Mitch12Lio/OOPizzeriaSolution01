using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPizzeriaLib04.Utilities;

namespace OOPizzeriaLib04
{
    public abstract class PizzaStore
    {
        public abstract Pizza CreatePizza(Pizza pizzaType, PizzaSizeFactory pizzaSizeFactory, List<string> extras);

        public Pizza OrderPizza(Pizza pizzaType, PizzaSize pizzaSize, List<string> extras)
        {
            PizzaSizeFactory sizeFactory = pizzaSize.Size switch
            {
                SizeType.Personal => new PersonalSize(),
                SizeType.Small => new SmallSize(),
                SizeType.Medium => new MediumSize(),
                SizeType.Large => new LargeSize(),
                SizeType.ExtraLarge => new ExtraLarge(),
                SizeType.Party => new Party(),
                _ => new SmallSize(),
            };
            Pizza? pizza = CreatePizza(pizzaType, sizeFactory, extras);
            _ = pizza.Prepare();

            return pizza;
        }
    }


    public class NYPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(Pizza pizzaType, PizzaSizeFactory sizeFactory, List<string> extras)
        {
            Pizza? pizza = null;

            PizzaPreparationFactory toppingsFactory = new NYPizzaPreperation(new NYPizzaIngredientFactory());
            if (toppingsFactory.ingredientFactory != null)
            {
                if (extras.Any(x => x.Equals("bacon", StringComparison.CurrentCultureIgnoreCase)))
                {
                    toppingsFactory.AddExtraTopping(toppingsFactory.ingredientFactory.CreateBacon());
                }
                if (extras.Any(x => x.Equals("cheese", StringComparison.CurrentCultureIgnoreCase)))
                {
                    toppingsFactory.AddExtraTopping(toppingsFactory.ingredientFactory.CreateCheese());
                }

                if (pizzaType.GetType() == typeof(PepperoniPizza))
                {
                    //Add stardard toppings
                    toppingsFactory.StandardToppings.Add(toppingsFactory.ingredientFactory.CreatePepperoni());

                    //In New York, we put our cheese OVER the toppings
                    toppingsFactory.MakeBase();
                    toppingsFactory.AddStandardToppings();
                    if (toppingsFactory.ExtraToppings.Count > 0)
                    {
                        toppingsFactory.AddExtraToppings();
                    }
                    toppingsFactory.AddCheese();

                    int price = 10;
                    switch (sizeFactory.PizzaSize)
                    {
                        case SizeType.Personal:
                            break;
                        case SizeType.Small:
                            price += 2;
                            break;
                        case SizeType.Medium:
                            price += 4;
                            break;
                        case SizeType.Large:
                            price += 6;
                            break;
                        case SizeType.ExtraLarge:
                            price += 8;
                            break;
                        case SizeType.Party:
                            price += 10;
                            break;
                        default:
                            break;
                    }

                    pizza = new PepperoniPizza(toppingsFactory, sizeFactory)
                    {
                        name = "New York Style Pepperoni Pizza",
                        cost = price + toppingsFactory.ExtraToppings.Count
                    };
                }
                else if (pizzaType.GetType() == typeof(ClamPizza))
                {
                    //Add stardard toppings
                    toppingsFactory.StandardToppings.Add(toppingsFactory.ingredientFactory.CreateClam());
                    //In New York, we put our cheese OVER the toppings
                    toppingsFactory.MakeBase();
                    toppingsFactory.AddStandardToppings();
                    if (toppingsFactory.ExtraToppings.Count > 0)
                    {
                        toppingsFactory.AddExtraToppings();
                    }
                    toppingsFactory.AddCheese();

                    int price = 16;
                    switch (sizeFactory.PizzaSize)
                    {
                        case SizeType.Personal:
                            break;
                        case SizeType.Small:
                            price += 2;
                            break;
                        case SizeType.Medium:
                            price += 4;
                            break;
                        case SizeType.Large:
                            price += 6;
                            break;
                        case SizeType.ExtraLarge:
                            price += 8;
                            break;
                        case SizeType.Party:
                            price += 10;
                            break;
                        default:
                            break;
                    }

                    pizza = new ClamPizza(toppingsFactory, sizeFactory)
                    {
                        name = "New York Style Clam Pizza",
                        cost = price + toppingsFactory.ExtraToppings.Count
                    };
                }
                else if (pizzaType.GetType() == typeof(VegetarianPizza))
                {
                    //Add stardard toppings
                    List<Vegetables>? vegetarianList = toppingsFactory.ingredientFactory.CreateVegetarianList();
                    foreach (var veg in vegetarianList)
                    {
                        toppingsFactory.StandardToppings.Add(veg);
                    }

                    toppingsFactory.MakeBase();
                    toppingsFactory.AddStandardToppings();
                    if (toppingsFactory.ExtraToppings.Count > 0)
                    {
                        toppingsFactory.AddExtraToppings();
                    }
                    toppingsFactory.AddCheese();

                    int price = 12;
                    switch (sizeFactory.PizzaSize)
                    {
                        case SizeType.Personal:
                            break;
                        case SizeType.Small:
                            price += 2;
                            break;
                        case SizeType.Medium:
                            price += 4;
                            break;
                        case SizeType.Large:
                            price += 6;
                            break;
                        case SizeType.ExtraLarge:
                            price += 8;
                            break;
                        case SizeType.Party:
                            price += 10;
                            break;
                        default:
                            break;
                    }

                    pizza = new VegetarianPizza(toppingsFactory, sizeFactory)
                    {
                        name = "New York Style Vegetarian Pizza",
                        cost = price + toppingsFactory.ExtraToppings.Count
                    };
                }
                else if (pizzaType.GetType() == typeof(GreekPizza))
                {
                    //Add stardard toppings
                    toppingsFactory.StandardToppings.Add(new BlackOlives());
                    List<Vegetables>? vegetarianList = toppingsFactory.ingredientFactory.CreateVegetarianList();
                    foreach (var veg in vegetarianList)
                    {
                        toppingsFactory.StandardToppings.Add(veg);
                    }

                    toppingsFactory.MakeBase();
                    toppingsFactory.AddStandardToppings();
                    if (toppingsFactory.ExtraToppings.Count > 0)
                    {
                        toppingsFactory.AddExtraToppings();
                    }
                    toppingsFactory.AddCheese();

                    int price = 15;
                    switch (sizeFactory.PizzaSize)
                    {
                        case SizeType.Personal:
                            break;
                        case SizeType.Small:
                            price += 2;
                            break;
                        case SizeType.Medium:
                            price += 4;
                            break;
                        case SizeType.Large:
                            price += 6;
                            break;
                        case SizeType.ExtraLarge:
                            price += 8;
                            break;
                        case SizeType.Party:
                            price += 10;
                            break;
                        default:
                            break;
                    }

                    pizza = new GreekPizza(toppingsFactory, sizeFactory)
                    {
                        name = "New York Style Greek Pizza",
                        cost = price + toppingsFactory.ExtraToppings.Count
                    };
                }
                else if (pizzaType.GetType() == typeof(HawaiianPizza))
                {
                    //Add stardard toppings
                    toppingsFactory.StandardToppings.Add(toppingsFactory.ingredientFactory.CreateHam());
                    List<Fruit>? fruitList = toppingsFactory.ingredientFactory.CreateFruitList();
                    foreach (var fruit in fruitList)
                    {
                        toppingsFactory.StandardToppings.Add(fruit);
                    }

                    toppingsFactory.MakeBase();
                    toppingsFactory.AddStandardToppings();
                    if (toppingsFactory.ExtraToppings.Count > 0)
                    {
                        toppingsFactory.AddExtraToppings();
                    }
                    toppingsFactory.AddCheese();

                    int price = 11;
                    switch (sizeFactory.PizzaSize)
                    {
                        case SizeType.Personal:
                            break;
                        case SizeType.Small:
                            price += 2;
                            break;
                        case SizeType.Medium:
                            price += 4;
                            break;
                        case SizeType.Large:
                            price += 6;
                            break;
                        case SizeType.ExtraLarge:
                            price += 8;
                            break;
                        case SizeType.Party:
                            price += 10;
                            break;
                        default:
                            break;
                    }

                    pizza = new HawaiianPizza(toppingsFactory, sizeFactory)
                    {
                        name = "New York Style Hawaiian Pizza",
                        cost = price + toppingsFactory.ExtraToppings.Count
                    };
                }
                else //base pizza
                {
                    toppingsFactory.MakeBase();
                    toppingsFactory.AddStandardToppings();
                    if (toppingsFactory.ExtraToppings.Count > 0)
                    {
                        toppingsFactory.AddExtraToppings();
                    }
                    toppingsFactory.AddCheese();

                    int price = 9;
                    switch (sizeFactory.PizzaSize)
                    {
                        case SizeType.Personal:
                            break;
                        case SizeType.Small:
                            price += 2;
                            break;
                        case SizeType.Medium:
                            price += 4;
                            break;
                        case SizeType.Large:
                            price += 6;
                            break;
                        case SizeType.ExtraLarge:
                            price += 8;
                            break;
                        case SizeType.Party:
                            price += 10;
                            break;
                        default:
                            break;
                    }

                    pizza = new CheesePizza(toppingsFactory, sizeFactory)
                    {
                        name = "New York Style Cheese Pizza",
                        cost = price + toppingsFactory.ExtraToppings.Count
                    };
                }

                pizza.style = "New York Style";
                return pizza;
            }
            else
            {
                //ingredients are unavailable
                return new CheesePizza();
            }
        }
    }

    public class ChicagoPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(Pizza pizzaType, PizzaSizeFactory sizeFactory, List<string> extras)
        {
            Pizza? pizza = null;

            PizzaPreparationFactory toppingsFactory = new ChicagoPizzaPreperation(new ChicagoPizzaIngredientFactory());
            if (toppingsFactory.ingredientFactory != null)
            {
                if (extras.Any(x => x.Equals("bacon", StringComparison.CurrentCultureIgnoreCase)))
                {
                    toppingsFactory.AddExtraTopping(toppingsFactory.ingredientFactory.CreateBacon());
                }
                if (extras.Any(x => x.Equals("cheese", StringComparison.CurrentCultureIgnoreCase)))
                {
                    toppingsFactory.AddExtraTopping(toppingsFactory.ingredientFactory.CreateCheese());
                }

                if (pizzaType.GetType() == typeof(PepperoniPizza))
                {
                    //Add stardard toppings
                    toppingsFactory.StandardToppings.Add(toppingsFactory.ingredientFactory.CreatePepperoni());

                    //In Chicago, we like our topping ON TOP of the cheese
                    toppingsFactory.MakeBase();
                    toppingsFactory.AddCheese();

                    int extraToppings = toppingsFactory.ExtraToppings.Count;
                    if (extraToppings > 0)
                    {
                        toppingsFactory.AddExtraToppings();
                    }
                    toppingsFactory.AddStandardToppings();

                    int price = 10;
                    switch (sizeFactory.PizzaSize)
                    {
                        case SizeType.Personal:
                            break;
                        case SizeType.Small:
                            price += 2;
                            break;
                        case SizeType.Medium:
                            price += 4;
                            break;
                        case SizeType.Large:
                            price += 6;
                            break;
                        case SizeType.ExtraLarge:
                            price += 8;
                            break;
                        case SizeType.Party:
                            price += 10;
                            break;
                        default:
                            break;
                    }

                    pizza = new PepperoniPizza(toppingsFactory, sizeFactory)
                    {
                        name = "Chicago Style Pepperoni Pizza",
                        cost = price + extraToppings
                    };
                }
                else if (pizzaType.GetType() == typeof(ClamPizza))
                {
                    //Add stardard toppings
                    toppingsFactory.StandardToppings.Add(toppingsFactory.ingredientFactory.CreateClam());

                    //In Chicago, we put our cheese UNDER the toppings
                    toppingsFactory.MakeBase();
                    toppingsFactory.AddCheese();

                    int extraToppings = toppingsFactory.ExtraToppings.Count;
                    if (extraToppings > 0)
                    {
                        toppingsFactory.AddExtraToppings();
                    }
                    toppingsFactory.AddStandardToppings();

                    int price = 16;
                    switch (sizeFactory.PizzaSize)
                    {
                        case SizeType.Personal:
                            break;
                        case SizeType.Small:
                            price += 2;
                            break;
                        case SizeType.Medium:
                            price += 4;
                            break;
                        case SizeType.Large:
                            price += 6;
                            break;
                        case SizeType.ExtraLarge:
                            price += 8;
                            break;
                        case SizeType.Party:
                            price += 10;
                            break;
                        default:
                            break;
                    }

                    pizza = new ClamPizza(toppingsFactory, sizeFactory)
                    {
                        name = "Chicago Style Clam Pizza",
                        cost = price + extraToppings
                    };
                }
                else if (pizzaType.GetType() == typeof(VegetarianPizza))
                {
                    //Add stardard toppings
                    List<Vegetables>? vegetarianList = toppingsFactory.ingredientFactory.CreateVegetarianList();
                    foreach (var veg in vegetarianList)
                    {
                        toppingsFactory.StandardToppings.Add(veg);
                    }

                    //In Chicago, we put our cheese UNDER the toppings
                    toppingsFactory.MakeBase();
                    toppingsFactory.AddCheese();

                    int extraToppings = toppingsFactory.ExtraToppings.Count;
                    if (extraToppings > 0)
                    {
                        toppingsFactory.AddExtraToppings();
                    }
                    toppingsFactory.AddStandardToppings();

                    int price = 13;
                    switch (sizeFactory.PizzaSize)
                    {
                        case SizeType.Personal:
                            break;
                        case SizeType.Small:
                            price += 2;
                            break;
                        case SizeType.Medium:
                            price += 4;
                            break;
                        case SizeType.Large:
                            price += 6;
                            break;
                        case SizeType.ExtraLarge:
                            price += 8;
                            break;
                        case SizeType.Party:
                            price += 10;
                            break;
                        default:
                            break;
                    }

                    pizza = new VegetarianPizza(toppingsFactory, sizeFactory)
                    {
                        name = "Chicago Style Vegetarian Pizza",
                        cost = price + extraToppings
                    };
                }
                else if (pizzaType.GetType() == typeof(GreekPizza))
                {
                    //Add stardard toppings
                    toppingsFactory.StandardToppings.Add(new BlackOlives());
                    List<Vegetables>? vegetarianList = toppingsFactory.ingredientFactory.CreateVegetarianList();
                    foreach (var veg in vegetarianList)
                    {
                        toppingsFactory.StandardToppings.Add(veg);
                    }

                    //In Chicago, we put our cheese UNDER the toppings
                    toppingsFactory.MakeBase();
                    toppingsFactory.AddCheese();

                    int extraToppings = toppingsFactory.ExtraToppings.Count;
                    if (extraToppings > 0)
                    {
                        toppingsFactory.AddExtraToppings();
                    }
                    toppingsFactory.AddStandardToppings();

                    int price = 14;
                    switch (sizeFactory.PizzaSize)
                    {
                        case SizeType.Personal:
                            break;
                        case SizeType.Small:
                            price += 2;
                            break;
                        case SizeType.Medium:
                            price += 4;
                            break;
                        case SizeType.Large:
                            price += 6;
                            break;
                        case SizeType.ExtraLarge:
                            price += 8;
                            break;
                        case SizeType.Party:
                            price += 10;
                            break;
                        default:
                            break;
                    }

                    pizza = new GreekPizza(toppingsFactory, sizeFactory)
                    {
                        name = "Chicago Style Greek Pizza",
                        cost = price + extraToppings
                    };
                }
                else if (pizzaType.GetType() == typeof(HawaiianPizza))
                {
                    pizza = new ForbiddenPizza(toppingsFactory, sizeFactory)
                    {
                        name = "Hawaiian Pizza is forbidden in Chicago!",
                        cost = 0
                    };
                }
                else //base pizza
                {
                    //In Chicago, we put our cheese UNDER the toppings
                    toppingsFactory.MakeBase();
                    toppingsFactory.AddCheese();

                    int extraToppings = toppingsFactory.ExtraToppings.Count;
                    if (extraToppings > 0)
                    {
                        toppingsFactory.AddExtraToppings();
                    }
                    toppingsFactory.AddStandardToppings();

                    int price = 9;
                    switch (sizeFactory.PizzaSize)
                    {
                        case SizeType.Personal:
                            break;
                        case SizeType.Small:
                            price += 2;
                            break;
                        case SizeType.Medium:
                            price += 4;
                            break;
                        case SizeType.Large:
                            price += 6;
                            break;
                        case SizeType.ExtraLarge:
                            price += 8;
                            break;
                        case SizeType.Party:
                            price += 10;
                            break;
                        default:
                            break;
                    }

                    pizza = new CheesePizza(toppingsFactory, sizeFactory)
                    {
                        name = "Chicago Style Cheese Pizza",
                        cost = price + extraToppings
                    };
                }
                pizza.style = "Chicago Style";
                return pizza;
            }
            else
            {
                //ingredients are unavailable
                return new CheesePizza();
            }
        }
    }

    public class CaliforniaPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(Pizza pizzaType, PizzaSizeFactory sizeFactory, List<string> extras)
        {
            Pizza? pizza = null;

            PizzaPreparationFactory toppingsFactory = new CaliforniaPizzaPreperation(new CaliforniaPizzaIngredientFactory());
            if (toppingsFactory.ingredientFactory != null)
            {
                if (extras.Any(x => x.Equals("bacon", StringComparison.CurrentCultureIgnoreCase)))
                {
                    toppingsFactory.AddExtraTopping(toppingsFactory.ingredientFactory.CreateBacon());
                }
                if (extras.Any(x => x.Equals("cheese", StringComparison.CurrentCultureIgnoreCase)))
                {
                    toppingsFactory.AddExtraTopping(toppingsFactory.ingredientFactory.CreateCheese());
                }

                if (pizzaType.GetType() == typeof(PepperoniPizza))
                {
                    //Add stardard toppings
                    toppingsFactory.StandardToppings.Add(toppingsFactory.ingredientFactory.CreatePepperoni());
                    //In New York, we put our cheese OVER the toppings
                    toppingsFactory.MakeBase();
                    toppingsFactory.AddStandardToppings();
                    if (toppingsFactory.ExtraToppings.Count > 0)
                    {
                        toppingsFactory.AddExtraToppings();
                    }
                    toppingsFactory.AddCheese();

                    int price = 8;
                    switch (sizeFactory.PizzaSize)
                    {
                        case SizeType.Personal:
                            break;
                        case SizeType.Small:
                            price += 2;
                            break;
                        case SizeType.Medium:
                            price += 4;
                            break;
                        case SizeType.Large:
                            price += 6;
                            break;
                        case SizeType.ExtraLarge:
                            price += 8;
                            break;
                        case SizeType.Party:
                            price += 10;
                            break;
                        default:
                            break;
                    }

                    pizza = new PepperoniPizza(toppingsFactory, sizeFactory)
                    {
                        name = "California Style Pepperoni Pizza",
                        cost = price + toppingsFactory.ExtraToppings.Count
                    };
                }
                else if (pizzaType.GetType() == typeof(ClamPizza))
                {
                    //Add stardard toppings
                    toppingsFactory.StandardToppings.Add(toppingsFactory.ingredientFactory.CreateClam());
                    //In New York, we put our cheese OVER the toppings
                    toppingsFactory.MakeBase();
                    toppingsFactory.AddStandardToppings();
                    if (toppingsFactory.ExtraToppings.Count > 0)
                    {
                        toppingsFactory.AddExtraToppings();
                    }
                    toppingsFactory.AddCheese();

                    int price = 19;
                    switch (sizeFactory.PizzaSize)
                    {
                        case SizeType.Personal:
                            break;
                        case SizeType.Small:
                            price += 2;
                            break;
                        case SizeType.Medium:
                            price += 4;
                            break;
                        case SizeType.Large:
                            price += 6;
                            break;
                        case SizeType.ExtraLarge:
                            price += 8;
                            break;
                        case SizeType.Party:
                            price += 10;
                            break;
                        default:
                            break;
                    }

                    pizza = new ClamPizza(toppingsFactory, sizeFactory)
                    {
                        name = "California Style Clam Pizza",
                        cost = price + toppingsFactory.ExtraToppings.Count
                    };
                }
                else if (pizzaType.GetType() == typeof(VegetarianPizza))
                {
                    //Add stardard toppings
                    List<Vegetables>? vegetarianList = toppingsFactory.ingredientFactory.CreateVegetarianList();
                    foreach (var veg in vegetarianList)
                    {
                        toppingsFactory.StandardToppings.Add(veg);
                    }

                    toppingsFactory.MakeBase();
                    toppingsFactory.AddStandardToppings();
                    if (toppingsFactory.ExtraToppings.Count > 0)
                    {
                        toppingsFactory.AddExtraToppings();
                    }
                    toppingsFactory.AddCheese();

                    int price = 12;
                    switch (sizeFactory.PizzaSize)
                    {
                        case SizeType.Personal:
                            break;
                        case SizeType.Small:
                            price += 2;
                            break;
                        case SizeType.Medium:
                            price += 4;
                            break;
                        case SizeType.Large:
                            price += 6;
                            break;
                        case SizeType.ExtraLarge:
                            price += 8;
                            break;
                        case SizeType.Party:
                            price += 10;
                            break;
                        default:
                            break;
                    }

                    pizza = new VegetarianPizza(toppingsFactory, sizeFactory)
                    {
                        name = "California Style Vegetarian Pizza",
                        cost = price + toppingsFactory.ExtraToppings.Count
                    };
                }
                else if (pizzaType.GetType() == typeof(GreekPizza))
                {
                    //Add stardard toppings
                    toppingsFactory.StandardToppings.Add(new BlackOlives());
                    List<Vegetables>? vegetarianList = toppingsFactory.ingredientFactory.CreateVegetarianList();
                    foreach (var veg in vegetarianList)
                    {
                        toppingsFactory.StandardToppings.Add(veg);
                    }

                    toppingsFactory.MakeBase();
                    toppingsFactory.AddStandardToppings();
                    if (toppingsFactory.ExtraToppings.Count > 0)
                    {
                        toppingsFactory.AddExtraToppings();
                    }
                    toppingsFactory.AddCheese();

                    int price = 15;
                    switch (sizeFactory.PizzaSize)
                    {
                        case SizeType.Personal:
                            break;
                        case SizeType.Small:
                            price += 2;
                            break;
                        case SizeType.Medium:
                            price += 4;
                            break;
                        case SizeType.Large:
                            price += 6;
                            break;
                        case SizeType.ExtraLarge:
                            price += 8;
                            break;
                        case SizeType.Party:
                            price += 10;
                            break;
                        default:
                            break;
                    }

                    pizza = new GreekPizza(toppingsFactory, sizeFactory)
                    {
                        name = "California Style Greek Pizza",
                        cost = price + toppingsFactory.ExtraToppings.Count
                    };
                }
                else if (pizzaType.GetType() == typeof(HawaiianPizza))
                {
                    //Add stardard toppings
                    toppingsFactory.StandardToppings.Add(toppingsFactory.ingredientFactory.CreateHam());
                    List<Fruit>? fruitList = toppingsFactory.ingredientFactory.CreateFruitList();
                    foreach (var fruit in fruitList)
                    {
                        toppingsFactory.StandardToppings.Add(fruit);
                    }

                    toppingsFactory.MakeBase();
                    toppingsFactory.AddStandardToppings();
                    if (toppingsFactory.ExtraToppings.Count > 0)
                    {
                        toppingsFactory.AddExtraToppings();
                    }
                    toppingsFactory.AddCheese();

                    int price = 10;
                    switch (sizeFactory.PizzaSize)
                    {
                        case SizeType.Personal:
                            break;
                        case SizeType.Small:
                            price += 2;
                            break;
                        case SizeType.Medium:
                            price += 4;
                            break;
                        case SizeType.Large:
                            price += 6;
                            break;
                        case SizeType.ExtraLarge:
                            price += 8;
                            break;
                        case SizeType.Party:
                            price += 10;
                            break;
                        default:
                            break;
                    }

                    pizza = new HawaiianPizza(toppingsFactory, sizeFactory)
                    {
                        name = "California Style Hawaiian Pizza",
                        cost = price + toppingsFactory.ExtraToppings.Count
                    };
                }
                else //base pizza
                {
                    toppingsFactory.MakeBase();
                    toppingsFactory.AddStandardToppings();
                    if (toppingsFactory.ExtraToppings.Count > 0)
                    {
                        toppingsFactory.AddExtraToppings();
                    }
                    toppingsFactory.AddCheese();

                    int price = 7;
                    switch (sizeFactory.PizzaSize)
                    {
                        case SizeType.Personal:
                            break;
                        case SizeType.Small:
                            price += 2;
                            break;
                        case SizeType.Medium:
                            price += 4;
                            break;
                        case SizeType.Large:
                            price += 6;
                            break;
                        case SizeType.ExtraLarge:
                            price += 8;
                            break;
                        case SizeType.Party:
                            price += 10;
                            break;
                        default:
                            break;
                    }

                    pizza = new CheesePizza(toppingsFactory, sizeFactory)
                    {
                        name = "California Style Cheese Pizza",
                        cost = price + toppingsFactory.ExtraToppings.Count
                    };
                }
                pizza.style = "California Style";
                return pizza;
            }
            else
            {
                //ingredients are unavailable
                return new CheesePizza();
            }
        }
    }
}
