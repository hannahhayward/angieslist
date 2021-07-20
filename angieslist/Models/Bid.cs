using System;

namespace angieslist.Models
{
  public class Bid 
  {
    public int Id {get;set;}
    public string Body {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get;set;}
    //virtuals below
    public Contractor Contractor {get;set;}
    public Job Job {get;set;}
  }
}