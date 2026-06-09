# Research: Subscription management MVP

## Decision
Use ASP.NET Core Web API for the backend and Blazor WebAssembly for the frontend, with in-memory subscription storage only for the MVP.

## Rationale
- Stakeholder documents explicitly describe an ASP.NET Core backend + Blazor WebAssembly frontend approach.
- This stack supports a rapid MVP while leaving a clean path for future persistence, feed fetching, and background updates.
- In-memory storage aligns with the stated MVP scope: no persistence, no feed fetching, no production-ready complexity.
- Maintaining a strict “add subscription + display list” boundary keeps the POC focused and lowers implementation risk.

## Alternatives considered
- A pure frontend-only solution: rejected because the stakeholder TechStack explicitly requires backend/frontend separation and because the future Extended-MVP expects server-side feed operations.
- Persistent storage in MVP: rejected to preserve speed and simplicity; the MVP requirement is satisfied with transient in-memory state.
- URL feed validation and fetch/parsing in MVP: rejected because the MVP should demonstrate only subscription management, not feed content handling.

## Outcomes
- Confirmed technical stack: ASP.NET Core backend + Blazor WebAssembly frontend.
- Confirmed MVP scope: add/list subscriptions only, no network feed fetch, no URL validation, in-memory state.
- Confirmed interface contract requirement: backend API exposed to frontend, documented separately as an API contract.
