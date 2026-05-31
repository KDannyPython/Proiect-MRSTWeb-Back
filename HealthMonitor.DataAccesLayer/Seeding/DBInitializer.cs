using HealthMonitor.DataAccesLayer.Context;
using HealthMonitor.Domain.Entities.Exercise;

namespace HealthMonitor.DataAccesLayer.Seeding;

public static class DbInitializer
{
    public static void SeedExercises()
    {
        using var context = new AppDbContext();
        // Iterăm prin listă și adăugăm doar ce lipsește

        var exercises = new List<Exercise>
        {
            // CHEST
            new Exercise { Name = "Barbell Bench Press", PrimaryMuscleGroup = MuscleGroup.Chest, SecondaryMuscleGroup = "Triceps,Shoulders", Difficulty = Difficulty.Advanced },
            new Exercise { Name = "Incline Dumbbell Press", PrimaryMuscleGroup = MuscleGroup.Chest, SecondaryMuscleGroup = "Triceps,Shoulders", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Cable Flye", PrimaryMuscleGroup = MuscleGroup.Chest, SecondaryMuscleGroup = "Shoulders", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Push Up", PrimaryMuscleGroup = MuscleGroup.Chest, SecondaryMuscleGroup = "Triceps,Shoulders", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Chest Dip", PrimaryMuscleGroup = MuscleGroup.Chest, SecondaryMuscleGroup = "Triceps", Difficulty = Difficulty.Intermediate },

            // BACK
            new Exercise { Name = "Deadlift", PrimaryMuscleGroup = MuscleGroup.Back, SecondaryMuscleGroup = "Glutes,Hamstrings,Traps", Difficulty = Difficulty.Advanced },
            new Exercise { Name = "Pull Up", PrimaryMuscleGroup = MuscleGroup.Lats, SecondaryMuscleGroup = "Biceps,Traps", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Barbell Row", PrimaryMuscleGroup = MuscleGroup.Back, SecondaryMuscleGroup = "Biceps,Lats", Difficulty = Difficulty.Advanced },
            new Exercise { Name = "Seated Cable Row", PrimaryMuscleGroup = MuscleGroup.Back, SecondaryMuscleGroup = "Biceps", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Lat Pulldown", PrimaryMuscleGroup = MuscleGroup.Lats, SecondaryMuscleGroup = "Biceps", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "T-Bar Row", PrimaryMuscleGroup = MuscleGroup.Back, SecondaryMuscleGroup = "Biceps,Lats", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Face Pull", PrimaryMuscleGroup = MuscleGroup.Shoulders, SecondaryMuscleGroup = "Traps", Difficulty = Difficulty.Beginner },

            // SHOULDERS
            new Exercise { Name = "Overhead Press", PrimaryMuscleGroup = MuscleGroup.Shoulders, SecondaryMuscleGroup = "Triceps,Traps", Difficulty = Difficulty.Advanced },
            new Exercise { Name = "Dumbbell Lateral Raise", PrimaryMuscleGroup = MuscleGroup.Shoulders, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Arnold Press", PrimaryMuscleGroup = MuscleGroup.Shoulders, SecondaryMuscleGroup = "Triceps", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Rear Delt Flye", PrimaryMuscleGroup = MuscleGroup.Shoulders, SecondaryMuscleGroup = "Traps", Difficulty = Difficulty.Beginner },

            // BICEPS
            new Exercise { Name = "Barbell Curl", PrimaryMuscleGroup = MuscleGroup.Biceps, SecondaryMuscleGroup = "Forearms", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Incline Dumbbell Curl", PrimaryMuscleGroup = MuscleGroup.Biceps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Hammer Curl", PrimaryMuscleGroup = MuscleGroup.Biceps, SecondaryMuscleGroup = "Forearms", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Preacher Curl", PrimaryMuscleGroup = MuscleGroup.Biceps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Cable Curl", PrimaryMuscleGroup = MuscleGroup.Biceps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },

            // TRICEPS
            new Exercise { Name = "Tricep Pushdown", PrimaryMuscleGroup = MuscleGroup.Triceps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Overhead Tricep Extension", PrimaryMuscleGroup = MuscleGroup.Triceps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Skull Crusher", PrimaryMuscleGroup = MuscleGroup.Triceps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Close Grip Bench Press", PrimaryMuscleGroup = MuscleGroup.Triceps, SecondaryMuscleGroup = "Chest", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Diamond Push Up", PrimaryMuscleGroup = MuscleGroup.Triceps, SecondaryMuscleGroup = "Chest", Difficulty = Difficulty.Beginner },

            // QUADS / LEGS
            new Exercise { Name = "Barbell Back Squat", PrimaryMuscleGroup = MuscleGroup.Quads, SecondaryMuscleGroup = "Glutes,Hamstrings", Difficulty = Difficulty.Advanced },
            new Exercise { Name = "Leg Press", PrimaryMuscleGroup = MuscleGroup.Quads, SecondaryMuscleGroup = "Glutes", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Leg Extension", PrimaryMuscleGroup = MuscleGroup.Quads, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Bulgarian Split Squat", PrimaryMuscleGroup = MuscleGroup.Quads, SecondaryMuscleGroup = "Glutes,Hamstrings", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Hack Squat", PrimaryMuscleGroup = MuscleGroup.Quads, SecondaryMuscleGroup = "Glutes", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Goblet Squat", PrimaryMuscleGroup = MuscleGroup.Quads, SecondaryMuscleGroup = "Glutes", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Lunges", PrimaryMuscleGroup = MuscleGroup.Quads, SecondaryMuscleGroup = "Glutes,Hamstrings", Difficulty = Difficulty.Beginner },

            // HAMSTRINGS / GLUTES
            new Exercise { Name = "Romanian Deadlift", PrimaryMuscleGroup = MuscleGroup.Hamstrings, SecondaryMuscleGroup = "Glutes,Back", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Leg Curl", PrimaryMuscleGroup = MuscleGroup.Hamstrings, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Hip Thrust", PrimaryMuscleGroup = MuscleGroup.Glutes, SecondaryMuscleGroup = "Hamstrings", Difficulty = Difficulty.Beginner },

            // CALVES
            new Exercise { Name = "Standing Calf Raise", PrimaryMuscleGroup = MuscleGroup.Calves, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Seated Calf Raise", PrimaryMuscleGroup = MuscleGroup.Calves, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },

            // ABS
            new Exercise { Name = "Plank", PrimaryMuscleGroup = MuscleGroup.Abs, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Cable Crunch", PrimaryMuscleGroup = MuscleGroup.Abs, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Hanging Leg Raise", PrimaryMuscleGroup = MuscleGroup.Abs, SecondaryMuscleGroup = null, Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Ab Wheel Rollout", PrimaryMuscleGroup = MuscleGroup.Abs, SecondaryMuscleGroup = null, Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Russian Twist", PrimaryMuscleGroup = MuscleGroup.Abs, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },

            // TRAPS
            new Exercise { Name = "Barbell Shrug", PrimaryMuscleGroup = MuscleGroup.Traps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Dumbbell Shrug", PrimaryMuscleGroup = MuscleGroup.Traps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Farmer's Walk", PrimaryMuscleGroup = MuscleGroup.Forearms, SecondaryMuscleGroup = "Traps", Difficulty = Difficulty.Beginner },

            // FOREARMS
            new Exercise { Name = "Wrist Curl", PrimaryMuscleGroup = MuscleGroup.Forearms, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Reverse Wrist Curl", PrimaryMuscleGroup = MuscleGroup.Forearms, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },

            // NECK
            new Exercise { Name = "Neck Curl", PrimaryMuscleGroup = MuscleGroup.Neck, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },

            // FULL BODY / COMPOUND
            new Exercise { Name = "Clean and Press", PrimaryMuscleGroup = MuscleGroup.Shoulders, SecondaryMuscleGroup = "Back,Quads,Glutes", Difficulty = Difficulty.Advanced },
            new Exercise { Name = "Thruster", PrimaryMuscleGroup = MuscleGroup.Quads, SecondaryMuscleGroup = "Shoulders,Glutes", Difficulty = Difficulty.Advanced },
        };

        foreach (var ex in exercises)
        {
            if (!context.Exercises.Any(e => e.Name == ex.Name))
            {
                context.Exercises.Add(ex);
            }
        }
        context.SaveChanges();
    }
}
