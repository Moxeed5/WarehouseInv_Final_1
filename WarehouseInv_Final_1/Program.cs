using FluentEmail.Core;
using FluentEmail.Smtp;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net.Mail;
using WarehouseInv_Final_1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDbConnection>((s) =>
{
    IDbConnection conn = new MySqlConnection(builder.Configuration.GetConnectionString("warehouseinventory"));
    conn.Open();
    return conn;
});

builder.Services.AddTransient<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


//static async Task Main(string[] args)
//{
    var sender = new SmtpSender(() => new SmtpClient(host: "localhost")
    {
        EnableSsl = false,
        DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
        PickupDirectoryLocation = @"C:\Demos"
    });

    Email.DefaultSender = sender;

    var email = await Email
        .From(emailAddress: "max@maxco.com")
        .To(emailAddress: "test@test.com", name: "Sue")
        .Subject(subject: "Thanks!")
        .Body(body: "Thanks for buying our product.")
        .SendAsync();
//}
