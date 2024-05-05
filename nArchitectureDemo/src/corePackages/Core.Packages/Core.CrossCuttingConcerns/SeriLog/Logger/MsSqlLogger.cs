using Core.CrossCuttingConcerns.SeriLog.ConfigurationModels;
using Core.CrossCuttingConcerns.SeriLog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.SeriLog.Logger;

public class MsSqlLogger:LoggerServiceBase
{
    public MsSqlLogger(IConfiguration configuration)
    {
		MsSqlConfiguration logConfig =
	   configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration").Get<MsSqlConfiguration>()
	   ?? throw new Exception(SeriLogMessages.NullOptionsMessage);

		MSSqlServerSinkOptions sinkOptions = new()
		{
			TableName = logConfig.TableName,
			AutoCreateSqlDatabase=logConfig.AutoCreateSqlTable
		};
		ColumnOptions columnOptions = new();

		global::Serilog.Core.Logger seriLogConfig = new LoggerConfiguration().WriteTo.
			MSSqlServer(logConfig.ConnectionString, sinkOptions, columnOptions: columnOptions)
			.CreateLogger();

		Logger = seriLogConfig;
	}
}
