using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BethanysPieShop.Mobile.ViewModels;
using BethanysPieShop.Mobile.Views.Base;

namespace BethanysPieShop.Mobile.Views;

public partial class RegisterPage
{
    public RegisterPage(RegisterViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}