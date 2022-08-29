using Business.EmailSender;
using Common.Models;
using Common.Models.EmailSender;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace Business.Extensions;

public static class EmailSenderExtension
{
	public static IServiceCollection AddSmtpSettings(this IServiceCollection services, ConfigurationManager configMgr, string bindingConfigName = "SmtpSettings")
	{
		SmtpSettings apiConfig = new SmtpSettings();
		configMgr.Bind(bindingConfigName, apiConfig);
		services.AddSingleton<SmtpSettings>(apiConfig);
		services.AddScoped<IEmailSendingHandler, EmailSendingHandler>();

		return services;
	}

}
