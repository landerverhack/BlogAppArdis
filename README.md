# BlogAppArdis

A Blazor blog application using EF Core for data access.

## Entities

- **Blog** — A blog site. Key properties: `Name`, `Description`, `CreatedDate`, `UpdatedDate`. Relationships: one-to-many with `Post`, many-to-many with `Author`.
- **Post** — A single post within a blog. Key properties: `Title`, `Content`, `CreatedDate`, `UpdatedDate`. Relationships: many-to-one with `Blog`.
- **Author** — A person who can write for one or more blogs. Key properties: `FirstName`, `LastName`, `Email`, `CreatedDate`, `UpdatedDate`. Relationships: many-to-many with `Blog` (via the `BlogAuthor` join table).
