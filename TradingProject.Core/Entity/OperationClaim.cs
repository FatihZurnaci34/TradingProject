using Core.Entity;

namespace TradingProject.Core.Entity;

public class OperationClaim : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public OperationClaim()
    {
    }

    public OperationClaim(int id, string name) 
    {
        Id = id;
        Name = name;
    }
}