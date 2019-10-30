using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpandableListTest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            itemLists.ItemsSource = GetItems();
        }

        private List<MyItems> GetItems()
        {
            return new List<MyItems>()
            {
                new MyItems{ Item1 = "Sweet Potato", Item2 = "$12.99" },
                new MyItems{ Item1 = "Vegetables", Item2 = "$5.99" },
                new MyItems{ Item1 = "Dairy Milk", Item2 = "$45.10" },
                new MyItems{ Item1 = "Green Tea", Item2 = "$10.99" },
            };
        }

        private async void ItemSelected(object sender, EventArgs e)
        {
            Grid grid = sender as Grid;
            Grid menuView = grid.FindByName("inVisibleGrid") as Grid;
            Image arrowImg = grid.FindByName("ArrowImg") as Image;

            if (menuView.IsVisible) await arrowImg?.RelRotateTo(180);
            else await arrowImg?.RelRotateTo(-180);

            menuView.IsVisible = !menuView.IsVisible;
        }
    }

    public class MyItems
    {
        public string Item1 { get; set; }
        public string Item2 { get; set; }
    }
}
