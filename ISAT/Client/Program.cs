global using ISAT.Client.Services.GenderService; // ISAT making global ref
global using ISAT.Client.Services.UsersTypeService; // ISAT making global ref
global using ISAT.Client.Services.SexualOrientationService; // ISAT making global ref
global using ISAT.Client.Services.IntervieweeService; // ISAT making global ref
global using ISAT.Client.Services.InterviewService; // ISAT making global ref
global using ISAT.Client.Services.InterviewStatusService; // ISAT making global ref
global using ISAT.Shared.Models;
using ISAT.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ISAT.Client.Services.InterviewerService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("ISAT.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ISAT.ServerAPI"));

// custom services 
//ISAT adding ref
builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<IUsersTypeService, UsersTypeService>();
builder.Services.AddScoped<ISexualOrientationService, SexualOrientationService>();
builder.Services.AddScoped<IIntervieweeService, IntervieweeService>();
builder.Services.AddScoped<IInterviewService, InterviewService>();
builder.Services.AddScoped<IInterviewStatusService, InterviewStatusService>();
builder.Services.AddScoped<IInterviewerService, InterviewerService>();

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
