using DietPlannerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DietPlannerAPI.Data
{
    public class DietPlannerDbContext : DbContext
    {
        public DietPlannerDbContext(DbContextOptions<DietPlannerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Meal> Meals { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DietPlan> DietPlans { get; set; }
        public DbSet<DayPlan> DayPlans { get; set; }
        public DbSet<Dietitian> Dietitians { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MealIngredient> MealIngredients { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<BodyMeasurement> BodyMeasurements { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<WaterIntake> WaterIntakes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MealIngredient>()
                .HasKey(mi => new { mi.MealId, mi.IngredientId });

            modelBuilder.Entity<MealIngredient>()
                .HasOne(mi => mi.Meal)
                .WithMany(m => m.MealIngredients)
                .HasForeignKey(mi => mi.MealId);

            modelBuilder.Entity<MealIngredient>()
                .HasOne(mi => mi.Ingredient)
                .WithMany(i => i.MealIngredients)
                .HasForeignKey(mi => mi.IngredientId);

            modelBuilder.Entity<MealIngredient>()
                .Property(mi => mi.QuantityGrams)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Śniadanie" },
                new Category { Id = 2, Name = "Obiad" },
                new Category { Id = 3, Name = "Kolacja" },
                new Category { Id = 4, Name = "Drugie śniadanie" },
                new Category { Id = 5, Name = "Lunch" },
                new Category { Id = 6, Name = "Podwieczorek" },
                new Category { Id = 7, Name = "Przekąska" }
            );

            modelBuilder.Entity<UserProfile>().HasData(
                new UserProfile
                {
                    Id = 1,
                    FullName = "Jan Testowy",
                    Gender = "Mężczyzna",
                    Age = 28,
                    HeightCm = 178
                },
                new UserProfile
                {
                    Id = 2,
                    FullName = "Babcia Maria",
                    Gender = "Kobieta",
                    Age = 72,
                    HeightCm = 164
                }
            );

            modelBuilder.Entity<Meal>().HasData(
                new Meal { Id = 1, Name = "Owsianka z owocami", Description = "Płatki owsiane z bananem i jogurtem", CategoryId = 1, Calories = 420, Protein = 18m, Carbs = 62m, Fat = 10m, Sugar = 18m },
                new Meal { Id = 2, Name = "Sałatka z kurczakiem", Description = "Lekki posiłek z warzywami i grillowanym kurczakiem", CategoryId = 2, Calories = 560, Protein = 42m, Carbs = 28m, Fat = 25m, Sugar = 8m },
                new Meal { Id = 3, Name = "Kanapki z twarożkiem", Description = "Pełnoziarniste pieczywo z twarożkiem i warzywami", CategoryId = 3, Calories = 390, Protein = 24m, Carbs = 48m, Fat = 12m, Sugar = 6m }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Płatki owsiane", Calories = 370, Protein = 13m, Carbs = 60m, Fat = 7m, Sugar = 1m },
                new Ingredient { Id = 2, Name = "Banan", Calories = 89, Protein = 1m, Carbs = 23m, Fat = 0m, Sugar = 12m },
                new Ingredient { Id = 3, Name = "Kurczak", Calories = 165, Protein = 31m, Carbs = 0m, Fat = 4m, Sugar = 0m },
                new Ingredient { Id = 4, Name = "Sałata", Calories = 15, Protein = 1m, Carbs = 3m, Fat = 0m, Sugar = 1m },
                new Ingredient { Id = 5, Name = "Twaróg", Calories = 98, Protein = 11m, Carbs = 3m, Fat = 5m, Sugar = 3m }
            );

            modelBuilder.Entity<MealIngredient>().HasData(
                new MealIngredient { MealId = 1, IngredientId = 1, QuantityGrams = 70m },
                new MealIngredient { MealId = 1, IngredientId = 2, QuantityGrams = 120m },
                new MealIngredient { MealId = 2, IngredientId = 3, QuantityGrams = 150m },
                new MealIngredient { MealId = 2, IngredientId = 4, QuantityGrams = 100m },
                new MealIngredient { MealId = 3, IngredientId = 5, QuantityGrams = 120m }
            );

            modelBuilder.Entity<DietPlan>().HasData(
                new DietPlan { Id = 1, Name = "Plan redukcyjny" },
                new DietPlan { Id = 2, Name = "Plan zdrowego odżywiania" }
            );

            modelBuilder.Entity<DayPlan>().HasData(
                new DayPlan { Id = 1, DayName = "Poniedziałek", PlanDate = new DateTime(2026, 5, 11, 8, 0, 0), MealTime = "Śniadanie", Notes = "Bez dodatkowego cukru", UserProfileId = 1, MealId = 1, DietPlanId = null },
                new DayPlan { Id = 2, DayName = "Poniedziałek", PlanDate = new DateTime(2026, 5, 11, 13, 0, 0), MealTime = "Obiad", Notes = "Dodać więcej warzyw", UserProfileId = 1, MealId = 2, DietPlanId = null },
                new DayPlan { Id = 3, DayName = "Wtorek", PlanDate = new DateTime(2026, 5, 12, 18, 0, 0), MealTime = "Kolacja", Notes = "Lekka kolacja po spacerze", UserProfileId = 2, MealId = 3, DietPlanId = null }
            );

            modelBuilder.Entity<Dietitian>().HasData(
                new Dietitian { Id = 1, FullName = "Anna Kowalska", Specialization = "Dietetyka kliniczna" },
                new Dietitian { Id = 2, FullName = "Michał Nowak", Specialization = "Dietetyka sportowa" }
            );

            modelBuilder.Entity<TimeSlot>().HasData(
                new TimeSlot { Id = 1, StartTime = new DateTime(2026, 5, 10, 10, 0, 0), IsAvailable = false, DietitianId = 1 },
                new TimeSlot { Id = 2, StartTime = new DateTime(2026, 5, 10, 12, 0, 0), IsAvailable = true, DietitianId = 1 },
                new TimeSlot { Id = 3, StartTime = new DateTime(2026, 5, 11, 9, 0, 0), IsAvailable = true, DietitianId = 2 },
                new TimeSlot { Id = 4, StartTime = new DateTime(2026, 5, 12, 10, 0, 0), IsAvailable = true, DietitianId = 1 },
                new TimeSlot { Id = 5, StartTime = new DateTime(2026, 5, 12, 16, 0, 0), IsAvailable = true, DietitianId = 2 },
                new TimeSlot { Id = 6, StartTime = new DateTime(2026, 5, 13, 11, 30, 0), IsAvailable = true, DietitianId = 1 },
                new TimeSlot { Id = 7, StartTime = new DateTime(2026, 5, 14, 14, 0, 0), IsAvailable = true, DietitianId = 2 },
                new TimeSlot { Id = 8, StartTime = new DateTime(2026, 5, 15, 9, 30, 0), IsAvailable = true, DietitianId = 1 }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, PatientName = "Jan Testowy", AppointmentDate = new DateTime(2026, 5, 10, 10, 0, 0), DietitianId = 1, UserProfileId = 1 }
            );

            modelBuilder.Entity<BodyMeasurement>().HasData(
                new BodyMeasurement { Id = 1, WeightKg = 82.5m, Bmi = 26.0m, MeasurementDate = new DateTime(2026, 5, 7), UserProfileId = 1 },
                new BodyMeasurement { Id = 2, WeightKg = 81.8m, Bmi = 25.8m, MeasurementDate = new DateTime(2026, 5, 14), UserProfileId = 1 },
                new BodyMeasurement { Id = 3, WeightKg = 68.2m, Bmi = 25.4m, MeasurementDate = new DateTime(2026, 5, 7), UserProfileId = 2 }
            );

            modelBuilder.Entity<Goal>().HasData(
                new Goal { Id = 1, GoalType = "Redukcja", TargetWeightKg = 76.0m, Description = "Stopniowa redukcja masy ciała przy zachowaniu zdrowych nawyków.", UserProfileId = 1 },
                new Goal { Id = 2, GoalType = "Zdrowsze odżywianie", TargetWeightKg = 66.0m, Description = "Regularne posiłki i ograniczenie cukru.", UserProfileId = 2 }
            );

            modelBuilder.Entity<WaterIntake>().HasData(
                new WaterIntake { Id = 1, DrinkDate = new DateTime(2026, 5, 11, 9, 0, 0), AmountMl = 300, Notes = "Szklanka wody po śniadaniu", UserProfileId = 1 },
                new WaterIntake { Id = 2, DrinkDate = new DateTime(2026, 5, 11, 13, 30, 0), AmountMl = 500, Notes = "Woda do obiadu", UserProfileId = 1 },
                new WaterIntake { Id = 3, DrinkDate = new DateTime(2026, 5, 11, 16, 0, 0), AmountMl = 250, Notes = "Herbata bez cukru", UserProfileId = 1 }
            );
        }
    }
}
