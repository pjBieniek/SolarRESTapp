using SolarApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Services
{
    interface ISolarDbRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(int roleId, int userId);
        void AddUser(string fullName, User user);
        void UpdateUser(User user);
        void DeleteUser(User user);

        IEnumerable<Session> GetSessions();
        User GetSession(int sessionId);
        void AddSession(User user, DateTime date, Session session);
        void UpdateSession(Session session);
        void DeleteSession(Session session);

        IEnumerable<Team> GetTeams();
        User GetTeam(int teamId);
        void AddTeam(string name, Team team);
        void UpdateTeam(Team team);
        void DeleteTeam(Team team);

        IEnumerable<Competition> GetCompetitions();
        User GetCompetition(int competitionId);
        void AddCompetition(string title, Competition competition);
        void UpdateCompetition(Competition competition);
        void DeleteCompetition(Competition competition);

        IEnumerable<Result> GetResults();
        User GetResult(int teamId, int competitionId);
        void AddResult(Result result);
        void UpdateResult(Result result);
        void DeleteResult(Result result);

        IEnumerable<Role> GetRoles();
        User GetRole(int userId);
        void AddRole(string title, Role role);
        void UpdateRole(Role role);
        void DeleteRole(Role role);

        bool UserExists(User user);
        bool SessionExists(Session session);
        bool TeamExists(Team team);
        bool CompetitionExists(Competition competition);
        bool ResultExists(Result result);
        bool RoleExists(Role role);
        bool Save();
    }
}
