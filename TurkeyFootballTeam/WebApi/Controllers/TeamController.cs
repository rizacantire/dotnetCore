using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Entities;

namespace WebApi.Controllers
    {
        [ApiController]
        [Route("[controller]s")]
        public class TeamController : ControllerBase
        {   
            private static List<Team> Teams = new List<Team>(){
                new Team{
                    Id=1,Name = "Beşiktaş",City = "İstanbul",FoundedDate = new DateTime(1903,1,1)
                },
                new Team{
                    Id=2,Name = "Galatasaray",City = "İstanbul",FoundedDate = new DateTime(1905,1,1)
                },
                new Team{
                    Id=3,Name = "Fenerbahçe",City = "İstanbul",FoundedDate = new DateTime(1907,1,1)
                },
                new Team{
                    Id=4,Name = "Trabzonspor",City = "Trabzon",FoundedDate = new DateTime(1961,1,1)
                }

            };
            

            [HttpGet]
            public List<Team> GetTeams(){
                var teams = Teams.OrderBy(t=>t.FoundedDate).ToList();
                return teams;
            }

            // [HttpGet("{id}")]
            // public Team GetTeam(int id){
            //     var team = Teams.SingleOrDefault(t=>t.Id == id);
            //     return team;
            // }

            [HttpGet("{name}")]
            public Team GetTeam(string name){
                var team = Teams.SingleOrDefault(t=>t.Name == name);
                return team;
            }

        }
}