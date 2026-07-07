---
description: "Use when creating or editing Razor components (.razor) - layouts, pages, and reusable UI. Covers component structure, CSS isolation, and Blazor Server conventions."
applyTo: "**/*.razor"
---
# Blazor Component Conventions

This app uses **Blazor Server** (Interactive Server render mode, configured in `Program.cs`).

- Put `@page` directives on the first line of routable components, followed by a `<PageTitle>` element.
- Use `@inherits` for layout components (see [MainLayout.razor](../../BlogAppArdis/Components/Layout/MainLayout.razor)).
- Style components with **CSS isolation**: create a co-located `ComponentName.razor.css` file instead of global styles in `wwwroot/app.css`, unless the style is truly shared app-wide.
- Keep markup declarative; extract non-trivial C# logic (loops, data fetching, event handlers with more than a couple of lines) into a `@code { }` block at the bottom of the file, or a code-behind `ComponentName.razor.cs` partial class for larger components.
- Use `NavLink` (not plain `<a>`) for in-app navigation so active-route styling works, matching [NavMenu.razor](../../BlogAppArdis/Components/Layout/NavMenu.razor).
- Inject services with `@inject` at the top of the file rather than resolving them manually.
- When a component needs data, inject the `BlogDbContext` (or a scoped service wrapping it) via `@inject` — do not `new` up a `DbContext` directly in a component.
- Prefer parameters (`[Parameter]`) and cascading values over static/global state for passing data between components.
