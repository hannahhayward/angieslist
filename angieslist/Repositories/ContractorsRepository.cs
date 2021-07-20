using System.Collections.Generic;
using System.Data;
using System.Linq;
using angieslist.Models;
using Dapper;

namespace angieslist.Repositories
{
  public class ContractorsRepository
  {
    private readonly IDbConnection _db;
    public ContractorsRepository(IDbConnection db)
    {
      _db = db;
    }
    public Contractor Create(Contractor c)
    {
      string sql = @"
      INSERT INTO
      contractors(title, experience)
      VALUES (@Title, @Experience);
      SELECT LAST_INSERT_ID();
      ";
      c.Id = _db.ExecuteScalar<int>(sql, c);
      return c;
    }
    internal List<Contractor> GetContractorById(int id)
    {
      string sql = @"
      SELECT *
      FROM contractors c
      JOIN accounts a ON a.id = c.accountId
      WHERE jobId = @id;";
      return _db.Query<Contractor, Profile, Contractor>(sql, (c, p) =>
      {
        c.Profile = p;
        return c;
      }, new {id}).ToList();
    }
  }
}