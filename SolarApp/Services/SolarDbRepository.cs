using SolarApp.DbContexts;
using SolarApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Services
{
    public class SolarDbRepository : ISolarDbRepository
    {
        private readonly SolarDbContext _solarDbContext;

        public SolarDbRepository(SolarDbContext context)
        {
            _solarDbContext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddCompetition(string title)
        {
            throw new NotImplementedException();
        }

        public void AddResult()
        {
            throw new NotImplementedException();
        }

        public void AddRole(string title)
        {
            throw new NotImplementedException();
        }

        public void AddSession(User user, DateTime date)
        {
            throw new NotImplementedException();
        }

        public void AddTeam(string name)
        {
            throw new NotImplementedException();
        }

        public void AddUser(string fullName)
        {
            throw new NotImplementedException();
        }

        public bool CompetitionExists(Competition competition)
        {
            throw new NotImplementedException();
        }

        public void DeleteCompetition(Competition competition)
        {
            throw new NotImplementedException();
        }

        public void DeleteResult(Result result)
        {
            throw new NotImplementedException();
        }

        public void DeleteRole(Role role)
        {
            throw new NotImplementedException();
        }

        public void DeleteSession(Session session)
        {
            throw new NotImplementedException();
        }

        public void DeleteTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetCompetition(int competitionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Competition> GetCompetitions()
        {
            throw new NotImplementedException();
        }

        public User GetResult(int teamId, int competitionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Result> GetResults()
        {
            throw new NotImplementedException();
        }

        public User GetRole(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetRoles()
        {
            throw new NotImplementedException();
        }

        public User GetSession(int sessionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Session> GetSessions()
        {
            throw new NotImplementedException();
        }

        public User GetTeam(int teamId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Team> GetTeams()
        {
            throw new NotImplementedException();
        }

        public User GetUser(int roleId, int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool ResultExists(Result result)
        {
            throw new NotImplementedException();
        }

        public bool RoleExists(Role role)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool SessionExists(Session session)
        {
            throw new NotImplementedException();
        }

        public bool TeamExists(Team team)
        {
            throw new NotImplementedException();
        }

        public void UpdateCompetition(Competition competition)
        {
            throw new NotImplementedException();
        }

        public void UpdateResult(Result result)
        {
            throw new NotImplementedException();
        }

        public void UpdateRole(Role role)
        {
            throw new NotImplementedException();
        }

        public void UpdateSession(Session session)
        {
            throw new NotImplementedException();
        }

        public void UpdateTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(User user)
        {
            throw new NotImplementedException();
        }
    }
}
