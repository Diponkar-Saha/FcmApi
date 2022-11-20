using CorePush.Google;
using FcmApi.Model;
using FcmApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Install-Package CorePush
//Install-Package Newtonsoft.Json
//Install-Package Swashbuckle.AspNetCore

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();



builder.Services.AddTransient<INotificationService, NotificationService>();
builder.Services.AddHttpClient<FcmSender>();
var appSettingsSection = builder.Configuration.GetSection("FcmNotification");
builder.Services.Configure<FcmNotificationSetting>(appSettingsSection);




builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
