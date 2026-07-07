---
description: "Use when working with the data layer - EF Core entities, DbContext, entity configurations, or migrations. Covers naming, fluent configuration, and registration patterns."
applyTo: "BlogAppArdis/Data/**"
---
# EF Core / Data Layer Conventions

- Entities (e.g. [Blog.cs](../../BlogAppArdis/Data/Blog.cs), [Post.cs](../../BlogAppArdis/Data/Post.cs)) are plain classes in `BlogAppArdis.Data`:
  - Default `string` properties to `string.Empty`, not nullable, unless the field is genuinely optional.
  - Default `CreatedDate` to `DateTime.UtcNow`; use nullable `DateTime?` for optional dates like `UpdatedDate`.
  - Mark foreign key and navigation properties with a `// Foreign key` / `// Navigation property` comment above them.
  - Non-nullable required navigation properties use `= null!;` rather than making the property nullable.
- Never configure entities with data annotations or inline `OnModelCreating` lambdas. Add a new `IEntityTypeConfiguration<T>` class per entity under `Data/Configurations/`, named `{Entity}Configuration.cs`, and register it in `BlogDbContext.OnModelCreating` via `modelBuilder.ApplyConfiguration(new {Entity}Configuration())`.
- In each configuration class, set the key first, then required/max-length constraints, then relationships (`HasOne`/`HasMany`) with an explicit `OnDelete` behavior — follow the structure in [PostConfiguration.cs](../../BlogAppArdis/Data/Configurations/PostConfiguration.cs).
- `BlogDbContext` uses a primary constructor (`public class BlogDbContext(DbContextOptions<BlogDbContext> options) : DbContext(options)`); keep new `DbContext` types consistent with this style.
- Register new `DbContext` types via the `AddDbContextForSqlite<TContext>()` extension in [HostApplicationBuilderExtensions.cs](../../BlogAppArdis/Data/HostApplicationBuilderExtensions.cs) rather than calling `AddDbContext` directly in `Program.cs`.
- After changing an entity or configuration, remind the user to add an EF Core migration (`dotnet ef migrations add <Name>`) rather than relying solely on `EnsureCreated()`.
