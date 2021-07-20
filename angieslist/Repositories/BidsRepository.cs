using System.Collections.Generic;
using System.Data;
using System.Linq;
using angieslist.Models;
using Dapper;

namespace angieslist.Repositories
{
  public class BidsRepository
  {
    private readonly IDbConnection _db;
    public BidsRepository(IDbConnection db)
    {
      _db = db;
    }
    public Bid Create(Bid b)
    {
      string sql = @"
      INSERT INTO
        bids(body)
      VALUES(@Body);
      ;";
      b.Id = _db.ExecuteScalar<int>(sql, b);
      return b;
    }
    internal List<Bid> GetBidByJobId(int id)
    {
      string sql = @"
      SELECT *
      FROM bids b
      JOIN accounts a ON a.id = a.accountId
      WHERE jobId = @id;";
      return _db.Query<Bid, Job, Bid>(sql, (b, j) =>
      {
        b.Job = j;
        return b;
      }, new {id}).ToList();
    }
    internal List<Bid> GetBidByContractorId(int id)
    {
      string sql = @"
      SELECT *
      FROM bids b
      JOIN accounts a ON a.id = a.accountId
      WHERE contractorId = @id;";
      return _db.Query<Bid, Contractor, Bid>(sql, (b, c) =>
      {
        b.Contractor = c;
        return b;
      }, new {id}).ToList();
    }
  }
}