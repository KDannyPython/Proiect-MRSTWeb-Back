using HealthMonitor.DataAccesLayer.Context;
using HealthMonitor.Domain.Entities.Exercise;
using HealthMonitor.Domain.Entities.User;
using System.Security.Cryptography;
using System.Text;

namespace HealthMonitor.DataAccesLayer.Seeding;

public static class DbInitializer
{
    // Hash SHA256 identic cu logica din PasswordHasher.cs din BusinessLayer
    private static string GenerateSalt()
        => Convert.ToBase64String(RandomNumberGenerator.GetBytes(16));

    private static string HashPassword(string password, string salt)
    {
        var bytes = Encoding.UTF8.GetBytes(password + salt);
        var hashBytes = SHA256.HashData(bytes);
        var sb = new StringBuilder();
        foreach (var b in hashBytes)
            sb.Append(b.ToString("x2"));
        return sb.ToString();
    }

    public static void SeedExercises()
    {
        using var context = new AppDbContext();
        // Iterăm prin listă și adăugăm doar ce lipsește

        var exercises = new List<Exercise>
        {
            // CHEST
            new Exercise { Name = "Barbell Bench Press", PrimaryMuscleGroup = MuscleGroup.Chest, SecondaryMuscleGroup = "Triceps,Shoulders", Difficulty = Difficulty.Advanced },
            new Exercise { Name = "Incline Dumbbell Press", PrimaryMuscleGroup = MuscleGroup.Chest, SecondaryMuscleGroup = "Triceps,Shoulders", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Flat Dumbbell Press", PrimaryMuscleGroup = MuscleGroup.Chest, SecondaryMuscleGroup = "Triceps,Shoulders", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Decline Bench Press", PrimaryMuscleGroup = MuscleGroup.Chest, SecondaryMuscleGroup = "Triceps,Shoulders", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Cable Flye", PrimaryMuscleGroup = MuscleGroup.Chest, SecondaryMuscleGroup = "Shoulders", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Pec Deck Fly", PrimaryMuscleGroup = MuscleGroup.Chest, SecondaryMuscleGroup = "Shoulders", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Incline Cable Fly", PrimaryMuscleGroup = MuscleGroup.Chest, SecondaryMuscleGroup = "Shoulders", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Push Up", PrimaryMuscleGroup = MuscleGroup.Chest, SecondaryMuscleGroup = "Triceps,Shoulders", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Chest Dip", PrimaryMuscleGroup = MuscleGroup.Chest, SecondaryMuscleGroup = "Triceps", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Dumbbell Pullover", PrimaryMuscleGroup = MuscleGroup.Chest, SecondaryMuscleGroup = "Lats", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Svend Press", PrimaryMuscleGroup = MuscleGroup.Chest, SecondaryMuscleGroup = "Shoulders", Difficulty = Difficulty.Intermediate },

            // BACK
            new Exercise { Name = "Deadlift", PrimaryMuscleGroup = MuscleGroup.Back, SecondaryMuscleGroup = "Glutes,Hamstrings,Traps", Difficulty = Difficulty.Advanced },
            new Exercise { Name = "Pull Up", PrimaryMuscleGroup = MuscleGroup.Lats, SecondaryMuscleGroup = "Biceps,Traps", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Chin Up", PrimaryMuscleGroup = MuscleGroup.Lats, SecondaryMuscleGroup = "Biceps", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Barbell Row", PrimaryMuscleGroup = MuscleGroup.Back, SecondaryMuscleGroup = "Biceps,Lats", Difficulty = Difficulty.Advanced },
            new Exercise { Name = "Single Arm Dumbbell Row", PrimaryMuscleGroup = MuscleGroup.Back, SecondaryMuscleGroup = "Biceps,Lats", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "T-Bar Row", PrimaryMuscleGroup = MuscleGroup.Back, SecondaryMuscleGroup = "Biceps,Lats", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Seated Cable Row", PrimaryMuscleGroup = MuscleGroup.Back, SecondaryMuscleGroup = "Biceps", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Lat Pulldown", PrimaryMuscleGroup = MuscleGroup.Lats, SecondaryMuscleGroup = "Biceps", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Straight Arm Pulldown", PrimaryMuscleGroup = MuscleGroup.Lats, SecondaryMuscleGroup = "Shoulders", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Reverse Grip Bent-Over Row", PrimaryMuscleGroup = MuscleGroup.Back, SecondaryMuscleGroup = "Biceps,Lats", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Back Extension", PrimaryMuscleGroup = MuscleGroup.Back, SecondaryMuscleGroup = "Glutes,Hamstrings", Difficulty = Difficulty.Beginner },

            // SHOULDERS
            new Exercise { Name = "Overhead Press", PrimaryMuscleGroup = MuscleGroup.Shoulders, SecondaryMuscleGroup = "Triceps,Traps", Difficulty = Difficulty.Advanced },
            new Exercise { Name = "Dumbbell Shoulder Press", PrimaryMuscleGroup = MuscleGroup.Shoulders, SecondaryMuscleGroup = "Triceps", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Arnold Press", PrimaryMuscleGroup = MuscleGroup.Shoulders, SecondaryMuscleGroup = "Triceps", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Dumbbell Lateral Raise", PrimaryMuscleGroup = MuscleGroup.Shoulders, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Cable Lateral Raise", PrimaryMuscleGroup = MuscleGroup.Shoulders, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Front Raise", PrimaryMuscleGroup = MuscleGroup.Shoulders, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Upright Row", PrimaryMuscleGroup = MuscleGroup.Shoulders, SecondaryMuscleGroup = "Traps", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Rear Delt Flye", PrimaryMuscleGroup = MuscleGroup.Shoulders, SecondaryMuscleGroup = "Traps", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Face Pull", PrimaryMuscleGroup = MuscleGroup.Shoulders, SecondaryMuscleGroup = "Traps", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Cable Rear Delt Flye", PrimaryMuscleGroup = MuscleGroup.Shoulders, SecondaryMuscleGroup = "Traps", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Cuban Press", PrimaryMuscleGroup = MuscleGroup.Shoulders, SecondaryMuscleGroup = "Rotators", Difficulty = Difficulty.Intermediate },

            // BICEPS
            new Exercise { Name = "Barbell Curl", PrimaryMuscleGroup = MuscleGroup.Biceps, SecondaryMuscleGroup = "Forearms", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "EZ Bar Curl", PrimaryMuscleGroup = MuscleGroup.Biceps, SecondaryMuscleGroup = "Forearms", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Dumbbell Curl", PrimaryMuscleGroup = MuscleGroup.Biceps, SecondaryMuscleGroup = "Forearms", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Incline Dumbbell Curl", PrimaryMuscleGroup = MuscleGroup.Biceps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Hammer Curl", PrimaryMuscleGroup = MuscleGroup.Biceps, SecondaryMuscleGroup = "Forearms", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Preacher Curl", PrimaryMuscleGroup = MuscleGroup.Biceps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Concentration Curl", PrimaryMuscleGroup = MuscleGroup.Biceps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Cable Curl", PrimaryMuscleGroup = MuscleGroup.Biceps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Spider Curl", PrimaryMuscleGroup = MuscleGroup.Biceps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Zottman Curl", PrimaryMuscleGroup = MuscleGroup.Biceps, SecondaryMuscleGroup = "Forearms", Difficulty = Difficulty.Intermediate },

            // TRICEPS
            new Exercise { Name = "Tricep Pushdown", PrimaryMuscleGroup = MuscleGroup.Triceps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Overhead Tricep Extension", PrimaryMuscleGroup = MuscleGroup.Triceps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Skull Crusher", PrimaryMuscleGroup = MuscleGroup.Triceps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Close Grip Bench Press", PrimaryMuscleGroup = MuscleGroup.Triceps, SecondaryMuscleGroup = "Chest", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Diamond Push Up", PrimaryMuscleGroup = MuscleGroup.Triceps, SecondaryMuscleGroup = "Chest", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Bench Dip", PrimaryMuscleGroup = MuscleGroup.Triceps, SecondaryMuscleGroup = "Chest", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Cable Overhead Rope Extension", PrimaryMuscleGroup = MuscleGroup.Triceps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Reverse Grip Tricep Pushdown", PrimaryMuscleGroup = MuscleGroup.Triceps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Lying Tricep Extension", PrimaryMuscleGroup = MuscleGroup.Triceps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Weighted Tricep Dip", PrimaryMuscleGroup = MuscleGroup.Triceps, SecondaryMuscleGroup = "Chest,Shoulders", Difficulty = Difficulty.Advanced },

            // QUADS / LEGS
            new Exercise { Name = "Barbell Back Squat", PrimaryMuscleGroup = MuscleGroup.Quads, SecondaryMuscleGroup = "Glutes,Hamstrings", Difficulty = Difficulty.Advanced },
            new Exercise { Name = "Front Squat", PrimaryMuscleGroup = MuscleGroup.Quads, SecondaryMuscleGroup = "Glutes,Core", Difficulty = Difficulty.Advanced },
            new Exercise { Name = "Leg Press", PrimaryMuscleGroup = MuscleGroup.Quads, SecondaryMuscleGroup = "Glutes", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Leg Extension", PrimaryMuscleGroup = MuscleGroup.Quads, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Bulgarian Split Squat", PrimaryMuscleGroup = MuscleGroup.Quads, SecondaryMuscleGroup = "Glutes,Hamstrings", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Hack Squat", PrimaryMuscleGroup = MuscleGroup.Quads, SecondaryMuscleGroup = "Glutes", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Goblet Squat", PrimaryMuscleGroup = MuscleGroup.Quads, SecondaryMuscleGroup = "Glutes", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Lunges", PrimaryMuscleGroup = MuscleGroup.Quads, SecondaryMuscleGroup = "Glutes,Hamstrings", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Sissy Squat", PrimaryMuscleGroup = MuscleGroup.Quads, SecondaryMuscleGroup = "Core", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Step Up", PrimaryMuscleGroup = MuscleGroup.Quads, SecondaryMuscleGroup = "Glutes", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Walking Lunge", PrimaryMuscleGroup = MuscleGroup.Quads, SecondaryMuscleGroup = "Glutes,Hamstrings", Difficulty = Difficulty.Intermediate },

            // HAMSTRINGS / GLUTES
            new Exercise { Name = "Romanian Deadlift", PrimaryMuscleGroup = MuscleGroup.Hamstrings, SecondaryMuscleGroup = "Glutes,Back", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Good Morning", PrimaryMuscleGroup = MuscleGroup.Hamstrings, SecondaryMuscleGroup = "Back,Glutes", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Single Leg Romanian Deadlift", PrimaryMuscleGroup = MuscleGroup.Hamstrings, SecondaryMuscleGroup = "Glutes", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Hip Thrust", PrimaryMuscleGroup = MuscleGroup.Glutes, SecondaryMuscleGroup = "Hamstrings", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Glute Bridge", PrimaryMuscleGroup = MuscleGroup.Glutes, SecondaryMuscleGroup = "Hamstrings", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Cable Pull-Through", PrimaryMuscleGroup = MuscleGroup.Glutes, SecondaryMuscleGroup = "Hamstrings", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Kettlebell Swing", PrimaryMuscleGroup = MuscleGroup.Glutes, SecondaryMuscleGroup = "Hamstrings,Back", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Nordic Hamstring Curl", PrimaryMuscleGroup = MuscleGroup.Hamstrings, SecondaryMuscleGroup = null, Difficulty = Difficulty.Advanced },
            new Exercise { Name = "Reverse Lunge", PrimaryMuscleGroup = MuscleGroup.Glutes, SecondaryMuscleGroup = "Hamstrings,Quads", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Stiff Leg Deadlift", PrimaryMuscleGroup = MuscleGroup.Hamstrings, SecondaryMuscleGroup = "Glutes", Difficulty = Difficulty.Intermediate },

            // CALVES
            new Exercise { Name = "Standing Calf Raise", PrimaryMuscleGroup = MuscleGroup.Calves, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Seated Calf Raise", PrimaryMuscleGroup = MuscleGroup.Calves, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Donkey Calf Raise", PrimaryMuscleGroup = MuscleGroup.Calves, SecondaryMuscleGroup = null, Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Smith Machine Calf Raise", PrimaryMuscleGroup = MuscleGroup.Calves, SecondaryMuscleGroup = null, Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Tibialis Raise", PrimaryMuscleGroup = MuscleGroup.Calves, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Calf Press on Leg Press", PrimaryMuscleGroup = MuscleGroup.Calves, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Jump Rope", PrimaryMuscleGroup = MuscleGroup.Calves, SecondaryMuscleGroup = "Cardio", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Single Leg Calf Raise", PrimaryMuscleGroup = MuscleGroup.Calves, SecondaryMuscleGroup = null, Difficulty = Difficulty.Intermediate },

            // ABS
            new Exercise { Name = "Plank", PrimaryMuscleGroup = MuscleGroup.Abs, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Cable Crunch", PrimaryMuscleGroup = MuscleGroup.Abs, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Hanging Leg Raise", PrimaryMuscleGroup = MuscleGroup.Abs, SecondaryMuscleGroup = null, Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Ab Wheel Rollout", PrimaryMuscleGroup = MuscleGroup.Abs, SecondaryMuscleGroup = null, Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Russian Twist", PrimaryMuscleGroup = MuscleGroup.Abs, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Bicycle Crunch", PrimaryMuscleGroup = MuscleGroup.Abs, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "V-Up", PrimaryMuscleGroup = MuscleGroup.Abs, SecondaryMuscleGroup = null, Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Reverse Crunch", PrimaryMuscleGroup = MuscleGroup.Abs, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Side Plank", PrimaryMuscleGroup = MuscleGroup.Abs, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Mountain Climber", PrimaryMuscleGroup = MuscleGroup.Abs, SecondaryMuscleGroup = "Cardio", Difficulty = Difficulty.Beginner },

            // TRAPS
            new Exercise { Name = "Barbell Shrug", PrimaryMuscleGroup = MuscleGroup.Traps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Dumbbell Shrug", PrimaryMuscleGroup = MuscleGroup.Traps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Farmer's Walk", PrimaryMuscleGroup = MuscleGroup.Forearms, SecondaryMuscleGroup = "Traps", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Upright Row", PrimaryMuscleGroup = MuscleGroup.Traps, SecondaryMuscleGroup = "Shoulders", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Cable Shrug", PrimaryMuscleGroup = MuscleGroup.Traps, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Rack Pull", PrimaryMuscleGroup = MuscleGroup.Traps, SecondaryMuscleGroup = "Back", Difficulty = Difficulty.Intermediate },

            // FOREARMS
            new Exercise { Name = "Wrist Curl", PrimaryMuscleGroup = MuscleGroup.Forearms, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Reverse Wrist Curl", PrimaryMuscleGroup = MuscleGroup.Forearms, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Farmer's Carry", PrimaryMuscleGroup = MuscleGroup.Forearms, SecondaryMuscleGroup = "Traps", Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Plate Pinch", PrimaryMuscleGroup = MuscleGroup.Forearms, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Wrist Roller", PrimaryMuscleGroup = MuscleGroup.Forearms, SecondaryMuscleGroup = null, Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Reverse Curl", PrimaryMuscleGroup = MuscleGroup.Forearms, SecondaryMuscleGroup = "Biceps", Difficulty = Difficulty.Intermediate },

            // NECK
            new Exercise { Name = "Neck Curl", PrimaryMuscleGroup = MuscleGroup.Neck, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Neck Bridge", PrimaryMuscleGroup = MuscleGroup.Neck, SecondaryMuscleGroup = null, Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Lateral Neck Raise", PrimaryMuscleGroup = MuscleGroup.Neck, SecondaryMuscleGroup = null, Difficulty = Difficulty.Beginner },
            new Exercise { Name = "Prone Neck Extensions", PrimaryMuscleGroup = MuscleGroup.Neck, SecondaryMuscleGroup = null, Difficulty = Difficulty.Intermediate },

            // FULL BODY / COMPOUND
            new Exercise { Name = "Clean and Press", PrimaryMuscleGroup = MuscleGroup.Shoulders, SecondaryMuscleGroup = "Back,Quads,Glutes", Difficulty = Difficulty.Advanced },
            new Exercise { Name = "Thruster", PrimaryMuscleGroup = MuscleGroup.Quads, SecondaryMuscleGroup = "Shoulders,Glutes", Difficulty = Difficulty.Advanced },
            new Exercise { Name = "Kettlebell Swing", PrimaryMuscleGroup = MuscleGroup.Glutes, SecondaryMuscleGroup = "Hamstrings,Back", Difficulty = Difficulty.Intermediate },
            new Exercise { Name = "Burpee", PrimaryMuscleGroup = MuscleGroup.Abs, SecondaryMuscleGroup = "Chest,Legs", Difficulty = Difficulty.Intermediate },
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

    public static void SeedAdmin()
    {
        using var context = new AppDbContext();

        if (!context.Users.Any(u => u.Role == UserRole.Admin))
        {
            var salt = GenerateSalt();
            var hash = HashPassword("admin123", salt);

            context.Users.Add(new UserEntity
            {
                Name = "Admin",
                Email = "admin@healthmonitor.com",
                Password = hash,
                PasswordSalt = salt,
                Role = UserRole.Admin,
                OnboardingCompleted = true,
                TwoFactorEnabled = false,
                RegisteredOn = DateTime.UtcNow
            });

            context.SaveChanges();
        }
    }
}
