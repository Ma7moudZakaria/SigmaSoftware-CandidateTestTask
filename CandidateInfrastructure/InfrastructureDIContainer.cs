using CandidateDomain.Repositories;
using CandidateEntites;
using CandidateEntites.Entities;
using CandidateInfrastructure.Mappings;
using CandidateInfrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using CandidateDomain.Features.SaveCandidate.CQRS.Command;
using CandidateDomain.Features.SaveCandidate.Validator.Command;

namespace CandidateInfrastructure
{
    public static class InfrastructureDIContainer
    {
        public static IServiceCollection AddInfrastructureDIContainer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddMediatR(typeof(IMarkupAssemblyScanning));
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddScoped<IValidator<SaveCandidateInformationCommand>, SaveCandidateInformationValidator>();
            services.AddDbContext<CandidateDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                     a => a.MigrationsAssembly("SigmaSoftwareCandidateTestTask"));
            });
            return services;
        }
    }
}
