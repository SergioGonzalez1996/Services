using System;

using Xamarin.Forms;

namespace Services.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            productsButton.Clicked += ProductsButton_Clicked;
            serviesButton.Clicked += ServiesButton_Clicked;
            queriesButton.Clicked += QueriesButton_Clicked;
        }

        private async void QueriesButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QueriesPage());
        }

        private async void ServiesButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServicesPage());
        }

        private async void ProductsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductsPage());
        }
    }
}
