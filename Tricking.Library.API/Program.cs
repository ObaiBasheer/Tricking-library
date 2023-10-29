var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddCors(option => option.AddPolicy(name: "TrickingWebClient",
policy =>
{
    policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}
));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("TrickingWebClient");




app.Run();


