# Quickstart: Run the RSS subscription management MVP

## Prerequisites

- .NET SDK 8.0 or later installed on macOS, Windows, or Linux.
- A terminal with access to the repository root.

## Intended setup

This feature is designed for an ASP.NET Core Web API backend and a Blazor WebAssembly frontend. Implementation will use the following directories once scaffolded:

- `backend/` for the API service
- `frontend/` for the Blazor WebAssembly UI

## Local run steps

1. Open a terminal at the repository root.
2. Start the backend API:

```bash
cd backend/RSSFeedReader.Api
dotnet run
```

3. Start the frontend UI:

```bash
cd frontend/RSSFeedReader.UI
dotnet run
```

4. In a browser, navigate to the frontend URL shown by the Blazor app.
5. Use the UI to paste a feed URL and add it.
6. Confirm the subscription appears immediately in the list.

## Notes

- Backend and frontend ports must be coordinated via backend CORS settings and frontend configuration.
- For MVP, the app does not fetch or parse feed contents; it only manages subscription URLs in memory.
- If the implementation differs from this scaffold, update this quickstart to reflect the actual run commands and ports.
