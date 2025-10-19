using FinSync.Finances.Application.Services.Contracts;
using FinSync.Finances.Application.UseCases;
using FinSync.Finances.Domain.Repositories;
using FinSync.Finances.Infra;
using FinSync.Finances.Infra.Repositories;
using FinSync.Mapper;
using Microsoft.EntityFrameworkCore;

namespace FinSync.Finances.API.Config;

internal static class DependencyInjectionExtensions
{
  internal static void InjectDesignatedDependencies(this WebApplicationBuilder builder)
  {
    builder.Services.AddScoped<IFinancialAccountService, ApplicationServicesImpl.FinancialAccountService>();
    builder.Services.AddScoped<IFinancialAccountRepository, FinancialAccountRepository>();

    builder.Services.AddScoped<
      ICreateAsyncUseCase<ApplicationsDTOS.FinancialAccountForCreationDTO, DomainEntities.FinancialAccount>,
      ApplicationServicesImpl.FinancialAccountService>();
  }

  internal static void InjectObjectMapper(this WebApplicationBuilder builder)
    => builder.Services.AddSingleton<IMapper, FluentMapper>(provider =>
    {
      var mapper = new FluentMapper();

      mapper.Register<FinancialAccountForCreationDTO, ApplicationsDTOS.FinancialAccountForCreationDTO>(src =>
        new ApplicationsDTOS.FinancialAccountForCreationDTO(src.UserId, src.Name, src.Balance, src.CurrencyAcronym));

      mapper.Register<ApplicationsDTOS.FinancialAccountForCreationDTO, DomainEntities.FinancialAccount>(src =>
        new DomainEntities.FinancialAccount(src.UserId, src.Name, src.Balance, src.CurrencyAcronym));

      mapper.Register<DomainEntities.FinancialAccount, FinancialAccount>(src =>
        new FinancialAccount
        {
          Id = src.Id.ToString(),
          UserId = src.UserId,
          Name = src.Name,
          Balance = (long)(src.Balance * 100),
          CurrencyAcronym = src.CurrencyAcronym,
          CreatedAt = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(src.CreatedAt.ToUniversalTime()),
          UpdatedAt = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(src.UpdatedAt.ToUniversalTime())
        });

      return mapper;
    });

  internal static void InjectDbContext(this WebApplicationBuilder builder)
  {
    builder.Services.AddDbContext<FinancesDBContext>(options =>
      options.UseNpgsql(Environment.GetEnvironmentVariable("FINANCES_DB_CONNECTION_STRING")));
  }
}