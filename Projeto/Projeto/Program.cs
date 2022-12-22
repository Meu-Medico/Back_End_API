var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Data.Contexto.ProjetoContext>();
// Updated upstream
//builder.Services.AddScoped<Data.Interface.IBeneficiarioRepositorio, Data.Repositorio.BeneficiarioRepositorio>();
//builder.Services.AddScoped<Data.Interface.IDadosBancariosRepositorio, Data.Repositorio.RepositorioRepositorio>();

builder.Services.AddScoped<Data.Interface.IHospitalRepositorio,Data.Repositorio.HospitalRepositorio>();
builder.Services.AddScoped<Data.Interface.IProfissionalRepositorio,Data.Repositorio.ProfissionalRepositorio>();
builder.Services.AddScoped<Data.Interface.IEspecialidadeRepositorio,Data.Repositorio.EspecialidadeRepositorio>();
//=======
// Stashed changes

//--------CORS-------------
builder.Services.AddCors(options => {
    options.AddPolicy("MinhaRegraCors",
        policy => {
            policy.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
