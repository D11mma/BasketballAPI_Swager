using BasketballAPI_Swager.Clients;
using Microsoft.AspNetCore.Mvc;

namespace BasketballAPI_Swager.Controllers
{
    public class DatabaseController : ControllerBase
    {
        private readonly ILogger<DatabaseController> _logger;
        private readonly BasketballClients _basketballClients;

        public DatabaseController(ILogger<DatabaseController> logger)
        {
            _logger = logger;

            _basketballClients = new BasketballClients();
        }
        [HttpGet("/DatabaseController/GetFavouriteTeam")]
        public async Task<string> GetFavouriteTeam(long IdOfTeam)
        {
            Database db = new Database();
            var answer = db.GetFavouriteTeamAsync(IdOfTeam).Result;
            if (string.IsNullOrEmpty(answer))
            {
                return "Переглянути улюблену команду неможливо,оскільки ви не вказали її";
            }
            return answer;
        }
        [HttpPost("/DatabaseController/SaveFavouriteTeam")]   // метод Post 
        public async Task SaveTeam(string NameOfTeam, long IdOfTeam)
        {
            Database db = new Database();

            db.InsertFavouriteTeamAsync(NameOfTeam, IdOfTeam);
            return;
        }
        [HttpPut("/DatabaseController/ChangeFavouriteTeam")]    // метод Put
        public async Task UpdateTeam(string NameOfTeam, long IdOfTeam)
        {
            Database db = new Database();

            db.ChangeFavouriteTeamAsync(NameOfTeam, IdOfTeam);
        }
        [HttpDelete("/DatabaseController/DeleteFavouriteTeam")] // метод Delete
        public async Task DeleteTeam(long IdOfTeam)
        {
            Database db = new Database();
            db.DeleteFavouriteTeamAsync(IdOfTeam);
        }
    }
}


