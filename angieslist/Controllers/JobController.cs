using System.Collections.Generic;
using System.Threading.Tasks;
using angieslist.Models;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace angieslist.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class JobController: ControllerBase
  {
    private readonly JobsService _js;
    public JobController(JobsService js)
    {
      _js = js;
    }
    [HttpGet]
    public ActionResult<List<Job>> Get()
    {
      try
      {
          List<Job> jobs = _js.GetAllJobs();
          return Ok(jobs);
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Job> GetJobById(int id)
    {
      try
      {
          Job job = _js.GetJobById(id);
          return Ok(job);
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/bids")]
    public ActionResult<List<Bid>> GetBidsByJobId(int id)
    {
      try
      {
          List<Bid> bids = _js.GetBidsByJobId(id);
          return Ok(bids);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Job>> CreateJob([FromBody] Job jobData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        jobData.CreatorId = userInfo.Id;
        var j = _js.CreateJob(jobData);
        return Ok(j);
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
  }
}