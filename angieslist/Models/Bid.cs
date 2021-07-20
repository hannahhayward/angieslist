using System;

namespace angieslist.Models
{
  public class Bid 
  {
    public int Id {get;set;}
    public string Body {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get;set;}
    public int CreatorId {get;set;}
    //virtuals below
    public Contractor Creator {get;set;}
    public Job JobPosting {get;set;}
  }
}