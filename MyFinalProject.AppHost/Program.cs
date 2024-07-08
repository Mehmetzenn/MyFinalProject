var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.WebApplication1>("webapplication1");

builder.Build().Run();
