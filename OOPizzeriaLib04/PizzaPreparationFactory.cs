using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OOPizzeriaLib04;

namespace OOPizzeriaLib04
{
    public class StepDescriptor
    {
        public string verb = string.Empty;
        public IPizzaTopping? pizzaTopping = null;
    }
    public abstract class PizzaPreparationFactory
    {
        public IPizzaIngredientFactory? ingredientFactory;
        public List<IPizzaTopping> ExtraToppings { get; set; } = [];
        public List<IPizzaTopping> StandardToppings { get; set; } = [];

        public List<StepDescriptor> PreperationSteps { get; set; } = [];

        public StepDescriptor? cheeseDescriptor = null;

        public PizzaPreparationFactory()
        {

        }

        public void AddExtraTopping(IPizzaTopping extraTopping)
        {
            ExtraToppings.Add(extraTopping);
        }

        public void AddStandardTopping(IPizzaTopping standardTopping)
        {
            StandardToppings.Add(standardTopping);
        }

        public virtual void MakeBase()
        {
            if (ingredientFactory != null)
            {
                PreperationSteps.Add(new OOPizzeriaLib04.StepDescriptor { pizzaTopping = ingredientFactory.CreateDough(), verb = "Tossing" });
                PreperationSteps.Add(new OOPizzeriaLib04.StepDescriptor { pizzaTopping = ingredientFactory.CreateSauce(), verb = "Adding" });
            }
        }

        public virtual void AddCheese()
        {
            if (ingredientFactory != null)
            {
                PreperationSteps.Add(new OOPizzeriaLib04.StepDescriptor { pizzaTopping = ingredientFactory.CreateCheese(), verb = "Adding" });
                if (cheeseDescriptor != null)
                {
                    PreperationSteps.Add(cheeseDescriptor);
                }
            }
        }

        public abstract void AddStandardToppings();

        public abstract void AddExtraToppings();


    }
    public class NYPizzaPreperation : PizzaPreparationFactory
    {
        public NYPizzaPreperation(IPizzaIngredientFactory ingredientFactory)
        {
            this.ingredientFactory = ingredientFactory;
        }

        public override void AddStandardToppings()
        {
            foreach (IPizzaTopping top in StandardToppings)
            {
                PreperationSteps.Add(new OOPizzeriaLib04.StepDescriptor { pizzaTopping = top, verb = "Adding" });
            }
        }

        public override void AddExtraToppings()
        {
            //In NEW YORK, we put the cheese OVER the toppings!
            foreach (IPizzaTopping top in ExtraToppings)
            {
                if (top.GetType().BaseType == typeof(Cheese))
                {
                    cheeseDescriptor = new OOPizzeriaLib04.StepDescriptor { pizzaTopping = top, verb = "Extra" };
                }
                else
                {
                    PreperationSteps.Add(new OOPizzeriaLib04.StepDescriptor { pizzaTopping = top, verb = "Extra" });
                }
            }
        }
    }

    public class ChicagoPizzaPreperation : PizzaPreparationFactory
    {
        public ChicagoPizzaPreperation(IPizzaIngredientFactory ingredientFactory)
        {
            this.ingredientFactory = ingredientFactory;
        }

        public override void AddStandardToppings()
        {
            foreach (IPizzaTopping top in StandardToppings)
            {
                PreperationSteps.Add(new OOPizzeriaLib04.StepDescriptor { pizzaTopping = top, verb = "Adding" });
            }
        }

        public override void AddExtraToppings()
        {
            //In CHICAGO, we put the cheese UNDER the toppings!
            IPizzaTopping? extraCheese = ExtraToppings.FirstOrDefault(x => x.GetType().BaseType == typeof(Cheese));
            if (extraCheese != null)
            {
                //Set extra cheese ingredient aside until after we've put all the ingredients
                PreperationSteps.Add(new OOPizzeriaLib04.StepDescriptor { pizzaTopping = extraCheese, verb = "Extra" });
                ExtraToppings.Remove(extraCheese);
            }
            foreach (IPizzaTopping top in ExtraToppings)
            {
                PreperationSteps.Add(new OOPizzeriaLib04.StepDescriptor { pizzaTopping = top, verb = "Extra" });
            }
        }
    }

    public class CaliforniaPizzaPreperation : PizzaPreparationFactory
    {
        public CaliforniaPizzaPreperation(IPizzaIngredientFactory ingredientFactory)
        {
            this.ingredientFactory = ingredientFactory;
        }

        public override void AddStandardToppings()
        {
            foreach (IPizzaTopping top in StandardToppings)
            {
                PreperationSteps.Add(new OOPizzeriaLib04.StepDescriptor { pizzaTopping = top, verb = "Adding" });
            }
        }

        public override void AddExtraToppings()
        {
            //In California, we put the cheese OVER the toppings!
            foreach (IPizzaTopping top in ExtraToppings)
            {
                if (top.GetType().BaseType == typeof(Cheese))
                {
                    cheeseDescriptor = new OOPizzeriaLib04.StepDescriptor { pizzaTopping = top, verb = "Extra" };
                }
                else
                {
                    PreperationSteps.Add(new OOPizzeriaLib04.StepDescriptor { pizzaTopping = top, verb = "Extra" });
                }
            }
        }
    }
}
