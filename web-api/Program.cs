var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Define Políticas de CORS.
// Precisa Definir antes do builder.Build() no arquivo Program.cs (.net 8)
builder.Services.AddCors(options => {
    options.AddPolicy("allOriginsCORS", policy => {

        // Libera todas as origens
        policy.SetIsOriginAllowed(origin => true) // allow any origin
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });

    // Libera só o local host
    options.AddPolicy("localhostCORS", policy => {
        policy.WithOrigins("http://127.0.0.1:5501")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });

});





var app = builder.Build();

/*
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

// Habilita a política CORS
// Esse comando deve ser inserido antes do app.Authorization no arquivo program.cs
app.UseCors("allOriginsCORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
