using System.Data;

namespace SnappetChallenge.Application.Interfaces;

public interface IDBConnectable
{
    IDbConnection CreateConnection(bool open = true);
}
