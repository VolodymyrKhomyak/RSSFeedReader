# Data Model: Subscription management MVP

## Entity: Subscription

- **Description**: Represents a single RSS/Atom feed subscription entered by the user.
- **Fields**:
  - `url` (string): The feed URL provided by the user.
  - `addedAt` (datetime, optional): Timestamp when the subscription was created. Useful for future ordering and auditing if persistence is added.

## Relationships

- No relationships are required for the MVP. Each `Subscription` stands alone in the current session.

## Validation Rules

- While MVP assumes valid URLs, the implementation should still avoid crashing on malformed input.
- For MVP, the backend may accept any non-empty string as a subscription URL.

## Future extension notes

- In Extended-MVP, `Subscription` may gain additional fields such as `title`, `lastFetchedAt`, and `isActive`.
- Persistence could later be implemented with a database table or serialized file format, leaving the current in-memory abstraction intact.
