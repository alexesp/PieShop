using BethanysPieShop.Mobile.Models;
using BethanysPieShop.Mobile.Repositories.Interfaces;

namespace BethanysPieShop.Mobile.Repositories;

public class PieMockRepository : IPieRepository
{
    public Task<PieDetailModel?> GetPieById(int id) 
        => Task.FromResult(_pieList
            .FirstOrDefault(p => p.Id == id));

    public Task<List<PieModel>> GetPiesOfTheWeek()
    {
        var piesOfTheWeek = _pieList
            .Where(p => p.IsPieOfTheWeek)
            .Select(p => p as PieModel)
            .ToList();
        return Task.FromResult(piesOfTheWeek);
    }

    public Task<List<PieModel>> GetAllPies()
    {
        return Task.FromResult(_pieList.Select(p => new PieModel
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            CategoryId = p.Category.Id,
            ImageThumbnailUrl = p.ImageThumbnailUrl
        }).ToList());
    }

    private readonly List<PieDetailModel> _pieList = new()
    {
        new()
        {
            Id = 1,
            Name = "Caramel Popcorn Cheese Cake",
            Price = 22.95M,
            ShortDescription = "The ultimate cheese cake",
            LongDescription =
                "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            Category = new CategoryModel
            {
                Id = 2,
                Label = "Cheese cakes"
            },
            ImageUrl =
                "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/cheesecakes/caramelpopcorncheesecake.jpg",
            IsPieOfTheWeek = true,
            ImageThumbnailUrl =
                "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/cheesecakes/caramelpopcorncheesecakesmall.jpg",
        },
        new()
        {
            Id = 2,
            Name = "Chocolate Cheese Cake",
            Price = 19.95M,
            ShortDescription = "The chocolate lover's dream",
            LongDescription =
                "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            Category = new CategoryModel
            {
                Id = 2,
                Label = "Cheese cakes"
            },
            ImageUrl =
                "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/cheesecakes/chocolatecheesecake.jpg",
            IsPieOfTheWeek = true,
            ImageThumbnailUrl =
                "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/cheesecakes/chocolatecheesecakesmall.jpg",
        },
        new()
        {
            Id = 3,
            Name = "Pistache Cheese Cake",
            Price = 21.95M,
            ShortDescription = "We're going nuts over this one",
            LongDescription =
                "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            Category = new CategoryModel
            {
                Id = 2,
                Label = "Cheese cakes"
            },
            ImageUrl =
                "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/cheesecakes/pistachecheesecake.jpg",
            IsPieOfTheWeek = true,
            ImageThumbnailUrl =
                "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/cheesecakes/pistachecheesecakesmall.jpg",
        },
        new()
        {
            Id = 4,
            Name = "Pecan Pie",
            Price = 21.95M,
            ShortDescription = "More pecan than you can handle!",
            LongDescription =
                "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            Category = new CategoryModel
            {
                Id = 1,
                Label = "Fruit pies"
            },
            ImageUrl =
                "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/fruitpies/pecanpie.jpg",
            IsPieOfTheWeek = false,
            ImageThumbnailUrl =
                "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/fruitpies/pecanpiesmall.jpg",
        },
        new()
        {
            Id = 5,
            Name = "Birthday Pie",
            Price = 29.95M,
            ShortDescription = "A Happy Birthday with this pie!",
            LongDescription =
                "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            Category = new CategoryModel
            {
                Id = 3,
                Label = "Seasonal pies"
            },
            ImageUrl =
                "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/seasonal/birthdaypie.jpg",
            IsPieOfTheWeek = false,
            ImageThumbnailUrl =
                "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/seasonal/birthdaypiesmall.jpg",
        },
        new()
        {
            Id = 6,
            Name = "Apple Pie",
            Price = 12.95M,
            ShortDescription = "Our famous apple pies!",
            LongDescription =
                "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            Category = new CategoryModel
            {
                Id = 1,
                Label = "Fruit pies"
            },
            ImageUrl = "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/fruitpies/applepie.jpg",
            IsPieOfTheWeek = false,
            ImageThumbnailUrl = "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/fruitpies/applepiesmall.jpg",
        },
        new()
        {
            Id = 7,
            Name = "Blueberry Cheese Cake",
            Price = 18.95M,
            ShortDescription = "You'll love it!",
            LongDescription =
                "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            Category = new CategoryModel
            {
                Id = 2,
                Label = "Cheese cakes"
            },
            ImageUrl =
                "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/cheesecakes/blueberrycheesecake.jpg",
            IsPieOfTheWeek = false,
            ImageThumbnailUrl =
                "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/cheesecakes/blueberrycheesecakesmall.jpg",
        },
        new()
        {
            Id = 8,
            Name = "Cheese Cake",
            Price = 18.95M,
            ShortDescription = "Plain cheese cake. Plain pleasure.",
            LongDescription =
                "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            Category = new CategoryModel
            {
                Id = 2,
                Label = "Cheese cakes"
            },
            ImageUrl =
                "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/cheesecakes/cheesecake.jpg",
            IsPieOfTheWeek = false,
            ImageThumbnailUrl =
                "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/cheesecakes/cheesecakesmall.jpg",
        },
        new()
        {
            Id = 9,
            Name = "Cherry Pie",
            Price = 15.95M,
            ShortDescription = "A summer classic!",
            LongDescription =
                "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            Category = new CategoryModel
            {
                Id = 1,
                Label = "Fruit pies"
            },
            ImageUrl = "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/fruitpies/cherrypie.jpg",
            IsPieOfTheWeek = false,
            ImageThumbnailUrl = "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/fruitpies/cherrypiesmall.jpg",
        },
        new()
        {
            Id = 10,
            Name = "Christmas Apple Pie",
            Price = 13.95M,
            ShortDescription = "Happy holidays with this pie!",
            LongDescription =
                "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            Category = new CategoryModel
            {
                Id = 3,
                Label = "Seasonal pies"
            },
            ImageUrl = "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/seasonal/christmasapplepie.jpg",
            IsPieOfTheWeek = false,
            ImageThumbnailUrl =
                "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/seasonal/christmasapplepiesmall.jpg",
        },
        new()
        {
            Id = 11,
            Name = "Cranberry Pie",
            Price = 17.95M,
            ShortDescription = "A Christmas favorite",
            LongDescription =
                "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            Category = new CategoryModel
            {
                Id = 3,
                Label = "Seasonal pies"
            },
            ImageUrl = "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/seasonal/cranberrypie.jpg",
            IsPieOfTheWeek = false,
            ImageThumbnailUrl = "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/seasonal/cranberrypiesmall.jpg",
        },
        new()
        {
            Id = 12,
            Name = "Peach Pie",
            Price = 15.95M,
            ShortDescription = "Sweet as peach",
            LongDescription =
                "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            Category = new CategoryModel
            {
                Id = 1,
                Label = "Fruit pies"
            },
            ImageUrl = "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/fruitpies/peachpie.jpg",
            IsPieOfTheWeek = false,
            ImageThumbnailUrl = "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/fruitpies/peachpiesmall.jpg",
        },
        new()
        {
            Id = 13,
            Name = "Pumpkin Pie",
            Price = 12.95M,
            ShortDescription = "Our Halloween favorite",
            LongDescription =
                "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            Category = new CategoryModel
            {
                Id = 3,
                Label = "Seasonal pies"
            },
            ImageUrl = "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/seasonal/pumpkinpie.jpg",
            IsPieOfTheWeek = false,
            ImageThumbnailUrl = "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/seasonal/pumpkinpiesmall.jpg",
        },
        new()
        {
            Id = 14,
            Name = "Rhubarb Pie",
            Price = 15.95M,
            ShortDescription = "My God, so sweet!",
            LongDescription =
                "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            Category = new CategoryModel
            {
                Id = 1,
                Label = "Fruit pies"
            },
            ImageUrl = "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/fruitpies/rhubarbpie.jpg",
            IsPieOfTheWeek = false,
            ImageThumbnailUrl = "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/fruitpies/rhubarbpiesmall.jpg",
        },
        new()
        {
            Id = 15,
            Name = "Strawberry Pie",
            Price = 15.95M,
            ShortDescription = "Our delicious strawberry pie!",
            LongDescription =
                "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            Category = new CategoryModel
            {
                Id = 1,
                Label = "Fruit pies"
            },
            ImageUrl = "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/fruitpies/strawberrypie.jpg",
            IsPieOfTheWeek = false,
            ImageThumbnailUrl = "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/fruitpies/strawberrypiesmall.jpg",
        },
        new()
        {
            Id = 16,
            Name = "Strawberry Cheese Cake",
            Price = 18.95M,
            ShortDescription = "You'll love it!",
            LongDescription =
                "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            Category = new CategoryModel
            {
                Id = 2,
                Label = "Cheese cakes"
            },
            ImageUrl = "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/cheesecakes/strawberrycheesecake.jpg",
            IsPieOfTheWeek = false,
            ImageThumbnailUrl =
                "https://lindseybroospluralsight.blob.core.windows.net/bethanyspieshop/cheesecakes/strawberrycheesecakesmall.jpg",
        }
    };
}