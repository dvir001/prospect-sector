using Robust.Shared.Configuration;

namespace Content.Shared.CCVar;

public sealed partial class CCVars
{
#if DEBUG
    private const int DefaultSqliteDelay = 1;
#else
    private const int DefaultSqliteDelay = 0;
#endif

    public static readonly CVarDef<string> DatabaseEngine =
        CVarDef.Create("database.engine", "sqlite", CVar.SERVERONLY);

    public static readonly CVarDef<string> DatabaseSqliteDbPath =
        CVarDef.Create("database.sqlite_dbpath", "preferences.db", CVar.SERVERONLY);

    /// <summary>
    ///     Milliseconds to asynchronously delay all SQLite database acquisitions with.
    /// </summary>
    /// <remarks>
    ///     Defaults to 1 on DEBUG, 0 on RELEASE.
    ///     This is intended to help catch .Result deadlock bugs that only happen on postgres
    ///     (because SQLite is not actually asynchronous normally)
    /// </remarks>
    public static readonly CVarDef<int> DatabaseSqliteDelay =
        CVarDef.Create("database.sqlite_delay", DefaultSqliteDelay, CVar.SERVERONLY);

    /// <summary>
    ///     Amount of concurrent SQLite database operations.
    /// </summary>
    /// <remarks>
    ///     Note that SQLite is not a properly asynchronous database and also has limited read/write concurrency.
    ///     Increasing this number may allow more concurrent reads, but it probably won't matter much.
    ///     SQLite operations are normally ran on the thread pool, which may cause thread pool starvation if the concurrency is too high.
    /// </remarks>
    public static readonly CVarDef<int> DatabaseSqliteConcurrency =
        CVarDef.Create("database.sqlite_concurrency", 3, CVar.SERVERONLY);

    public static readonly CVarDef<string> DatabasePgHost =
        CVarDef.Create("database.pg_host", "localhost", CVar.SERVERONLY);

    public static readonly CVarDef<int> DatabasePgPort =
        CVarDef.Create("database.pg_port", 5432, CVar.SERVERONLY);

    public static readonly CVarDef<string> DatabasePgDatabase =
        CVarDef.Create("database.pg_database", "ss14", CVar.SERVERONLY);

    public static readonly CVarDef<string> DatabasePgUsername =
        CVarDef.Create("database.pg_username", "postgres", CVar.SERVERONLY);

    public static readonly CVarDef<string> DatabasePgPassword =
        CVarDef.Create("database.pg_password", "", CVar.SERVERONLY | CVar.CONFIDENTIAL);

    /// <summary>
    ///     Max amount of concurrent Postgres database operations.
    /// </summary>
    public static readonly CVarDef<int> DatabasePgConcurrency =
        CVarDef.Create("database.pg_concurrency", 8, CVar.SERVERONLY);

    /// <summary>
    ///     Milliseconds to asynchronously delay all PostgreSQL database operations with.
    /// </summary>
    /// <remarks>
    ///     This is intended for performance testing. It works different from <see cref="DatabaseSqliteDelay"/>,
    ///     as the lag is applied after acquiring the database lock.
    /// </remarks>
    public static readonly CVarDef<int> DatabasePgFakeLag =
        CVarDef.Create("database.pg_fake_lag", 0, CVar.SERVERONLY);

    /// <summary>
    ///     Basically only exists for integration tests to avoid race conditions.
    /// </summary>
    public static readonly CVarDef<bool> DatabaseSynchronous =
        CVarDef.Create("database.sync", false, CVar.SERVERONLY);

    /// <summary>
    /// Prospect: Added for SSL/TLS support ---
    /// </summary>
    public static readonly CVarDef<string> DatabasePgSslMode =
        CVarDef.Create("database.pg_sslmode", "Disable", CVar.SERVERONLY); // sslmode values: Disable, Allow, Prefer, Require, VerifyCA, VerifyFull

    public static readonly CVarDef<bool> DatabasePgTrustServerCertificate =
        CVarDef.Create("database.pg_trust_server_certificate", true, CVar.SERVERONLY);

    public static readonly CVarDef<string> DatabasePgServerCompatibilityMode =
        CVarDef.Create("database.pg_server_compatibility_mode", "None", CVar.SERVERONLY); // compatibility modes: None, Redshift

    public static readonly CVarDef<bool> DatabasePgCheckCertificateRevocation =
        CVarDef.Create("database.pg_check_certificate_revocation", false, CVar.SERVERONLY);

    public static readonly CVarDef<int> DatabasePgConnectionTimeout =
        CVarDef.Create("database.pg_connection_timeout", 30, CVar.SERVERONLY); // Connection timeout in seconds

    public static readonly CVarDef<int> DatabasePgCommandTimeout =
        CVarDef.Create("database.pg_command_timeout", 30, CVar.SERVERONLY); // Command timeout in seconds

    public static readonly CVarDef<int> DatabasePgKeepAlive =
        CVarDef.Create("database.pg_keep_alive", 30, CVar.SERVERONLY); // Keep alive interval in seconds
    /// <summary>
    /// End Prospect: Added for SSL/TLS support ---
    /// </summary>
}
