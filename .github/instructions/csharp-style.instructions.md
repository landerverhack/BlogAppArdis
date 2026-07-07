---
description: "Use when writing or editing C# code in this project. Covers general style: namespaces, constructors, nullability."
applyTo: "**/*.cs"
---
# C# Style Conventions

- Use **file-scoped namespaces** (`namespace BlogAppArdis.Data;`) rather than block-scoped namespaces.
- Prefer **primary constructors** for simple dependency injection (e.g. `public class BlogDbContext(DbContextOptions<BlogDbContext> options) : DbContext(options)`) instead of a constructor body that just assigns fields.
- Avoid nullable reference warnings by initializing non-nullable properties: use `= string.Empty;` for strings and `= null!;` only when a value is guaranteed to be set before use (e.g. required navigation properties).
- Put small, focused extension methods in a `static class` named `{Type}Extensions` (see [HostApplicationBuilderExtensions.cs](../../BlogAppArdis/Data/HostApplicationBuilderExtensions.cs)), and add an XML doc comment summarizing what is registered/returned.
- Keep `Program.cs` a thin composition root: push reusable setup logic (like DB registration) into extension methods rather than inlining it.
- Prefer using records for DTOs
