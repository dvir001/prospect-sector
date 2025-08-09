using System.Text;
using Robust.Shared.Configuration;
using Content.Shared.CCVar;

/// <summary>
/// Prospect: A factory for building PostgreSQL connection strings, needed for database ssl auth.
/// </summary>
public static class PostgresConnectionFactory
{
    public static string Build(IConfigurationManager cfg)
    {
        var host = cfg.GetCVar(CCVars.DatabasePgHost);
        var port = cfg.GetCVar(CCVars.DatabasePgPort);
        var db   = cfg.GetCVar(CCVars.DatabasePgDatabase);
        var user = cfg.GetCVar(CCVars.DatabasePgUsername);
        var pass = cfg.GetCVar(CCVars.DatabasePgPassword);
        var sslMode = cfg.GetCVar(CCVars.DatabasePgSslMode);
        var trust = cfg.GetCVar(CCVars.DatabasePgTrustServerCertificate);
        var rootCert = cfg.GetCVar(CCVars.DatabasePgRootCert);

        var sb = new StringBuilder();
        sb.Append($"Host={host};Port={port};Database={db};Username={user};Password={pass};");
        if (!string.IsNullOrWhiteSpace(sslMode))
            sb.Append($"SSL Mode={sslMode};");

        if (!string.IsNullOrWhiteSpace(rootCert))
        {
            // Prefer root certificate if provided.
            sb.Append($"Root Certificate={rootCert};");
        }
        else if (trust)
        {
            // Fallback for dev environments.
            sb.Append("Trust Server Certificate=true;");
        }

        // Optional tuning (leave commented unless needed):
        // sb.Append("Timeout=15;Command Timeout=30;");

        return sb.ToString();
    }
}
