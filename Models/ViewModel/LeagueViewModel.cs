using System;

namespace APIChallengeWebAPI.ViewModel
{
  public class LeagueViewModel
  {

    public long PlayerId{ get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long? TeamID { get; set; }
    public string TeamName{ get; set; }

  }
}
