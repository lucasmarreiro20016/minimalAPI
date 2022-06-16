using AplicacaoMinima;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var repositorio = new RepositorioDePessoas(true);

app.UseSwagger(); // Ativando o Swagger
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.MapGet("/Get", () => {
    return repositorio.SelecionarPessoas();
});

app.MapPost("/Post", (Pessoa pessoa) => {
    return repositorio.AdicionarPessoas(pessoa);
});

app.MapDelete("/Delete", (string cpf) => {
    return repositorio.RemoverPessoas(cpf);
});

app.MapPut("/Put", (Pessoa pessoa) => {
    return repositorio.AtualizarPessoas(pessoa);
});


app.Run();
