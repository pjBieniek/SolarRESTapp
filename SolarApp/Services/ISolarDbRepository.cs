using SolarApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Services
{
    public interface ISolarDbRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(int userId);
        void AddUser(string fullName, User user);
        //void UpdateUser(User user);
        void DeleteUser(User user);

        IEnumerable<Session> GetSessions();
        Session GetSession(int sessionId);
        void AddSession(User user, DateTime date, Session session);
        //void UpdateSession(Session session);
        void DeleteSession(Session session);

        IEnumerable<Team> GetTeams();
        Team GetTeam(int teamId);
        void AddTeam(string name, Team team);
        //void UpdateTeam(Team team);
        void DeleteTeam(Team team);

        IEnumerable<Competition> GetCompetitions();
        Competition GetCompetition(int competitionId);
        void AddCompetition(string title, Competition competition);
        //void UpdateCompetition(Competition competition);
        void DeleteCompetition(Competition competition);

        IEnumerable<Result> GetResults(int competitionId);
        Result GetResult(int resultId, int competitionId);
        void AddResult(Result result);
        //void UpdateResult(Result result);
        void DeleteResult(Result result);

        IEnumerable<Role> GetRoles();
        Role GetRole(string title);
        void AddRole(string title, Role role);
        //void UpdateRole(Role role);
        void DeleteRole(Role role);

        IEnumerable<UserRole> GetUserRoles(int userId);

        //bool UserExists(User user);
        //bool SessionExists(Session session);
        //bool TeamExists(Team team);
        bool CompetitionExists(int competitionId);
        //bool ResultExists(Result result);
        //bool RoleExists(Role role);
        bool Save();
    }
}
