using BasketballAPI_Swager.Clients;
using BasketballAPI_Swager.Model;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Xml.Linq;

namespace BasketballAPI_Swager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketballTeamController : ControllerBase
    {
        private readonly ILogger<BasketballTeamController> _logger;
        private readonly BasketballClients _basketballClients;

        public BasketballTeamController(ILogger<BasketballTeamController> logger)
        {
            _logger = logger;
            
            _basketballClients = new BasketballClients();
        }

        [HttpGet("GetTeamById")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            try
            {
                var basketballTeam = await _basketballClients.GetTeamById(id);
                if (basketballTeam == null)
                {
                    return NotFound(new { Message = "Команду не знайдено" });
                }
                return Ok($"Певна інформація про команду:\nНазва баскетбольної команди: {basketballTeam.Name}\nID басктбольної команди: {basketballTeam.Id}\nЛоготип баскетбольної команди: {basketballTeam.Logo}\nНаціональна команда: {(basketballTeam.Nattionnal ? "Так" : "Ні")}\nКраїна: {basketballTeam.Country.Name} ({basketballTeam.Country.Flag})");
            }
            catch (HttpRequestException httpRequestException)
            {
                _logger.LogError(httpRequestException, "Помилка отримання даних з API");
                return StatusCode(503, new { Message = "Зовнішній API недоступний" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Сталася помилка при обробці Вашого запиту");
                return StatusCode(500, new { Message = "Внутрішня помилка сервера" });
            }
        }
        [HttpGet("GetTeamByName")]
        public async Task<IActionResult> GetTeamByName(string name)
        {
            try
            {
                //Database db = new Database();
                var basketballTeam = await _basketballClients.GetTeamByName(name);
                
                if (basketballTeam == null)
                {
                    return NotFound(new { Message = "Команду не знайдено" });
                }
                
                return Ok($"Певна інформація про команду:\nНазва баскетбольної команди: {basketballTeam.Name}\nID басктбольної команди: {basketballTeam.Id}\nЛоготип баскетбольної команди: {basketballTeam.Logo}\nНаціональна команда: {(basketballTeam.Nattionnal ? "Так" : "Ні")}\nКраїна: {basketballTeam.Country.Name} ({basketballTeam.Country.Flag})");
            }
            catch (HttpRequestException httpRequestException)
            {
                _logger.LogError(httpRequestException, "Помилка отримання даних з API");
                return StatusCode(503, new { Message = "Зовнішній API недоступний" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Сталася помилка при обробці Вашого запиту");
                return StatusCode(500, new { Message = "Внутрішня помилка сервера" });
            }
        }
        [HttpGet("GetLeagueByName")]
        public async Task<IActionResult> GetLeagueByName(string name)
        {
            try
            {
                var basketballLeague = await _basketballClients.GetLeagueByName(name);
                if (basketballLeague == null)
                {
                    return NotFound(new { Message = "Лігу не знайдено" });
                }
                return Ok($"Певна інформація про команду:\nНазва баскетбольної команди: {basketballLeague.Name}\nID баскетбольної ліги: {basketballLeague.Id}\nТип: {basketballLeague.Type}\nЛоготип баскетбольної команди: {basketballLeague.Logo}\nКраїна: {basketballLeague.Country.Name} ({basketballLeague.Country.Flag})");

            }
            catch (HttpRequestException httpRequestException)
            {
                _logger.LogError(httpRequestException, "Помилка отримання даних з API");
                return StatusCode(503, new { Message = "Зовнішній API недоступний" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Сталася помилка при обробці Вашого запиту");
                return StatusCode(500, new { Message = "Внутрішня помилка сервера" });
            }
        }
    }
}
    
