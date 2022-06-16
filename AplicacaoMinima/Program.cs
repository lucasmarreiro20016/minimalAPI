using AplicacaoMinima;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PessoaContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")));
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    app.UseSwagger(); // Ativando o Swagger
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });

    app.MapGet("/Get", async  (PessoaContext context) => {
        return await context.TAB_PESSOA.ToListAsync();
    });

    app.MapPost("/Post", async (Pessoa pessoa, PessoaContext context) =>
    {
        context.TAB_PESSOA.Add(pessoa);
        await context.SaveChangesAsync();
    });

    //app.MapDelete("/Delete", (string cpf) => {
    //    return repositorio.RemoverPessoas(cpf);
    //});

    //app.MapPut("/Put", (Pessoa pessoa) => {
    //    return repositorio.AtualizarPessoas(pessoa);
    //});
}


app.Run();
