<!--
Sync Impact Report

Version change: [unknown] -> 0.1.0
Modified principles: placeholder template -> Concrete core principles (Security by Default; Maintainability & Modular Design; Testable Core Behavior; MVP Simplicity; Observability & Versioning)
Added sections: Security & Constraints, Development Workflow
Removed sections: none
Templates requiring updates: ⚠ /Users/vkhomiak/projects/GitHubSpecKit/TrainingProjects/RSSFeedReader/.specify/templates/plan-template.md (pending)
						  ⚠ /Users/vkhomiak/projects/GitHubSpecKit/TrainingProjects/RSSFeedReader/.specify/templates/spec-template.md (pending)
						  ⚠ /Users/vkhomiak/projects/GitHubSpecKit/TrainingProjects/RSSFeedReader/.specify/templates/tasks-template.md (pending)
Follow-up TODOs: RATIFICATION_DATE left as TODO
-->

# RSS Feed Reader Constitution

## Core Principles

### I. Security by Default
All external or user-provided content MUST be treated as untrusted. For the MVP (no feed fetching), this means:
- No HTML rendering of external feed content in the UI. If feed content is added later, sanitize with a vetted library before display.
- Any future network fetches MUST use HttpClient with timeouts, cancellation, and limited concurrency. Credentials and secrets MUST not be hardcoded.

### II. Maintainability & Modular Design
Code MUST be organized with clear separation between backend API and frontend UI. Concretely:
- Backend endpoints expose a minimal, well-documented contract: add subscription, list subscriptions.
- Keep subscription storage behind a single abstraction to allow swapping in-memory storage for a persistent store without wide refactors.
- Remove Blazor template demo pages before implementing MVP pages (see TechStack cleanup steps).

### III. Testable Core Behavior (NON-NEGOTIABLE)
Core behaviors are testable units and MUST have automated tests before changes are merged. Specifically:
- Unit tests for the subscription add/list logic (backend and any shared models).
- Integration or end-to-end tests that verify the frontend can add a subscription and display it (can be minimal / run locally).
- CI must run unit tests on every PR; failing tests block merges.

### IV. MVP Simplicity (Scope Discipline)
The MVP scope is intentionally minimal. Changes that expand scope MUST be approved via PR with an explicit rationale and migration plan. Rules:
- MVP implementation MUST store subscriptions in memory and accept URLs without validation.
- No feed fetching, parsing, or background polling in MVP code paths.
- Any post-MVP features must be behind feature flags or added in separate branches/PRs.

### V. Observability, Logging & Versioning
Even for a POC, maintain minimal observability and a clear versioning policy:
- Use structured logging for key events (subscription added, errors). Logs MUST not contain secrets.
- Follow semantic versioning for releases. Internal changes to wording or docs → PATCH; new principle added → MINOR; principle removal or incompatible governance change → MAJOR.

## Security & Constraints
The project targets a local, single-user POC environment. Constraints:
- Default runtime behavior must not perform network calls. Any network-capable code must be opt-in and clearly documented.
- Sanitize user input that will be rendered in the UI. Escape content by default.

## Development Workflow
- Pull requests require at least one approving reviewer and passing CI (tests + linters).
- Minor documentation or wording fixes should be implemented as PATCH-level amendments to this constitution.
- Use the Tech Stack guidance (TechStack.md) for cleanup and port configuration before implementing features.

## Governance
Amendments to this constitution follow this process:
- Propose change in a dedicated branch with a PR describing the change and migration implications.
- Two approving reviewers required for MINOR/PATCH changes. MAJOR changes require explicit maintainers' sign-off.
- The PR must state the required version bump (MAJOR/MINOR/PATCH) and justification.

**Version**: 0.1.0 | **Ratified**: TODO(RATIFICATION_DATE): identify original adoption date | **Last Amended**: 2026-06-09
