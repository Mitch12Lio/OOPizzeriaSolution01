using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using OOPizzeriaLib04;
using static OOPizzeriaLib04.Utilities;

namespace WPFPizzeria04.ViewModels
{
    public partial class MasterViewModel : ObservableObject
    {
        private string statusMessage = "Ready";
        public string StatusMessage
        {
            get
            {
                return statusMessage;
            }
            set
            {
                if (statusMessage != value)
                {
                    statusMessage = value;
                    OnPropertyChanged(nameof(StatusMessage));
                }
            }
        }

        public MasterViewModel()
        {
            FillPizzaSizes();
            FillPizzaOptions();
        }

        #region Pizza

        [ObservableProperty]
        private bool addBacon = false;

        [ObservableProperty]
        private bool addCheese = false;

        [ObservableProperty]
        private System.Collections.ObjectModel.ObservableCollection<Pizza> pizzaTypes = [];

        [ObservableProperty]
        private string pizzaType = string.Empty;

        [ObservableProperty]
        ObservableCollection<string> steps = [];

        [ObservableProperty]
        private Pizza? currentPizza = null;

        [RelayCommand]
        public void OrderNYPizza()
        {
            if (SelectedPizza != null)
            {
                PizzaStore nyPizzaStore = new NYPizzaStore();
                List<string> extras = [];

                if (AddBacon)
                { extras.Add("Bacon"); }

                if (AddCheese)
                { extras.Add("Cheese"); }

                CurrentPizza = nyPizzaStore.OrderPizza(SelectedPizza, SelectedPizzaSize, extras);
                Steps = CurrentPizza.pizzaSteps;
                StatusMessage = CurrentPizza.Display;
            }
            else { StatusMessage = "Pizza currently not available"; }
        }

        [RelayCommand]
        public void OrderChicagoPizza()
        {
            if (SelectedPizza != null)
            {
                PizzaStore chiPizzaStore = new ChicagoPizzaStore();
                List<string> extras = [];

                if (AddBacon)
                { extras.Add("Bacon"); }

                if (AddCheese)
                { extras.Add("Cheese"); }

                CurrentPizza = chiPizzaStore.OrderPizza(SelectedPizza, SelectedPizzaSize, extras);
                Steps = CurrentPizza.pizzaSteps;
                StatusMessage = CurrentPizza.Display;
            }
            else { StatusMessage = "Pizza currently not available"; }
        }

        [RelayCommand]
        public void OrderCaliforniaPizza()
        {
            if (SelectedPizza != null)
            {
                PizzaStore calPizzaStore = new CaliforniaPizzaStore();
                List<string> extras = [];

                if (AddBacon)
                { extras.Add("Bacon"); }

                if (AddCheese)
                { extras.Add("Cheese"); }

                CurrentPizza = calPizzaStore.OrderPizza(pizzaType: SelectedPizza, pizzaSize: SelectedPizzaSize, extras);
                Steps = CurrentPizza.pizzaSteps;
                StatusMessage = CurrentPizza.Display;
            }
            else { StatusMessage = "Pizza currently not available"; }
        }

        private Pizza? selectedPizza;
        public Pizza? SelectedPizza
        {
            get
            {
                return selectedPizza;
            }
            set
            {
                selectedPizza = value;
                OnPropertyChanged(nameof(SelectedPizza));
            }
        }

        private System.Collections.ObjectModel.ObservableCollection<Pizza> pizzaOptionsLst = [];
        public System.Collections.ObjectModel.ObservableCollection<Pizza> PizzaOptionsLst
        {
            get
            {
                return pizzaOptionsLst;
            }
            set
            {
                pizzaOptionsLst = value;
            }
        }

        public void FillPizzaOptions()
        {
            //make these values enums or structs
            PizzaOptionsLst.Add(new CheesePizza());
            PizzaOptionsLst.Add(new PepperoniPizza());
            PizzaOptionsLst.Add(new GreekPizza());
            PizzaOptionsLst.Add(new VegetarianPizza());
            PizzaOptionsLst.Add(new ClamPizza());
            PizzaOptionsLst.Add(new HawaiianPizza());
            //PizzaOptionsLst.Add(new MargheritaPizza());
            SelectedPizza = PizzaOptionsLst[0];
        }

        private PizzaSize selectedPizzaSize = new();
        public PizzaSize SelectedPizzaSize
        {
            get
            {
                return selectedPizzaSize;
            }
            set
            {
                selectedPizzaSize = value;
                OnPropertyChanged(nameof(SelectedPizzaSize));
            }
        }

        private static System.Collections.ObjectModel.ObservableCollection<PizzaSize> pizzaSizeLst = [];
        public static System.Collections.ObjectModel.ObservableCollection<PizzaSize> PizzaSizeLst
        {
            get
            {
                return pizzaSizeLst;
            }
            set
            {
                pizzaSizeLst = value;
            }
        }

        public void FillPizzaSizes()
        {
            PizzaSizeLst.Add(new PizzaSize { Id = 0, Size = SizeType.Personal });
            PizzaSizeLst.Add(new PizzaSize { Id = 1, Size = SizeType.Small });
            PizzaSizeLst.Add(new PizzaSize { Id = 2, Size = SizeType.Medium });
            PizzaSizeLst.Add(new PizzaSize { Id = 3, Size = SizeType.Large });
            PizzaSizeLst.Add(new PizzaSize { Id = 4, Size = SizeType.ExtraLarge });
            PizzaSizeLst.Add(new PizzaSize { Id = 5, Size = SizeType.Party });
            SelectedPizzaSize = PizzaSizeLst[2];
        }

        #endregion
    }
}
