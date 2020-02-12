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
        public void AddCompetition(string title, Competition competition)
        {
            if (title == string.Empty)
                throw new ArgumentNullException(nameof(title));
            if (competition == null)
                throw new ArgumentNullException(nameof(competition));
            competition.CompetitionTitle = title;
            _solarDbContext.Competitions.Add(competition);
        }

        public void AddResult(Result result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            _solarDbContext.Results.Add(result);
        }

        public void AddRole(string title, Role role)
        {
            if (title == string.Empty)
                throw new ArgumentNullException(nameof(title));
            if (role == null)
                throw new ArgumentNullException(nameof(role));
            role.RoleTitle = title;
            _solarDbContext.Roles.Add(role);
        }

        public void AddSession(User user, DateTime date, Session session)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (date == null)
                throw new ArgumentNullException(nameof(date));
            if (session == null)
                throw new ArgumentNullException(nameof(session));
            _solarDbContext.Sessions.Add(session);
        }

        public void AddTeam(string name, Team team)
        {
            if (name == string.Empty)
                throw new ArgumentNullException(nameof(name));
            if (team == null)
                throw new ArgumentNullException(nameof(team));
            team.TeamName = name;
            _solarDbContext.Teams.Add(team);
        }

        public void AddUser(string fullName, User user)
        {
            if (fullName == string.Empty)
                throw new ArgumentNullException(nameof(fullName));
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            user.UserFullName = fullName;
            _solarDbContext.Users.Add(user);
        }

        public bool CompetitionExists(Competition competition)
        {
            throw new NotImplementedException();
        }

        public void DeleteCompetition(Competition competition)
        {
            if (competition == null)
                throw new ArgumentNullException(nameof(competition));
            _solarDbContext.Competitions.Remove(competition);
        }

        public void DeleteResult(Result result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            _solarDbContext.Results.Remove(result);
        }

        public void DeleteRole(Role role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));
            _solarDbContext.Roles.Remove(role);
        }

        public void DeleteSession(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));
            _solarDbContext.Sessions.Remove(session);
        }

        public void DeleteTeam(Team team)
        {
            if (team == null)
                throw new ArgumentNullException(nameof(team));
            _solarDbContext.Teams.Remove(team);
        }

        public void DeleteUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            _solarDbContext.Users.Remove(user);
        }

        public Competition GetCompetition(int competitionId)
        {
            int intValue;
            if (!int.TryParse(competitionId.ToString(), out intValue))
                throw new ArgumentNullException(nameof(competitionId));
            return _solarDbContext.Competitions.Where(c => c.CompetitionId == competitionId).FirstOrDefault();
        }

        public IEnumerable<Competition> GetCompetitions()
        {
            throw new NotImplementedException();
        }

        public Result GetResult(int teamId, int competitionId)
        {
            int intValue1;
            int intValue2;
            if (!int.TryParse(teamId.ToString(), out intValue1))
                throw new ArgumentNullException(nameof(teamId));
            if (!int.TryParse(competitionId.ToString(), out intValue2))
                throw new ArgumentNullException(nameof(competitionId));
            return _solarDbContext.Results.Where(t => t.TeamId == teamId && t.CompetitionId == competitionId).FirstOrDefault();

        }

        public IEnumerable<Result> GetResults()
        {
            throw new NotImplementedException();
        }

        public Role GetRole(string title)
        {
            if (title == string.Empty)
                throw new ArgumentNullException(nameof(title));
            return _solarDbContext.Roles.Where(r => r.RoleTitle == title).FirstOrDefault();
        }

        public IEnumerable<Role> GetRoles()
        {
            throw new NotImplementedException();
        }

        public Session GetSession(int sessionId)
        {
            int intValue;
            if (!int.TryParse(sessionId.ToString(), out intValue))
                throw new ArgumentNullException(nameof(sessionId));
            return _solarDbContext.Sessions.Where(s => s.SessionId == sessionId).FirstOrDefault();
        }

        public IEnumerable<Session> GetSessions()
        {
            throw new NotImplementedException();
        }

        public Team GetTeam(int teamId)
        {
            int intValue;
            if (!int.TryParse(teamId.ToString(), out intValue))
                throw new ArgumentNullException(nameof(teamId));
            return _solarDbContext.Teams.Where(t => t.TeamId == teamId).FirstOrDefault();
        }

        public IEnumerable<Team> GetTeams()
        {
            throw new NotImplementedException();
        }

        public User GetUser(int userId)
        {
            int intValue;
            if (!int.TryParse(userId.ToString(), out intValue))
                throw new ArgumentNullException(nameof(userId));
            return _solarDbContext.Users.Where(u => u.UserId == userId).FirstOrDefault();
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
