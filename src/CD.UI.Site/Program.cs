using CD.UI.Site.Data;
using CD.UI.Site.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

builder.Services.AddDbContext<MeuDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MeuDbContext")));

builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.AreaViewLocationFormats.Clear();
    options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/{1}/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/Shared/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
});

builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();

builder.Services.AddTransient<IOperacaoTransient, Operacao>();
builder.Services.AddScoped<IOperacaoScoped, Operacao>();
builder.Services.AddSingleton<IOperacaoSingleton, Operacao>();
builder.Services.AddSingleton<IOperacaoSingletonInstance>(new Operacao(Guid.Empty));

builder.Services.AddTransient<OperacaoService>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();

//Using default route to all areas
//app.MapControllerRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

//If you want route by area
app.MapAreaControllerRoute("AreaProdutos", "Produtos", "Produtos/{controller=Cadastro}/{action=Index}/{id?}");
app.MapAreaControllerRoute("AreaVendas", "Vendas", "Vendas/{controller=Pedidos}/{action=Index}/{id?}");


app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
