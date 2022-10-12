using DBMS_WebApI.CQRS.Rows.Queries.GetAllRows;
using DBMS_WebApI.Infrastructure.Data.Extensions;
using MediatR;
using System.Reflection;
using DBMS_WebApI.Infrastructure.Mapper;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

await builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddMediatR(typeof(GetRows).GetTypeInfo().Assembly);
builder.Services.AddAutoMapper(typeof(DBMSMappingProfile));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
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
