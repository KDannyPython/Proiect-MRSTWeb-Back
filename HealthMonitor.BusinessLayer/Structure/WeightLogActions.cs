using HealthMonitor.DataAccesLayer.Context;
using HealthMonitor.Domain.Entities.User;
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.User;
using Microsoft.EntityFrameworkCore;

namespace HealthMonitor.BusinessLayer.Structure
{
    public class WeightLogActions
    {
        protected async Task<ServiceResponse> LogWeightAction(int userId, WeightLogDto dto)
        {
            try
            {
                using var _context = new AppDbContext();

                // Find user and update their current weight
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                if (user == null)
                {
                    return new ServiceResponse { IsSuccess = false, Message = "User not found." };
                }

                // Make sure weight is valid
                if (dto.Weight < 10 || dto.Weight > 500)
                {
                    return new ServiceResponse { IsSuccess = false, Message = "Invalid weight value." };
                }

                // Update user profile weight
                user.Weight = (int)Math.Round(dto.Weight);

                // Add to history log
                var log = new WeightLogEntity
                {
                    UserId = userId,
                    Weight = dto.Weight,
                    LoggedAt = dto.LoggedAt == default ? DateTime.UtcNow : dto.LoggedAt
                };

                _context.WeightLogs.Add(log);
                await _context.SaveChangesAsync();

                return new ServiceResponse { IsSuccess = true, Message = "Weight logged successfully." };
            }
            catch (Exception ex)
            {
                return new ServiceResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        protected async Task<List<WeightLogResponseDto>> GetWeightHistoryAction(int userId, int? limit)
        {
            try
            {
                using var _context = new AppDbContext();
                
                var query = _context.WeightLogs
                    .Where(w => w.UserId == userId)
                    .OrderBy(w => w.LoggedAt) // Ascending order (oldest first) so frontend charts draw left to right
                    .AsQueryable();

                if (limit.HasValue)
                {
                    // For limit, we want the most recent N, but still ordered ascending.
                    // EF doesn't support TakeLast easily, so we order desc, take N, then order asc in memory
                    var logs = await query.OrderByDescending(w => w.LoggedAt).Take(limit.Value).ToListAsync();
                    return logs.OrderBy(w => w.LoggedAt).Select(w => new WeightLogResponseDto
                    {
                        Id = w.Id,
                        Weight = w.Weight,
                        LoggedAt = w.LoggedAt
                    }).ToList();
                }

                var allLogs = await query.ToListAsync();
                return allLogs.Select(w => new WeightLogResponseDto
                {
                    Id = w.Id,
                    Weight = w.Weight,
                    LoggedAt = w.LoggedAt
                }).ToList();
            }
            catch
            {
                return new List<WeightLogResponseDto>();
            }
        }
    }
}
