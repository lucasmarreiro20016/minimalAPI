using AplicacaoMinima;
using Microsoft.EntityFrameworkCore;
using System.Net;

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
        return Results.Ok(await context.TAB_PESSOA.ToListAsync());
    });

    app.MapPost("/Post", async (Pessoa pessoa, PessoaContext context) =>
    {
        try
        {
            context.TAB_PESSOA.Add(pessoa);
            await context.SaveChangesAsync();

            return Results.Ok("Pessoa cadastrada com sucesso!");
        }
        catch
        {
            return Results.BadRequest("Erro ao cadastrar pessoa");
        }
    });

    app.MapDelete("/Delete", async (string cpf, PessoaContext context) =>
    {
        Pessoa pes = await context.TAB_PESSOA.Where(x => x.CPF.Equals(cpf)).SingleOrDefaultAsync();
        if (pes is not null)
        {
            context.TAB_PESSOA.Remove(pes);
            await context.SaveChangesAsync();

            return Results.Ok("Removido com sucesso");
        }else
        {
            return Results.NotFound("CPF não encontrado");
        }
    });

    //app.MapPut("/Put", (Pessoa pessoa) => {
    //    return repositorio.AtualizarPessoas(pessoa);
    //});
}


app.Run();
