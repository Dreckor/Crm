using Newtonsoft.Json.Serialization;
using CRM.Services;
using CRM;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<CRMContext>(builder.Configuration.GetConnectionString("CrmDatabase"));
builder.Services.AddScoped<ISellersService, SellersService>();
builder.Services.AddScoped<ICustomersService, CustomersService>();
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(
        options => options.SerializerSettings.ReferenceLoopHandling=Newtonsoft
        .Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(
        options => options.SerializerSettings.ContractResolver = new DefaultContractResolver()
        );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader() );
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
