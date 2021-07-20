using System;
using System.ComponentModel.DataAnnotations;

namespace angieslist.Models
{
  public class Job
  {
    public int Id {get;set;}
    [Required]
    public string Title {get;set;}
    [Required]
    public string Body {get;set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
    public string CreatorId {get;set;}
    //virtuals below here
    public Profile Creator {get; set;}
  }
}