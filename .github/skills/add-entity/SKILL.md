---
name: add-entity
description: 'Scaffold a new EF Core entity in the blog data layer — POCO class, IEntityTypeConfiguration, DbSet registration, and README update. Use when: adding a new entity, new EF Core entity, new data model, add a table, add a DbSet, add entity configuration, extend the data layer with Comment/Category/Tag/etc.'
argument-hint: 'EntityName: Property1 (type), Property2 (type), ... [relationship to existing entity, e.g. "many-to-one with Blog"]'
---

# Add EF Core Entity

Adds a new entity to `BlogAppArdis/Data`, following the conventions in [efcore-data.instructions.md](../../instructions/efcore-data.instructions.md) and [csharp-style.instructions.md](../../instructions/csharp-style.instructions.md).

## When to Use

- The user wants to add a new EF Core entity/table to the blog data layer (e.g. `Comment`, `Category`, `Tag`).
- The user gives an entity name plus a property list and/or a relationship to an existing entity (`Blog`, `Post`, `Author`).

If the entity name, properties, or relationship aren't provided, ask for them before proceeding.

## Procedure

1. **Create the POCO entity** at `BlogAppArdis/Data/{EntityName}.cs`:
   - Plain class in the `BlogAppArdis.Data` namespace (file-scoped namespace).
   - Default `string` properties to `string.Empty`.
   - Default a `CreatedDate` property to `DateTime.UtcNow`; use nullable `DateTime?` for optional dates like `UpdatedDate`.
   - Mark any foreign key property with a `// Foreign key` comment above it, and any navigation property with a `// Navigation property` comment above it.
   - Non-nullable required navigation properties use `= null!;` rather than being made nullable.
   - No data annotations — mapping is done entirely via fluent API (next step).

2. **Create the configuration class** at `BlogAppArdis/Data/Configurations/{EntityName}Configuration.cs`:
   - Implement `IEntityTypeConfiguration<{EntityName}>`.
   - In `Configure`, set the key first, then required/max-length constraints, then relationships (`HasOne`/`HasMany`) with an explicit `OnDelete` behavior — mirror the structure in [PostConfiguration.cs](../../../BlogAppArdis/Data/Configurations/PostConfiguration.cs).
   - If the new entity relates to an existing entity (e.g. `Blog` or `Post`), add the corresponding navigation collection/property to the other side of the relationship as needed.

3. **Register the DbSet and configuration** in `BlogDbContext` ([BlogDbContext.cs](../../../BlogAppArdis/Data/BlogDbContext.cs)):
   - Add `public DbSet<{EntityName}> {EntityName}s { get; set; }` alongside the existing `DbSet` properties.
   - Add `modelBuilder.ApplyConfiguration(new {EntityName}Configuration());` in `OnModelCreating`.

4. **Update `README.md`** at the repository root:
   - If the file doesn't have an `## Entities` section yet, create one listing the existing entities plus the new one.
   - Add an entry for `{EntityName}` using this template:

     ```
     - **{EntityName}** — {one-line description}. Key properties: `Prop1`, `Prop2`, .... Relationships: {relationship description, e.g. "many-to-one with `Blog`"}.
     ```

5. Remind the user to add an EF Core migration for the change (`dotnet ef migrations add Add{EntityName}`), rather than relying on `EnsureCreated()`.

## Completion Check

- Entity, configuration, `DbSet`, and `OnModelCreating` registration all exist and compile.
- README `## Entities` section includes the new entity using the template above.
- User has been reminded to add a migration.
