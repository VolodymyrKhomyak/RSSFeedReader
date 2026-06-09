# API Contract: Subscription management

## API Overview

The backend exposes a minimal REST API for managing subscriptions during the current session.

## Endpoints

### GET /api/subscriptions

- **Purpose**: Retrieve the current list of subscriptions.
- **Response**:
  - `200 OK`
  - Body: JSON array of subscription objects

```json
[
  {
    "url": "https://example.com/feed.xml"
  }
]
```

### POST /api/subscriptions

- **Purpose**: Add a new subscription to the current session.
- **Request Body**:
  - `url`: string

```json
{
  "url": "https://example.com/feed.xml"
}
```

- **Response**:
  - `201 Created` on success
  - `400 Bad Request` if the request body is missing `url` or if it is empty

## Data Contract

### Subscription object

- `url` (string): The feed URL entered by the user.

## Notes

- The MVP contract does not include feed validation, parsing, or item endpoints.
- The API is intended for local use by the frontend app only.
- Future versions may expose additional fields such as `addedAt`, `title`, or `isActive`.
