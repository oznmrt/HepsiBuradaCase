using HP.BACKEND.BUSINESS.Concrete;
using HP.BACKEND.ENTITIES.Concrete.Response;
using HP.BACKEND.REPOSITORY.Abstract;
using HP.BACKEND.REPOSITORY.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ColorService>();
builder.Services.AddScoped<BrandService>();

builder.Services.AddDbContext<HPCaseDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("HPCaseDB"));
});

var app = builder.Build();
// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var caseDBContext = scope.ServiceProvider.GetRequiredService<HPCaseDBContext>();
    var productService = scope.ServiceProvider.GetRequiredService<ProductService>();
    var colorService = scope.ServiceProvider.GetRequiredService<ColorService>();
    var brandService = scope.ServiceProvider.GetRequiredService<BrandService>();

    caseDBContext.Database.Migrate();

    var colorData = await colorService.GetAll();

    var colorIdList = new List<int>();

    if(!colorData.Any())
    {
        colorIdList.Add(await colorService.Insert(new HP.BACKEND.ENTITIES.Concrete.Color
        {
            Name = "Siyah"
        }));
        colorIdList.Add(await colorService.Insert(new HP.BACKEND.ENTITIES.Concrete.Color
        {
            Name = "Beyaz"
        }));
        colorIdList.Add(await colorService.Insert(new HP.BACKEND.ENTITIES.Concrete.Color
        {
            Name = "Kýrmýzý"
        }));
    }

    var brandData = await brandService.GetAll();

    var brandIdList = new List<int>();

    if (!brandData.Any())
    {
        brandIdList.Add(await brandService.Insert(new HP.BACKEND.ENTITIES.Concrete.Brand
        {
            Name = "Xiaomi"
        }));

        brandIdList.Add(await brandService.Insert(new HP.BACKEND.ENTITIES.Concrete.Brand
        {
            Name = "Apple"
        }));

        brandIdList.Add(await brandService.Insert(new HP.BACKEND.ENTITIES.Concrete.Brand
        {
            Name = "Samsung"
        }));
    }

    var productData = await productService.GetAll();

    if (!productData.Any())
    {
        var random = new Random();
        for (int i = 0; i < 35; i++)
        {
            productService.Insert(new HP.BACKEND.ENTITIES.Concrete.Product
            {
                DiscountRatio = random.Next(10, 100),
                BrandId = random.Next(brandIdList.Min(), brandIdList.Max()),
                ColorId = random.Next(colorIdList.Min(), colorIdList.Max()),
                Name = $"Product {i}",
                Price = random.Next(10, 100),
                ImagePath = "https://productimages.hepsiburada.net/s/49/222-222/10986387243058.jpg"
            }).Wait();
        }
    }
}

app.Run();
