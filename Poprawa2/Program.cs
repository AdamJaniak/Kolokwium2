using Microsoft.EntityFrameworkCore;
using Poprawa2.DAL;
using Poprawa2.Service;

namespace Poprawa2;

public class Program
{
    public static void Main(string[] args)
    {   
        var builder = WebApplication.CreateBuilder(args);
        
        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddDbContext<GalleriesDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddScoped<IGetGallery, GetGallery>();
        builder.Services.AddScoped<IAddExhibition, AddExhibition>();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}