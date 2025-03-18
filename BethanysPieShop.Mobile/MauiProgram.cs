using BethanysPieShop.Mobile.Repositories;
using BethanysPieShop.Mobile.Repositories.Interfaces;
using BethanysPieShop.Mobile.Services;
using BethanysPieShop.Mobile.Services.Interfaces;
using BethanysPieShop.Mobile.ViewModels;
using BethanysPieShop.Mobile.Views;
using Microsoft.Extensions.Logging;

namespace BethanysPieShop.Mobile;

public static class MauiProgram
{
    public static string BethanysPieShopApiClient = "BethanysPieShopApiClient";
    public static string BaseAddress = "http://localhost:5000";
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcon");
            })
            .RegisterServices()
            .RegisterRepositories()
            .RegisterViewModels()
            .RegisterViews();
        
        Routing.RegisterRoute("PieDetail", typeof(PieDetailPage));
        Routing.RegisterRoute("Checkout", typeof(CheckOutPage));
        Routing.RegisterRoute("OrderHistory", typeof(OrderHistoryPage));
        Routing.RegisterRoute("OrderDetail", typeof(OrderDetailPage));

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
    
    private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        
        builder.Services.AddTransient<IAuthService, AuthService>();
        builder.Services.AddTransient<ICategoryService, CategoryService>();
        builder.Services.AddTransient<IOrderService, OrderService>();
        builder.Services.AddTransient<IPieService, PieService>();
        builder.Services.AddSingleton<IShoppingCartService, ShoppingCartService>();


        //builder.Services.AddHttpClient("BethanysPieShopApiClient",
        builder.Services.AddHttpClient<IPieRepository>(BethanysPieShopApiClient,
            client =>
            {
                client.BaseAddress = new Uri(BaseAddress);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

        builder.Services.AddTransient<IPieRepository, PieRepository>();

        return builder;
    }
    
    private static MauiAppBuilder RegisterRepositories(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<IAuthRepository, AuthMockRepository>();
        builder.Services.AddTransient<ICategoryRepository, CategoryMockRepository>();
        builder.Services.AddTransient<IOrderRepository, OrderMockRepository>();
        builder.Services.AddTransient<IPieRepository, PieMockRepository>();
        builder.Services.AddTransient<IShoppingCartRepository, ShoppingCartMockRepository>();

        return builder;
    }

    private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<CheckoutViewModel>();
        builder.Services.AddSingleton<HomePageViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<PieDetailViewModel>();
        builder.Services.AddSingleton<PiesOverviewViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();
        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddSingleton<ShoppingCartViewModel>();
        builder.Services.AddTransient<OrderOverviewViewModel>();
        builder.Services.AddTransient<OrderDetailViewModel>();

        return builder;
    }

    private static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<CheckOutPage>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<MyAccountPage>();
        builder.Services.AddTransient<PieDetailPage>();
        builder.Services.AddSingleton<PiesOverviewPage>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddSingleton<ShoppingCartPage>();
        builder.Services.AddTransient<OrderHistoryPage>();
        builder.Services.AddTransient<OrderDetailPage>();

        return builder;
    }
}