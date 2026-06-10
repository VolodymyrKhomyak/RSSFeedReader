# Tasks: Subscription management (MVP)

**Input**: Design documents from `specs/001-subscription-management/`

**Prerequisites**: `plan.md`, `spec.md`, `research.md`, `data-model.md`, `contracts/api-contract.md`

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Initialize the backend/frontend workspace and create the foundational project structure.

- [x] T001 Create backend project scaffold in `backend/RSSFeedReader.Api/Program.cs`
- [x] T002 Create frontend project scaffold in `frontend/RSSFeedReader.UI/Program.cs`
- [x] T003 [P] Create backend subscription model in `backend/RSSFeedReader.Api/Models/Subscription.cs`
- [x] T004 [P] Create backend subscription storage abstraction in `backend/RSSFeedReader.Api/Services/ISubscriptionStore.cs`
- [x] T005 [P] Create concrete in-memory storage implementation in `backend/RSSFeedReader.Api/Services/InMemorySubscriptionStore.cs`

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Implement the core backend/front-end plumbing needed before any user story work can begin.

- [x] T006 Configure backend dependency injection and CORS in `backend/RSSFeedReader.Api/Program.cs`
- [x] T007 Create `backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs` with placeholder routing for GET and POST
- [x] T008 Create frontend app configuration in `frontend/RSSFeedReader.UI/wwwroot/appsettings.json`
- [x] T009 Replace Blazor template demo pages in `frontend/RSSFeedReader.UI/Pages/` with a single MVP landing page structure
- [x] T010 Create frontend subscription API client in `frontend/RSSFeedReader.UI/Services/SubscriptionApiClient.cs`

**Checkpoint**: The backend API and frontend project are scaffolded, CORS is configured, and the core subscription service abstraction exists.

---

## Phase 3: User Story 1 - Add a subscription (Priority: P1)

**Goal**: Enable the user to add a feed subscription URL and submit it to the backend.

**Independent Test**: Open the UI, enter a feed URL, click add, and verify the subscription is sent to the backend and stored in memory.

- [x] T011 [US1] Implement backend `POST /api/subscriptions` in `backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs`
- [x] T012 [US1] Implement backend request body validation and `201 Created` response handling in `backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs`
- [x] T013 [US1] Implement frontend add-subscription UI in `frontend/RSSFeedReader.UI/Pages/Home.razor`
- [x] T014 [US1] Wire frontend add button to `frontend/RSSFeedReader.UI/Services/SubscriptionApiClient.cs`
- [x] T015 [US1] Add a backend unit test for the in-memory subscription store in `backend/RSSFeedReader.Api.Tests/UnitTests/SubscriptionStoreTests.cs`

**Checkpoint**: A user can add a subscription URL from the frontend and the backend stores it in memory.

---

## Phase 4: User Story 2 - View subscriptions (Priority: P1)

**Goal**: Display the current list of subscriptions in the UI after they are added.

**Independent Test**: Add multiple subscriptions in the UI and verify the list refreshes to show all added URLs.

- [x] T016 [US2] Implement backend `GET /api/subscriptions` in `backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs`
- [x] T017 [US2] Implement frontend subscription list rendering in `frontend/RSSFeedReader.UI/Pages/Home.razor`
- [x] T018 [US2] Update frontend refresh behavior so the list is refreshed automatically after adding a subscription in `frontend/RSSFeedReader.UI/Pages/Home.razor`
- [x] T019 [US2] Add a frontend integration verification task to confirm list updates in `frontend/RSSFeedReader.UI/Pages/Index.razor`

**Checkpoint**: The UI shows the current subscriptions list and updates after each add action.

---

## Phase 5: User Story 3 - Extended-MVP: Manual refresh (Priority: P2)

**Goal**: Prepare the eventual manual refresh flow for future feed fetching and item display.

**Independent Test**: This is a deferred extension; a placeholder should be present for later implementation.

- [x] T020 [US3] Add placeholder backend endpoint in `backend/RSSFeedReader.Api/Controllers/FeedsController.cs`
- [x] T021 [US3] Add placeholder frontend refresh UI in `frontend/RSSFeedReader.UI/Pages/FeedRefresh.razor`
- [x] T022 [US3] Document the extended refresh workflow in `specs/001-subscription-management/contracts/api-contract.md`

**Checkpoint**: The extended-MVP contract is captured and the refresh flow is scaffolded without changing MVP behavior.

---

## Phase 6: Polish & Cross-Cutting Concerns

**Purpose**: Final cleanup, documentation updates, and validation across the feature.

- [x] T023 [P] Update `specs/001-subscription-management/quickstart.md` to match the actual backend/frontend launch commands and project structure
- [x] T024 [P] Update `specs/001-subscription-management/checklists/requirements.md` to confirm implementation readiness
- [x] T025 [ ] Review `specs/001-subscription-management/contracts/api-contract.md` and confirm the final backend routes and payloads match implementation
- [x] T026 [ ] Add or update a README note in `README.md` describing how this feature fits the RSS Feed Reader MVP

---

## Dependencies & Execution Order

### Phase Dependencies
- **Phase 1**: Setup tasks can begin immediately.
- **Phase 2**: Foundational work blocks all user story implementation until complete.
- **Phase 3+**: User stories can begin only after foundational phase is complete.
- **Phase 6**: Polish can begin after the required user stories are functional.

### User Story Dependencies
- **User Story 1**: Can start after Phase 2 and does not depend on any other story.
- **User Story 2**: Can start after Phase 2 and can be validated independently of User Story 1 once API endpoints exist.
- **User Story 3**: Deferred extension; can be implemented after MVP delivery.

### Parallel Opportunities
- Setup tasks `T003` through `T005` are parallelizable.
- Foundational tasks `T006` through `T010` are parallelizable where they touch different files.
- User Story 1 and User Story 2 implementation tasks can be worked in parallel by separate developers once Phase 2 is complete.
- Polish tasks `T023` and `T024` are parallelizable.

## Implementation Strategy

### MVP first
1. Complete Phase 1 to scaffold backend/frontend structure.
2. Complete Phase 2 to enable backend API and frontend wiring.
3. Deliver Phase 3 as the core MVP: add subscriptions.
4. Deliver Phase 4 as the visible subscription list.
5. Validate the MVP flow before any extended work.

### Incremental delivery
- After Phase 2, complete User Story 1 and User Story 2 as separate, independently testable slices.
- Hold User Story 3 as a future extension once the MVP is stable.

### Final validation
- Verify `GET /api/subscriptions` and `POST /api/subscriptions` against `specs/001-subscription-management/contracts/api-contract.md`
- Confirm the frontend list updates immediately after add operations
- Confirm the documentation in `quickstart.md` and `requirements.md` matches the final implementation
