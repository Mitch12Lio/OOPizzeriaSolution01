using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OOPizzeriaLib04
{
    public abstract class Pizza
    {
        public string? name;
        public string? style;
        public int? cost = 0;
        public string? description;
        public IPizzaTopping? topping;
        public Dough? dough;
        public Sauce? sauce;
        public Cheese? cheese;
        public List<Vegetables>? vegetarianList;
        public Pepperoni? pepperoni;
        public Clam? clam;
        public Ham? ham;
        public List<Fruit>? fruitList;
        public Bacon? bacon;
        public List<string> extras = [];

        public PizzaSizeFactory? size;

        public ICutShape? cutShape;

        public ObservableCollection<string> pizzaSteps = [];
        public int pizzaStepsCount = 0;
        public virtual string Display { get; set; } = "No pizza yet";
        public virtual string ShortName { get; set; } = "No pizza yet";
        public virtual string BakingInstruction { get; set; } = "Baking for 25 at 350...";


        public PizzaPreparationFactory? preparationFactory;
        public PizzaSizeFactory? sizeFactory;
        public Pizza(PizzaPreparationFactory preparationFactory, PizzaSizeFactory sizeFactory)
        {
            this.sizeFactory = sizeFactory;
            this.preparationFactory = preparationFactory;
        }

        public Pizza()
        {

        }

        public async virtual Task Prepare()
        {
            if ((sizeFactory != null) && (preparationFactory != null))
            {
                pizzaStepsCount++;
                pizzaSteps.Add($"{pizzaStepsCount}. Preparing a {sizeFactory.PizzaSize} {name} [${cost}]");
                await Task.Delay(500);
            }
        }

        public async virtual Task Bake(string bakingInstructions)
        {
            pizzaStepsCount++;
            pizzaSteps.Add($"{pizzaStepsCount}. {bakingInstructions}");
            await Task.Delay(500);
        }

        public async virtual Task Cut()
        {
            if (sizeFactory != null)
            {
                pizzaStepsCount++;
                cutShape = sizeFactory.Cut();
                pizzaSteps.Add($"{pizzaStepsCount}. {cutShape.Name}");
                await Task.Delay(500);
            }
        }

        public async virtual Task Box()
        {
            pizzaStepsCount++;
            pizzaSteps.Add($"{pizzaStepsCount}. Placing pizza in official {style} box...");
            await Task.Delay(500);
        }

        public async virtual Task Deliver()
        {
            pizzaStepsCount++;
            pizzaSteps.Add($"{pizzaStepsCount}. Delivered");
            await Task.Delay(500);
        }
    }

    public class CheesePizza : Pizza
    {
        public CheesePizza(PizzaPreparationFactory preperationFactory, PizzaSizeFactory sizeFactory) : base(preperationFactory, sizeFactory) { }
        public CheesePizza() { ShortName = "Cheese"; }
        public override string Display { get; set; } = "One cheese pizza coming up!";
        public override string BakingInstruction { get; set; } = "Baking for 20 at 400...";

        public async override Task Prepare()
        {
            await base.Prepare();

            if (preparationFactory != null)
            {
                foreach (StepDescriptor description in preparationFactory.PreperationSteps)
                {
                    pizzaStepsCount++;
                    topping = description.pizzaTopping;
                    if (topping != null)
                    {
                        if (description.verb.Equals("extra", StringComparison.CurrentCultureIgnoreCase))
                        {
                            pizzaSteps.Add($"{pizzaStepsCount}. Adding {topping.Name}... ({description.verb})");
                        }
                        else
                        {
                            pizzaSteps.Add($"{pizzaStepsCount}. {description.verb} {topping.Name}...");
                        }
                        await Task.Delay(500);
                    }
                }
            }
            await Bake(BakingInstruction);
            await Cut();
            await Box();
            await Deliver();
        }

        public async override Task Bake(string bakingInstruction)
        {
            await base.Bake(bakingInstruction);
        }

        public async override Task Cut()
        {
            await base.Cut();
        }

        public async override Task Box()
        {
            await base.Box();
        }

        public async override Task Deliver()
        {
            await base.Deliver();
        }
    }

    public class PepperoniPizza : Pizza
    {
        public PepperoniPizza(PizzaPreparationFactory preperationFactory, PizzaSizeFactory sizeFactory) : base(preperationFactory, sizeFactory) { }
        public PepperoniPizza() { ShortName = "Pepperoni"; }

        public override string Display { get; set; } = "One pepperoni pizza coming up!";

        public async override Task Prepare()
        {
            await base.Prepare();
            if (preparationFactory != null)
            {
                foreach (StepDescriptor descriptor in preparationFactory.PreperationSteps)
                {
                    pizzaStepsCount++;
                    topping = descriptor.pizzaTopping;
                    if (topping != null)
                    {
                        if (descriptor.verb.Equals("extra", StringComparison.CurrentCultureIgnoreCase))
                        {
                            pizzaSteps.Add($"{pizzaStepsCount}. Adding {topping.Name}... ({descriptor.verb})");
                        }
                        else
                        {
                            pizzaSteps.Add($"{pizzaStepsCount}. {descriptor.verb} {topping.Name}...");
                        }
                        await Task.Delay(500);
                    }
                }
            }
            await Bake(BakingInstruction);
            await Cut();
            await Box();
            await Deliver();
        }

        public async override Task Bake(string bakingInstruction)
        {
            await base.Bake(bakingInstruction);
        }

        public async override Task Cut()
        {
            await base.Cut();
        }

        public async override Task Box()
        {
            await base.Box();
        }

        public async override Task Deliver()
        {
            await base.Deliver();
        }
    }

    public class VegetarianPizza : Pizza
    {
        public VegetarianPizza(PizzaPreparationFactory preperationFactory, PizzaSizeFactory sizeFactory) : base(preperationFactory, sizeFactory) { }
        public VegetarianPizza() { ShortName = "Vegetarian"; }
        public override string Display { get; set; } = "One vegetarian pizza coming up!";

        public async override Task Prepare()
        {
            await base.Prepare();

            if (preparationFactory != null)
            {
                foreach (StepDescriptor description in preparationFactory.PreperationSteps)
                {
                    pizzaStepsCount++;
                    topping = description.pizzaTopping;
                    if (topping != null)
                    {
                        if (description.verb.Equals("extra", StringComparison.CurrentCultureIgnoreCase))
                        {
                            pizzaSteps.Add($"{pizzaStepsCount}. Adding {topping.Name}... ({description.verb})");
                        }
                        else
                        {
                            pizzaSteps.Add($"{pizzaStepsCount}. {description.verb} {topping.Name}...");
                        }
                        await Task.Delay(500);
                    }
                }
            }

            await Bake(BakingInstruction);
            await Cut();
            await Box();
            await Deliver();
        }

        public async override Task Bake(string bakingInstruction)
        {
            await base.Bake(bakingInstruction);
        }

        public async override Task Cut()
        {
            await base.Cut();
        }

        public async override Task Box()
        {
            await base.Box();
        }

        public async override Task Deliver()
        {
            await base.Deliver();
        }
    }

    public class ClamPizza : Pizza
    {
        public ClamPizza(PizzaPreparationFactory preperationFactory, PizzaSizeFactory sizeFactory) : base(preperationFactory, sizeFactory) { }
        public ClamPizza() { ShortName = "Clam"; }
        public override string Display { get; set; } = "One clam pizza coming up!";

        public async override Task Prepare()
        {
            await base.Prepare();

            if (preparationFactory != null)
            {
                foreach (StepDescriptor description in preparationFactory.PreperationSteps)
                {
                    pizzaStepsCount++;
                    topping = description.pizzaTopping;
                    if (topping != null)
                    {
                        if (description.verb.Equals("extra", StringComparison.CurrentCultureIgnoreCase))
                        {
                            pizzaSteps.Add($"{pizzaStepsCount}. Adding {topping.Name}... ({description.verb})");
                        }
                        else
                        {
                            pizzaSteps.Add($"{pizzaStepsCount}. {description.verb} {topping.Name}...");
                        }
                        await Task.Delay(500);
                    }
                }
            }
            await Bake(BakingInstruction);
            await Cut();
            await Box();
            await Deliver();
        }

        public async override Task Bake(string bakingInstruction)
        {
            await base.Bake(bakingInstruction);
        }

        public async override Task Cut()
        {
            await base.Cut();
        }

        public async override Task Box()
        {
            await base.Box();
        }

        public async override Task Deliver()
        {
            await base.Deliver();
        }
    }

    public class GreekPizza : Pizza
    {
        public GreekPizza(PizzaPreparationFactory preperationFactory, PizzaSizeFactory sizeFactory) : base(preperationFactory, sizeFactory) { }
        public GreekPizza() { ShortName = "Greek"; }
        public override string Display { get; set; } = "One greek pizza coming up!";

        public async override Task Prepare()
        {
            await base.Prepare();
            if (preparationFactory != null)
            {
                foreach (StepDescriptor description in preparationFactory.PreperationSteps)
                {
                    pizzaStepsCount++;
                    topping = description.pizzaTopping;
                    if (topping != null)
                    {
                        if (description.verb.Equals("extra", StringComparison.CurrentCultureIgnoreCase))
                        {
                            pizzaSteps.Add($"{pizzaStepsCount}. Adding {topping.Name}... ({description.verb})");
                        }
                        else
                        {
                            pizzaSteps.Add($"{pizzaStepsCount}. {description.verb} {topping.Name}...");
                        }
                        await Task.Delay(500);
                    }
                }
            }
            await Bake(BakingInstruction);
            await Cut();
            await Box();
            await Deliver();
        }

        public async override Task Bake(string bakingInstruction)
        {
            await base.Bake(bakingInstruction);
        }

        public async override Task Cut()
        {
            await base.Cut();
        }

        public async override Task Box()
        {
            await base.Box();
        }

        public async override Task Deliver()
        {
            await base.Deliver();
        }
    }

    public class HawaiianPizza : Pizza
    {
        public HawaiianPizza(PizzaPreparationFactory preperationFactory, PizzaSizeFactory sizeFactory) : base(preperationFactory, sizeFactory) { }
        public HawaiianPizza() { ShortName = "Hawaiian"; }
        public override string Display { get; set; } = "One hawaiian pizza coming up!";

        public async override Task Prepare()
        {
            await base.Prepare();
            if (preparationFactory != null)
            {
                foreach (StepDescriptor description in preparationFactory.PreperationSteps)
                {
                    pizzaStepsCount++;
                    topping = description.pizzaTopping;
                    if (topping != null)
                    {
                        if (description.verb.Equals("extra", StringComparison.CurrentCultureIgnoreCase))
                        {
                            pizzaSteps.Add($"{pizzaStepsCount}. Adding {topping.Name}... ({description.verb})");
                        }
                        else
                        {
                            pizzaSteps.Add($"{pizzaStepsCount}. {description.verb} {topping.Name}...");
                        }
                        await Task.Delay(500);
                    }
                }
            }
            await Bake(BakingInstruction);
            await Cut();
            await Box();
            await Deliver();
        }

        public async override Task Bake(string bakingInstruction)
        {
            await base.Bake(bakingInstruction);
        }

        public async override Task Cut()
        {
            await base.Cut();
        }

        public async override Task Box()
        {
            await base.Box();
        }

        public async override Task Deliver()
        {
            await base.Deliver();
        }
    }

    //public class MargheritaPizza : Pizza
    //{
    //    public MargheritaPizza(PizzaIngredientFactory ingredientFactory, PizzaSizeFactory sizeFactory) : base(ingredientFactory, sizeFactory) { }
    //    public MargheritaPizza() { shortName = "Margherita"; }
    //    public override string display { get; set; } = "One margherita pizza coming up!";

    //    public async override Task Prepare()
    //    {
    //        await base.Prepare();
    //        if (ingredientFactory != null)
    //        {
    //            vegetarianList = ingredientFactory.CreateVegetarianList();
    //            vegetarianList.Add(new BlackOlives());

    //            foreach (var veg in vegetarianList)
    //            {
    //                pizzaStepsCount++;
    //                pizzaSteps.Add($"{pizzaStepsCount}. Adding {veg.name}...");
    //                await Task.Delay(500);
    //            }
    //        }
    //        await Bake(bakingInstruction);
    //        await Cut();
    //        await Box();
    //        await Deliver();
    //    }

    //    public async override Task Bake(string bakingInstruction)
    //    {
    //        await base.Bake(bakingInstruction);
    //    }

    //    public async override Task Cut()
    //    {
    //        await base.Cut();
    //    }

    //    public async override Task Box()
    //    {
    //        await base.Box();
    //    }

    //    public async override Task Deliver()
    //    {
    //        await base.Deliver();
    //    }
    //}

    public class ForbiddenPizza : Pizza
    {
        public ForbiddenPizza(PizzaPreparationFactory preperationFactory, PizzaSizeFactory sizeFactory) : base(preperationFactory, sizeFactory) { }
        public ForbiddenPizza() { ShortName = "Forbidden"; }
        public override string Display { get; set; } = "Hawaiian Pizza is forbidden in Chicago!";

        public async override Task Prepare()
        {
            pizzaStepsCount++;
            pizzaSteps.Add("Hawaiian Pizza is forbidden in Chicago!");
            await Task.Delay(500);

            pizzaStepsCount++;
            pizzaSteps.Add("Try New York!");
            await Task.Delay(500);
        }
    }
}
