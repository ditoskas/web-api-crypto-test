using AutoMapper;
using BlockCypherSeeder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Contracts;

/**
 * This application is consuming the BlockCypher API to seed the database with the latest blocks of a given crypto network.
 * The application accepts 4 parameters:
 * 1. The symbol of the crypto network to seed. Default is BTC.
 * 2. The network of the crypto network to seed. Default is main.
 * 3. The number of records to read. Default is 100.
 * 4. The action to perform (seed or update). Default is seed.
 * 
 * Location of database is in the LocalApplicationData folder.
 */

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
string DbPath = System.IO.Path.Join(path, "cryptos.db");

// Add services to the container.
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqliteContext($"Data Source={DbPath}");
builder.Services.AddAutoMapper(typeof(Program));

// Parse parameters
string crypto = args.Length > 0 ? args[0] : "BTC";
string network = args.Length > 1 ? args[1] : "main";
int recordsToRead = 100;
if (args.Length > 2 && int.TryParse(args[2], out int readRecords))
{
    recordsToRead = readRecords;
}
string action = args.Length > 3 ? args[3] : "seed";

// Seed the database
using IHost host = builder.Build();
IMapper mapper = host.Services.GetRequiredService<IMapper>();
IServiceManager serviceManager = host.Services.GetRequiredService<IServiceManager>();
BCSeeder.Seed(serviceManager, mapper, crypto, network, recordsToRead, action);
await host.RunAsync();

