﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NLog;
using Swashbuckle.AspNetCore.Swagger;
using SwitchFully.IntakeApp.API.Campaigns.Mappers;
using SwitchFully.IntakeApp.API.Candidates.Mapper;
using SwitchFully.IntakeApp.API.Helpers;
using SwitchFully.IntakeApp.API.JobApplications.Mapper;
using SwitchFully.IntakeApp.API.Users.Mapper;
using SwitchFully.IntakeApp.Data;
using SwitchFully.IntakeApp.Data.Repositories;
using SwitchFully.IntakeApp.Data.Repositories.Campaigns;
using SwitchFully.IntakeApp.Data.Repositories.Candidates;
using SwitchFully.IntakeApp.Data.Repositories.FileUploads;
using SwitchFully.IntakeApp.Data.Repositories.JobApplications;
using SwitchFully.IntakeApp.Data.Repositories.JobApplications.Screenings;
using SwitchFully.IntakeApp.Data.Repositories.Users;
using SwitchFully.IntakeApp.Service.Campaigns;
using SwitchFully.IntakeApp.Service.Candidates;
using SwitchFully.IntakeApp.Service.JobApplications;
using SwitchFully.IntakeApp.Service.JobApplications.Screenings;
using SwitchFully.IntakeApp.Service.Logging;
using SwitchFully.IntakeApp.Service.Security;
using SwitchFully.IntakeApp.Service.Users;
using System;
using System.Collections;
using System.IO;
using System.Text;

namespace SwitchFully.IntakeApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            ConfigureAdditionalServices(services);
        }

        protected virtual void ConfigureAdditionalServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info
				{
					Title = "SwitchFully Intake App",
					Version = "v1"
				});
			});

			services.AddScoped<ILoggerManager, LoggerManager>();

			services.AddScoped<IUserService, UserService>();
			services.AddScoped<ICampaignService, CampaignService>();
			services.AddScoped<ICandidateService, CandidateService>();
			services.AddScoped<IJobApplicationService, JobApplicationService>();

			services.AddScoped<CampaignRepository>();
			services.AddScoped<CandidateRepository>();
			services.AddScoped<JobApplicationRepository>();
	        services.AddScoped<FileRepository>();

            services.AddScoped<IScreeningMapper, ScreeningMapper>();
            services.AddScoped<IScreeningService, ScreeningService>();
            services.AddScoped<IScreeningRepository, ScreeningRepository>();


            services.AddScoped<UserMapper>();
			services.AddScoped<ICandidateMapper, CandidateMapper>();
			services.AddSingleton<ICampaignMapper, CampaignMapper>();
			services.AddScoped<JobApplicationMapper>();
			services.AddScoped<StatusMapper>();

			services.AddScoped<Hasher>();
			services.AddScoped<Salter>();
			services.AddScoped<UserAuthenticationService>();

			services.AddTransient<SwitchFullyIntakeAppContext>();
			services.AddDbContext<SwitchFullyIntakeAppContext>(options =>
                options.UseSqlServer(GetConnectionString())
            );
			services.AddScoped<UserRepository>();

			services
				//.AddAuthorization(options => {
				//	options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.r, "admin@gmail.com"));
				//})
				.AddAuthentication(options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(options =>
				{
					options.RequireHttpsMetadata = false;
					options.SaveToken = true;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(UserAuthenticationService.GetSecretKey(Configuration["SecretKey"])),
						ValidateIssuer = false,
						ValidateAudience = false
					};
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerManager logger)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SwitchFully Intake App V1");
                c.RoutePrefix = string.Empty;
            });
            app.ConfigureExceptionHandler(logger);

            ConfigureAdditionalMiddleware(app, env);

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthentication();

            app.UseMvc();
        }

        private string GetConnectionString()
        {
            var connectionString = Environment.GetEnvironmentVariable("APPSETTING_SqlConnectionString", EnvironmentVariableTarget.Process);
            if (string.IsNullOrEmpty(connectionString))
            {
                System.Diagnostics.Trace.TraceWarning("The sql connection string environment variable was not found. Using the default.");
                connectionString = "Data Source=.\\SQLExpress;Initial Catalog=SwitchfullyIntakeApp;Integrated Security=True;";
            }
            return connectionString;
        }

        protected virtual void ConfigureAdditionalMiddleware(IApplicationBuilder app, IHostingEnvironment env)
        {
        }

    }

}

