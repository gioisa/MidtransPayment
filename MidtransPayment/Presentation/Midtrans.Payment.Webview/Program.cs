using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Midtrans.Payment.Webview.Helpers;

var builder = WebApplication.CreateBuilder(args);


var configuration = new ConfigurationBuilder()
	.SetBasePath(Directory.GetCurrentDirectory())
	.AddJsonFile("appsettings.json")
	.Build();

string _defaultCorsPolicyName = "localhost";
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddRazorRuntimeCompilation();

builder.Services.AddTransient<IRestAPIHelper, RestAPIHelper>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddCors(
				options => options.AddPolicy(
					_defaultCorsPolicyName,
				builder => builder
				.WithOrigins(
							configuration["AllowedHosts"]
						)
						.AllowAnyHeader()
						.AllowAnyMethod()
				)
			);

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
app.UseCors(_defaultCorsPolicyName);
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
