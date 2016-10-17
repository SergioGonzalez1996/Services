using Services.Cells;
using Services.Classes;
using System;
using System.Linq;

using Xamarin.Forms;

namespace Services.Pages
{
    public partial class ProductsPage : ContentPage
    {
        public ProductsPage()
        {
            InitializeComponent();

            productsListView.ItemTemplate = new DataTemplate(typeof(ProductCell));

            addButton.Clicked += AddButton_Clicked;
            productsListView.ItemSelected += ProductsListView_ItemSelected;
        }

        private async void ProductsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new EditProductsPage((Product)e.SelectedItem));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (var da = new DataAccess())
            {
                productsListView.ItemsSource = da.GetList<Product>(false).OrderBy(p => p.Description);
            }
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(descriptionEntry.Text))
            {
                await DisplayAlert("Error", "You must enter a description", "Accept");
                return;
            }

            if (string.IsNullOrEmpty(priceEntry.Text))
            {
                await DisplayAlert("Error", "You must enter a price", "Accept");
                return;
            }

            var price = decimal.Parse(priceEntry.Text);
            if (price < 0)
            {
                await DisplayAlert("Error", "The price must be a value greather or equals to zero", "Accept");
                return;
            }

            var product = new Product
            {
                Description = descriptionEntry.Text,
                Price = price,
            };

            using (var da = new DataAccess())
            {
                da.Insert(product);
                productsListView.ItemsSource = da.GetList<Product>(false).OrderBy(p => p.Description);
            }

            descriptionEntry.Text = string.Empty;
            priceEntry.Text = string.Empty;
            await DisplayAlert("Message", "The product was added successfully", "Accept");
        }
    }
}
