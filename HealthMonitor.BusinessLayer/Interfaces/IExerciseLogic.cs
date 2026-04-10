using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.Exercise;

namespace HealthMonitor.BusinessLayer.Interfaces;

public interface IExerciseLogic
{
    ServiceResponse CreateExercise(ExerciseCreateDto exerciseDto);
    ServiceResponse GetExerciseById(int id);
    ServiceResponse GetExerciseList();
    ServiceResponse UpdateExercise(int id, ExerciseCreateDto exerciseDto);
    ServiceResponse DeleteExercise(int id);
}