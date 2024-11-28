using METC_Interview.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace METC_Interview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IConfiguration _configuration; // 注入 IConfiguration
        private static readonly string[] Summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;  // 初始化 IConfiguration
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// 取得ACPD列表
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        [HttpGet("GetACPDList")]
        public IEnumerable<Select_Myoffice_ACPD> GetACPDList()
        {
            var officeData = new List<Select_Myoffice_ACPD>();

            // 從 appsettings.json 讀取 SQL 連接字串
            string connectionString = _configuration.GetConnectionString("MyDatabase");

            // 檢查 connectionString 是否為空
            if (string.IsNullOrEmpty(connectionString))
            {
                _logger.LogError("Connection string 'MyDatabase' is missing or invalid.");
                throw new InvalidOperationException("Connection string 'MyDatabase' is missing or invalid.");
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // 呼叫存儲過程 sp_Select_Myoffice_ACPD
                using (var command = new SqlCommand("sp_Select_Myoffice_ACPD", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@jsonInput", "1");

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var officeRecord = new Select_Myoffice_ACPD
                            {
                                acpd_sid = reader.GetString(reader.GetOrdinal("acpd_sid")), 
                                acpd_cname = reader.GetString(reader.GetOrdinal("acpd_cname")) 
                            };
                            officeData.Add(officeRecord);
                        }
                    }
                }
            }

            return officeData;
        }

        /// <summary>
        /// 插入新的ACPD記錄
        /// </summary>
        /// <param name="acpd">包含要插入的ACPD資料</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        [HttpPost("InsertACPD")]
        public async Task<IActionResult> InsertACPD([FromBody] Insert_Myoffice_ACPD acpd)
        {
            // 檢查接收到的資料是否為 null
            if (acpd == null)
            {
                _logger.LogError("ACPD data is null.");
                return BadRequest("ACPD data is null.");
            }

            // 從 appsettings.json 讀取 SQL 連接字串
            string connectionString = _configuration.GetConnectionString("MyDatabase");

            // 檢查 connectionString 是否為空
            if (string.IsNullOrEmpty(connectionString))
            {
                _logger.LogError("Connection string 'MyDatabase' is missing or invalid.");
                throw new InvalidOperationException("Connection string 'MyDatabase' is missing or invalid.");
            }

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    // 呼叫存儲過程 sp_Insert_Myoffice_ACPD
                    using (var command = new SqlCommand("sp_Insert_Myoffice_ACPD", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // 傳遞更新的參數
                        command.Parameters.AddWithValue("@acpd_sid", acpd.acpd_sid);
                        command.Parameters.AddWithValue("@acpd_cname", acpd.acpd_cname);
                        command.Parameters.AddWithValue("@acpd_ename", acpd.acpd_ename);
                        command.Parameters.AddWithValue("@acpd_sname", acpd.acpd_sname);
                        command.Parameters.AddWithValue("@acpd_email", acpd.acpd_email);
                        command.Parameters.AddWithValue("@acpd_status", acpd.acpd_status);
                        command.Parameters.AddWithValue("@acpd_stop", acpd.acpd_stop);
                        command.Parameters.AddWithValue("@acpd_stopMemo", acpd.acpd_stopMemo);
                        command.Parameters.AddWithValue("@acpd_loginID", acpd.acpd_LoginID);
                        command.Parameters.AddWithValue("@acpd_loginPW", acpd.acpd_LoginPW);
                        command.Parameters.AddWithValue("@acpd_memo", acpd.acpd_memo);
                        command.Parameters.AddWithValue("@acpd_nowdatetime", acpd.acpd_nowdatetime);
                        command.Parameters.AddWithValue("@appd_nowid", acpd.appd_nowid);
                        command.Parameters.AddWithValue("@acpd_upddatetitme", acpd.acpd_upddatetitme);
                        command.Parameters.AddWithValue("@acpd_updid", acpd.acpd_updid);
                        command.Parameters.AddWithValue("@logResult", acpd.logResult);



                        var returnCodeParam = new SqlParameter("@ReturnCode", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(returnCodeParam);
                        
                        await command.ExecuteNonQueryAsync();
                        
                        int returnCode = (int)returnCodeParam.Value;

                        // 檢查返回的執行代碼
                        if (returnCode != 0)
                        {
                            _logger.LogError($"Insert operation failed with return code: {returnCode}");
                            return StatusCode(500, $"Insert operation failed with return code: {returnCode}");
                        }
                    }
                }

                return Ok("ACPD record inserted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error inserting ACPD: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// 刪除ACPD記錄
        /// </summary>
        /// <param name="acpd">包含要刪除的ACPD資料</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        [HttpDelete("DeleteACPD")]
        public async Task<IActionResult> DeleteACPD([FromBody] Delete_Myoffice_ACPD acpd)
        {
            // 檢查接收到的資料是否為 null
            if (acpd == null)
            {
                _logger.LogError("ACPD data is null.");
                return BadRequest("ACPD data is null.");
            }

            // 從 appsettings.json 讀取 SQL 連接字串
            string connectionString = _configuration.GetConnectionString("MyDatabase");

            // 檢查 connectionString 是否為空
            if (string.IsNullOrEmpty(connectionString))
            {
                _logger.LogError("Connection string 'MyDatabase' is missing or invalid.");
                throw new InvalidOperationException("Connection string 'MyDatabase' is missing or invalid.");
            }

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    // 呼叫存儲過程 sp_Delete_Myoffice_ACPD
                    using (var command = new SqlCommand("sp_Delete_Myoffice_ACPD", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // 傳遞刪除的acpd_sid參數
                        command.Parameters.AddWithValue("@acpd_sid", acpd.acpd_sid);

                        var returnCodeParam = new SqlParameter("@ReturnCode", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(returnCodeParam);

                        await command.ExecuteNonQueryAsync();

                        int returnCode = (int)returnCodeParam.Value;

                        // 檢查返回的執行代碼
                        if (returnCode != 0)
                        {
                            _logger.LogError($"Delete operation failed with return code: {returnCode}");
                            return StatusCode(500, $"Delete operation failed with return code: {returnCode}");
                        }
                    }
                }

                return Ok("ACPD record deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting ACPD: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// 更新ACPD記錄
        /// </summary>
        /// <param name="acpd">包含要更新的ACPD資料</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        [HttpPatch("UpdateACPD")]
        public async Task<IActionResult> UpdateACPD([FromBody] Update_Myoffice_ACPD acpd)
        {
            // 檢查接收到的資料是否為 null
            if (acpd == null)
            {
                _logger.LogError("ACPD data is null.");
                return BadRequest("ACPD data is null.");
            }

            // 從 appsettings.json 讀取 SQL 連接字串
            string connectionString = _configuration.GetConnectionString("MyDatabase");

            // 檢查 connectionString 是否為空
            if (string.IsNullOrEmpty(connectionString))
            {
                _logger.LogError("Connection string 'MyDatabase' is missing or invalid.");
                throw new InvalidOperationException("Connection string 'MyDatabase' is missing or invalid.");
            }

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    // 呼叫存儲過程 sp_Update_Myoffice_ACPD
                    using (var command = new SqlCommand("sp_Update_Myoffice_ACPD", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // 傳遞更新的參數
                        command.Parameters.AddWithValue("@acpd_sid", acpd.acpd_sid);
                        command.Parameters.AddWithValue("@acpd_cname", acpd.acpd_cname);
                        command.Parameters.AddWithValue("@acpd_ename", acpd.acpd_ename);
                        command.Parameters.AddWithValue("@acpd_sname", acpd.acpd_sname);
                        command.Parameters.AddWithValue("@acpd_email", acpd.acpd_email);
                        command.Parameters.AddWithValue("@acpd_status", acpd.acpd_status);
                        command.Parameters.AddWithValue("@acpd_stop", acpd.acpd_stop);
                        command.Parameters.AddWithValue("@acpd_stopMemo", acpd.acpd_stopMemo);
                        command.Parameters.AddWithValue("@acpd_loginID", acpd.acpd_LoginID);
                        command.Parameters.AddWithValue("@acpd_loginPW", acpd.acpd_LoginPW);
                        command.Parameters.AddWithValue("@acpd_memo", acpd.acpd_memo);
                        command.Parameters.AddWithValue("@acpd_nowdatetime", acpd.acpd_nowdatetime);
                        command.Parameters.AddWithValue("@appd_nowid", acpd.appd_nowid);
                        command.Parameters.AddWithValue("@acpd_upddatetitme", acpd.acpd_upddatetitme);
                        command.Parameters.AddWithValue("@acpd_updid", acpd.acpd_updid);
                        command.Parameters.AddWithValue("@logResult", acpd.logResult);

                        var returnCodeParam = new SqlParameter("@ReturnCode", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(returnCodeParam);

                        await command.ExecuteNonQueryAsync();

                        int returnCode = (int)returnCodeParam.Value;

                        // 檢查返回的執行代碼
                        if (returnCode != 0)
                        {
                            _logger.LogError($"Update operation failed with return code: {returnCode}");
                            return StatusCode(500, $"Update operation failed with return code: {returnCode}");
                        }
                    }
                }

                return Ok("ACPD record updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating ACPD: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
