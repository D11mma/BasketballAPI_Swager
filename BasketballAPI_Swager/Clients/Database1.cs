using BasketballAPI_Swager.Model;
using Npgsql;
namespace BasketballAPI_Swager.Clients
{
    public class Database
    {
        NpgsqlConnection con = new NpgsqlConnection(Constant.Connect);
        public async Task InsertFavouriteTeamAsync(string NameOfTeam, long IdOfTeam)
        {
            var sql = "insert into public.\"BasketballTable\"(\"NameOfTeam\",\"IdOfTeam\") values(@NameOfTeam,@IdOfTeam)";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("NameOfTeam", NameOfTeam);
            cmd.Parameters.AddWithValue("IdOfTeam", IdOfTeam);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }
        public async Task DeleteFavouriteTeamAsync(long IdOfTeam)
        {
            var sql = $"delete from public.\"BasketballTable\" where \"IdOfTeam\" = @IdOfTeam";

            await using (var command = new NpgsqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("IdOfTeam", IdOfTeam);
             
                await con.OpenAsync();
                await command.ExecuteNonQueryAsync();
                await con.CloseAsync();
            }
        }
        public async Task ChangeFavouriteTeamAsync(string NameOfTeam, long IdOfTeam)
        {
            var sql = $"UPDATE public.\"BasketballTable\" SET \"NameOfTeam\" = @NameOfTeam WHERE \"IdOfTeam\" = @IdOfTeam";

            await using (var command = new NpgsqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("NameOfTeam", NameOfTeam);
                command.Parameters.AddWithValue("IdOfTeam", IdOfTeam);
                await con.OpenAsync();
                await command.ExecuteNonQueryAsync();
                await con.CloseAsync();
            }
        }
        public async Task<string> GetFavouriteTeamAsync(long IdOfTeam)
        {
            var sql = $"SELECT \"NameOfTeam\" FROM public.\"BasketballTable\" WHERE \"IdOfTeam\" = @IdOfTeam";

            await using (var command = new NpgsqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("IdOfTeam", IdOfTeam);

                await con.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        string answer = reader.GetString(0);
                        await con.CloseAsync();
                        return answer;
                    }
                }
                await con.CloseAsync();
                return null;
            }
        }
    }
}