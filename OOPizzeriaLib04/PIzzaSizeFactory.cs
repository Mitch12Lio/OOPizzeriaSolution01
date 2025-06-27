using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPizzeriaLib04.Utilities;

namespace OOPizzeriaLib04
{
    public abstract class PizzaSizeFactory
    {
        public abstract string PizzaSize { get; set; }

        public ICutShape? cutShape;
        public abstract ICutShape Cut();
    }

    public class PersonalSize : PizzaSizeFactory
    {
        public override string PizzaSize { get => SizeType.Personal; set => _ = SizeType.Personal; }

        public override ICutShape Cut()
        {
            return new NoCuts();
        }
    }
    public class SmallSize : PizzaSizeFactory
    {
        public override string PizzaSize { get => SizeType.Small; set => _ = SizeType.Small; }

        public override ICutShape Cut()
        {
            return new TriangleCuts();
        }
    }

    public class MediumSize : PizzaSizeFactory
    {
        public override string PizzaSize { get => SizeType.Medium; set => _ = SizeType.Medium; }

        public override ICutShape Cut()
        {
            return new TriangleCuts();
        }
    }
    public class LargeSize : PizzaSizeFactory
    {
        public override string PizzaSize { get => SizeType.Large; set => _ = SizeType.Large; }

        public override ICutShape Cut()
        {
            return new TriangleCuts();
        }
    }
    public class ExtraLarge : PizzaSizeFactory
    {
        public override string PizzaSize { get => SizeType.ExtraLarge; set => _ = SizeType.ExtraLarge; }

        public override ICutShape Cut()
        {
            return new TriangleCuts();
        }
    }
    public class Party : PizzaSizeFactory
    {
        public override string PizzaSize { get => SizeType.Party; set => _ = SizeType.Party; }

        public override ICutShape Cut()
        {
            return new RectangleCuts();
        }
    }
}
