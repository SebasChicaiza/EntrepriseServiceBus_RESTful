var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null; // ? FORZA el respeto del nombre original
    options.JsonSerializerOptions.DictionaryKeyPolicy = null;  // ? igual para claves de diccionario si usas alguno
});

builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseHttpsRedirection();

app.UseCors("PermitirTodo");
app.MapControllers();
app.UseSwagger(); app.UseSwaggerUI();


app.MapGet("/", () => "Hello World!");

app.Run();