using System.Text;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using MangoFusion_API.Data;
using Microsoft.AspNetCore.Identity;
using MangoFusion_API.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();
builder.Services.AddControllers();
builder.Services.AddOpenApi(options =>
{
	options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
});

var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");
builder.Services.AddAuthentication(configureOptions =>
{
	configureOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	configureOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwtBearerOptions =>
{
	jwtBearerOptions.RequireHttpsMetadata = false;
	jwtBearerOptions.SaveToken = true;
	jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		ValidateIssuer = false,
		ValidateAudience = false,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
	};
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.MapScalarApiReference();
}

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

internal sealed class BearerSecuritySchemeTransformer(IAuthenticationSchemeProvider authenticationSchemeProvider) : IOpenApiDocumentTransformer
{
	public async Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
	{
		var authenticationSchemes = await authenticationSchemeProvider.GetAllSchemesAsync();
		if (authenticationSchemes.Any(scheme => scheme.Name == JwtBearerDefaults.AuthenticationScheme))
		{
			var requirement = new Dictionary<string, IOpenApiSecurityScheme>
			{
				[JwtBearerDefaults.AuthenticationScheme] = new OpenApiSecurityScheme
				{
					Type = SecuritySchemeType.Http,
					Scheme = "bearer",
					In = ParameterLocation.Header,
					BearerFormat = "JWT",
				}
			};
			document.Components ??= new OpenApiComponents();
			document.Components.SecuritySchemes = requirement;
		}
		document.Info = new OpenApiInfo
		{
			Title = "MangoFusion API",
			Version = "v1",
			Description = "API for MangoFusion Restaurant",
		};
	}
}