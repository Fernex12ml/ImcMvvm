using Microsoft.Maui.Controls;
using ImcMvvm.ViewModels;

namespace ImcMvvm.Views;

public partial class ImcPage : ContentPage
{
    public ImcPage()
    {
        InitializeComponent();

        BindingContext = new ImcViewModel();
    }
}