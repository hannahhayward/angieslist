namespace angieslist.Models
{
  public class Contractor
  {
    public int Id {get;set;}
    public string Title {get;set;}
    public string Experience {get;set;}
    //virtuals below here
    public Profile Profile {get;set;}
  }
}