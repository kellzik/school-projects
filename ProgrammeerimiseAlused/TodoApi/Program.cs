using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Fixed the OpenAPI schema for long id parameters so Swagger UI can send them correctly. Originally was: builder.Services.AddOpenApi();
builder.Services.AddOpenApi(options =>
{
    options.AddSchemaTransformer((schema, context, _) =>
    {
        if (context.ParameterDescription?.Name == "id" &&
            context.JsonTypeInfo?.Type == typeof(long))
        {
            schema.Type = Microsoft.OpenApi.JsonSchemaType.Integer;
            schema.AnyOf?.Clear();
            schema.Pattern = null;
        }

        return Task.CompletedTask;
    });
});
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));

// <snippet_UseSwagger>
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}
// </snippet_UseSwagger>

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();