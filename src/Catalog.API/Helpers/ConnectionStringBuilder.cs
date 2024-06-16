using System.Runtime.CompilerServices;

namespace Catalog.API.Helpers;

public class ConnectionStringBuilder
{
    private string serverName = string.Empty;
    private string databaseName = string.Empty;
    private string credentials = string.Empty;
    private int port;

    public ConnectionStringBuilder WithServer(string serverName)
    {
        this.serverName = serverName;
        return this;
    }
    public ConnectionStringBuilder WithPort(int port)
    {
        this.port = port;
        return this;
    }
    public ConnectionStringBuilder WithDatabase(string databaseName)
    {
        this.databaseName = databaseName;
        return this;
    }

    public ConnectionStringBuilder WithCredentials(string credentials)
    {
        this.credentials = credentials;
        return this;
    }

    public string Build()
    {
        DefaultInterpolatedStringHandler stringHandler = new DefaultInterpolatedStringHandler();
        stringHandler.AppendLiteral("Server=");
        stringHandler.AppendLiteral(serverName);
        stringHandler.AppendLiteral(";");
        stringHandler.AppendLiteral("Port=");
        stringHandler.AppendLiteral(port.ToString());
        stringHandler.AppendLiteral(";");
        stringHandler.AppendLiteral("Database=");
        stringHandler.AppendLiteral(databaseName);
        stringHandler.AppendLiteral(";");
        stringHandler.AppendFormatted(credentials);
        stringHandler.AppendLiteral("Include Error Detail=true");
        return stringHandler.ToStringAndClear();
    }
}

