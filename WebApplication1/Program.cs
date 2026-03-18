using biznis.Interfaces.Repository;
using biznis.Interfaces.Services;
using biznis.Repository;
using biznis.Services;
using ClassLibrary1;
using ClassLibrary1.Entities;
using Common.Enum;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    var adminEmail = "admin@admin.com";

    var adminExists = db.Users.Any(u => u.Email == adminEmail);
    if (!adminExists)
    {
        var admin = new UserEntity
        {
            PublicId = Guid.NewGuid(),
            Name = "Administrator",
            Email = adminEmail,
            Password = "admin",
            Role = RoleEnum.admin
        };

        db.Users.Add(admin);

        var productNameList = new List<string> { "Jedlo pre psov", "Jedlo pre macky", "Jedlo pre skreckov", "Hracka pre psa", "Hracka pre macku", "Koleso na behaie pre skrecka", "Voditko pre psa", "Voda pre rybu", "Klietka pre skrecka" };
        var productInfoList = new List<string>
        {
            "Kvalitne jedlo pre psov vsetkych vekov.",
            "Chutne jedlo pre macky s vysokym obsahom bielkovin.",
            "Vyvazene jedlo pre skreckov s vitamínmi.",
            "Odolna hracka pre psa na hryzanie a aportovanie.",
            "Interaktivna hracka pre macku na zabavu.",
            "Tiche koleso na behaie pre skrecka.",
            "Bezpecne voditko pre psa na prechadzky.",
            "Cista voda pre ryby v akvariu.",
            "Priestranna klietka pre skrecka s hrackami."
        };
        var productCategoriesList = new List<List<int>>
        {
            new() { (int)CategoryEnum.Dogs, (int)CategoryEnum.Food },
            new() { (int)CategoryEnum.Cats, (int)CategoryEnum.Food },
            new() { (int)CategoryEnum.Hamsters, (int)CategoryEnum.Food },
            new() { (int)CategoryEnum.Dogs, (int)CategoryEnum.Toys },
            new() { (int)CategoryEnum.Cats, (int)CategoryEnum.Toys },
            new() { (int)CategoryEnum.Hamsters, (int)CategoryEnum.Toys },
            new() { (int)CategoryEnum.Dogs },
            new() { (int)CategoryEnum.Fish },
            new() { (int)CategoryEnum.Hamsters }
        };
        var productPricesList = new List<float> { 29.99f, 24.99f, 9.99f, 14.99f, 12.99f, 19.99f, 15.99f, 4.99f, 39.99f };
        for (int i = 0; i < productNameList.Count; i++)
        {
            var product = new ProductEntity
            {
                PublicId = Guid.NewGuid(),
                Name = productNameList[i],
                Info = productInfoList[i],
                Categories = productCategoriesList[i],
                Price = productPricesList[i]
            };
            db.Products.Add(product);
        }
        db.SaveChanges();

    }
}

app.Run();
