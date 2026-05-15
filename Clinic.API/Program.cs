using Microsoft.EntityFrameworkCore;
using Clinic.API.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình Database
builder.Services.AddDbContext<ClinicContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cấu hình JSON (SỬA LẠI ĐOẠN NÀY)
builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        // 1. Chống lỗi vòng lặp (vòng lặp giữa Doctor - User - Specialty)
        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

        // 2. GIỮ NGUYÊN ĐỊNH DẠNG (Quan trọng: Trả về DoctorID thay vì doctorID)
        opt.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();