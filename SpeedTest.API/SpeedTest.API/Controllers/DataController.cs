using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SpeedTest.API.Data;
using SpeedTest.API.Dto;
using SpeedTest.API.Entities;

namespace SpeedTest.API.Controllers
{
    public class DataController : Controller
    {
        private readonly HistoryContext _historyContext;

        public DataController(HistoryContext historyContext)
        {
            _historyContext = historyContext;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add()
        {
            try
            {

                var historyLog = new HistoryLog();
                foreach (var item in Request.Form.Keys)
                {
                    historyLog = JsonConvert.DeserializeObject<HistoryLog>(item);
                }
                var history = new History
                {
                    Download = historyLog.Download,
                    Upload = historyLog.Upload,
                    Ping = historyLog.Ping,
                    UserId = historyLog.Id,
                    LogTime = DateTime.Now
                };
                await _historyContext.Histories.AddAsync(history);
                await _historyContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }

        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var histories = await _historyContext.Histories
                .Where(h=>h.UserId==id)
                .ToListAsync();
            return Ok(histories);
        }

        [HttpGet("chart/{id}")]
        public async Task<IActionResult> GetChart(string id)
        {
            var histories = await _historyContext.Histories
                .Where(h => h.UserId == id)
                .OrderByDescending(h=>h.Id)
                .ToListAsync();
            return Ok(histories.Take(10).Reverse());
        }
    }
}