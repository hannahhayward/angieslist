using System.Collections.Generic;
using System.Data;
using System.Linq;
using angieslist.Models;
using Dapper;

namespace angieslist.Repositories
{
  public class JobsRepository
  {
    private readonly IDbConnection _db;
    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }
    public Job Create(Job j)
    {
      string sql = @"
      INSERT INTO
        jobs(title, body)
      VALUES(@Title, @Body);
      SELECT LAST_INSERT_ID();
      ";
      j.Id = _db.ExecuteScalar<int>(sql, j);
      return j;
    }
    internal List<Job> GetJobById(int id)
    {
      string sql = @"
      SELECT *
      FROM jobs j
      JOIN accounts a ON a.id = j.accountId
      WHERE j.id = @id ;";
      return _db.Query<Job, Profile, Job>(sql, (j, p) =>
      {
        j.Profile = p;
        return j;
      }, new {id}).ToList();
    }
    internal List<Job> GetAllJobs()
    {
      string sql = @"
      SELECT
        j*,
        a*
        FROM jobs j
        JOIN accounts a ON j.creatorId = a.id;";
        return _db.Query<Job, Profile, Job>(sql, (j, p) =>
        {
          j.Profile = p;
          return j;
        }, splitOn: "id").ToList();
    }
  }
}