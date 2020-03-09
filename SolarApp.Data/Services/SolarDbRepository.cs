using Microsoft.EntityFrameworkCore;
using SolarApp.DatabaseCreation.DbContexts;
using SolarApp.DatabaseCreation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Data.Services
{
    public class SolarDbRepository : ISolarDbRepository
    {
        private readonly SolarDbContext _solarDbContext;

        public SolarDbRepository(SolarDbContext context)
        {
            _solarDbContext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddCompetition(Competition competition)
        {
            if (competition == null)
                throw new ArgumentNullException(nameof(competition));
            _solarDbContext.Competitions.Add(competition);
        }

        public void AddResult(Result result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            _solarDbContext.Results.Add(result);
        }

        public void AddResult(int competitionId, Result result)
        {
            int intValue;
            if (!int.TryParse(competitionId.ToString(), out intValue))
                throw new ArgumentNullException(nameof(competitionId));
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            result.CompetitionId = competitionId;
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

        public void AddUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            _solarDbContext.Users.Add(user);
        }

        public Competition DeleteCompetition(int id)
        {
            Competition competition = _solarDbContext.Competitions.FirstOrDefault(c => c.CompetitionId == id);
            if (competition != null)
                _solarDbContext.Competitions.Remove(competition);
            return competition;
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

        public User DeleteUser(int id)
        {
            User user = _solarDbContext.Users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
                _solarDbContext.Users.Remove(user);
            return user;
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
            return _solarDbContext.Competitions.OrderBy(c => c.CompetitionTitle).ToList();
        }

        public Result GetResult(int resultId, int competitionId)
        {
            int intValue1;
            int intValue2;
            if (!int.TryParse(resultId.ToString(), out intValue1))
                throw new ArgumentNullException(nameof(resultId));
            if (!int.TryParse(competitionId.ToString(), out intValue2))
                throw new ArgumentNullException(nameof(competitionId));
            return _solarDbContext.Results.Where(r => r.ResultId == resultId && r.CompetitionId == competitionId).FirstOrDefault();

        }

        public IEnumerable<Result> GetResults(int competitionId)
        {
            return _solarDbContext.Results.Where(r => r.CompetitionId == competitionId).ToList();
        }

        public Role GetRole(string title)
        {
            if (title == string.Empty)
                throw new ArgumentNullException(nameof(title));
            return _solarDbContext.Roles.Where(r => r.RoleTitle == title).FirstOrDefault();
        }

        public IEnumerable<Role> GetRoles()
        {
            return _solarDbContext.Roles.ToList();
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
            return _solarDbContext.Sessions.ToList();
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
            return _solarDbContext.Teams.OrderBy(t => t.TeamName).ToList();
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
            return _solarDbContext.Users.ToList();
        }

        public bool CompetitionExists(int competitionId)
        {
            int intValue;
            if (!int.TryParse(competitionId.ToString(), out intValue))
                throw new ArgumentNullException(nameof(competitionId));
            return _solarDbContext.Competitions.Any(c => c.CompetitionId == competitionId);
        }

        //public bool ResultExists(Result result)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool RoleExists(Role role)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool SessionExists(Session session)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool TeamExists(Team team)
        //{
        //    throw new NotImplementedException();
        //}

        public bool UserExists(int userId)
        {
            int intValue;
            if (!int.TryParse(userId.ToString(), out intValue))
                throw new ArgumentNullException(nameof(userId));
            return _solarDbContext.Users.Any(u => u.UserId == userId);
        }

        public void UpdateCompetition(int competitionId, Competition competition)
        {
            var competitionEntity = GetCompetition(competitionId);
            competitionEntity.CompetitionTitle = competition.CompetitionTitle;
            competitionEntity.CompetitionDescription = competition.CompetitionDescription;
            competitionEntity.CompetitionUrlAddress = competition.CompetitionUrlAddress;
            competitionEntity.CompetitionDate = competition.CompetitionDate;
        }

        //public void UpdateResult(Result result)
        //{
        //    throw new NotImplementedException();
        //}

        //public void UpdateRole(Role role)
        //{
        //    throw new NotImplementedException();
        //}

        //public void UpdateSession(Session session)
        //{
        //    throw new NotImplementedException();
        //}

        //public void UpdateTeam(Team team)
        //{
        //    throw new NotImplementedException();
        //}

        public void UpdateUser(int userId, User user)
        {
            var userEntity = GetUser(userId);
            userEntity.UserFullName = user.UserFullName;
            userEntity.UserEmail = user.UserEmail;
            userEntity.UserPassword = user.UserPassword;
        }

        public bool Save()
        {
            return (_solarDbContext.SaveChanges() > 0);
        }

        public User LoginUser(User user)
        {
            user = _solarDbContext.Users
                .Where(u => u.UserEmail == user.UserEmail
                    && u.UserPassword == user.UserPassword)
                .FirstOrDefault();
            return user;
        }
    }
}
