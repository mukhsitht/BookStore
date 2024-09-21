using Api.Infrastructure;
using Utilities.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var appsettingsSection = builder.Configuration.GetSection("appsettings");
        builder.Services.Configure<AppSettingsModel>(appsettingsSection);

        var appSettingsModel = builder.Configuration.Get<AppSettingsModel>() ?? throw new Exception("Error occured");
        builder.Services.AddSingleton(appSettingsModel);

        builder.AddDbContext();
        builder.AddAutoMapper();
        builder.RegisterService();
        builder.AddCors(appSettingsModel);
        builder.AddSwagger();
        builder.Services.AddControllers();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddAuthorization();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors(appSettingsModel.CommonSettings?.CorsPolicyName ?? "");
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}