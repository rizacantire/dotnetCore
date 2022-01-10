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
                    Id=1,Name = "Beşiktaş",City = "İstanbul",FoundedDate = 1903
                },
                new Team{
                    Id=2,Name = "Galatasaray",City = "İstanbul",FoundedDate = 1905
                },
                new Team{
                    Id=3,Name = "Fenerbahçe",City = "İstanbul",FoundedDate = 1907
                },
                new Team{
                    Id=4,Name = "Trabzonspor",City = "Trabzon",FoundedDate = 1961
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

            [HttpPost]
            public IActionResult AddTeam([FromBody] Team newTeam){
                var team = Teams.SingleOrDefault(t=>t.Name == newTeam.Name);
                if(team is not null)
                    return BadRequest();
               
                Teams.Add(newTeam);
                return Ok();
            }

            [HttpPut("{id}")]
            public IActionResult UpdateTeam(int id,[FromBody] Team updateTeam){
                var team = Teams.SingleOrDefault(t=>t.Id == id);
                if(team is  null)
                    return BadRequest();
                 team.Id = updateTeam.Id != default ? updateTeam.Id : team.Id;
                 team.Name = updateTeam.Name != default ? updateTeam.Name : team.Name;
                 team.FoundedDate = updateTeam.FoundedDate != default ? updateTeam.FoundedDate : team.FoundedDate;
                 team.City = updateTeam.City != default ? updateTeam.City : team.City;
                 
                return Ok();
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteTeam(int id)
            {
                var team = Teams.SingleOrDefault(t=>t.Id == id);
                if(team is  null)
                    return BadRequest();
                Teams.Remove(team);
                return Ok();
            }

        }
}