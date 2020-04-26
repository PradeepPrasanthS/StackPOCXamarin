using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StackPOC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewDemo : ContentPage
    {
        public ListViewDemo()
        {
            InitializeComponent();
            List<Object> dataSource = new List<Object>
            {
                new Person("Abigail", new DateTime(1975, 1, 15), Color.Aqua),
                new Person("Bob", new DateTime(1976, 2, 20), Color.Black),
                new Person("Yvonne", new DateTime(1987, 1, 10), Color.Purple),
                new Person("Zachary", new DateTime(1988, 2, 5), Color.Red),
                new Person("Abigail", new DateTime(1975, 1, 15), Color.Aqua),
                new Person("Bob", new DateTime(1976, 2, 20), Color.Black),
                new Person("Yvonne", new DateTime(1987, 1, 10), Color.Purple),
                new Car("Nano", "Tata", Color.Aqua),
                new Car("Alto", "Maruthi", Color.Black),
                new Car("Yvonne", "Audi", Color.Purple)
            };

            listView.ItemTemplate = new DataTemplate(() =>
            {
                // Create views with bindings for displaying each property.
                Label nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");

                Label birthdayLabel = new Label();
                birthdayLabel.SetBinding(Label.TextProperty,
                    new Binding("Birthday", BindingMode.OneWay,
                        null, null, "Born {0:d}"));

                BoxView boxView = new BoxView();
                boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");

                // Return an assembled ViewCell.
                return new StackLayout
                    {
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Horizontal,
                        Children =
                                {
                                    boxView,
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.Center,
                                        Spacing = 0,
                                        Children =
                                        {
                                            nameLabel,
                                            birthdayLabel
                                        }
                                        }
                                }
           
                };
            });

            listView.ItemsSource = dataSource;

        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            throw new NotImplementedException();
        }

        class Person
        {
            public Person(string name, DateTime birthday, Color favoriteColor)
            {
                this.Name = name;
                this.Birthday = birthday;
                this.FavoriteColor = favoriteColor;
              
            }

            public string Name { private set; get; }

            public DateTime Birthday { private set; get; }

            public Color FavoriteColor { private set; get; }
        };

        class Car
        {
            public Car(string name, string manufacturer, Color favoriteColor)
            {
                this.Name = name;
                this.Manufacturer = manufacturer;
                this.FavoriteColor = favoriteColor;
            }

            public string Name { private set; get; }

            public string Manufacturer { private set; get; }

            public Color FavoriteColor { private set; get; }
        };
    }

}