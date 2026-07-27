# Record Shop Frontend

A Blazor Web App frontend for browsing and managing records in the Midnight Groove record shop.

This project allows users to browse records, view record details, add new records, update existing records, delete records and search the catalogue.

The frontend communicates with the Record Shop API using `HttpClient` and displays data returned from the backend API.

---

# Features

## Core Features

- View all records
- View a single record by ID
- Add a new record
- Update record details
- Delete records
- Navigate between pages using Blazor routing
- Display a custom 404 page for unknown routes

## Search Features

- Search for a record by ID
- Search for a record by title
- Search for records by artist

## Homepage Features

- Welcome section for Midnight Groove
- Featured record selected from the record collection
- Quick navigation to browse and search records

## Validation

The frontend uses data annotation validation to check form input before sending create or update requests to the API.

Validation is used for:

- Title
- Artist
- Genre
- Release year
- Price
- Stock quantity

## Styling

The application uses Bootstrap for layout and styling.

The current design uses a dark theme with:

- Dark cards
- Light text
- Bootstrap buttons
- Responsive record grids
- Styled forms and search panels

---

# Technologies Used

- C#
- .NET 8
- Blazor Web App
- Razor Components
- Bootstrap
- HTML
- CSS
- HttpClient
- System.Net.Http.Json

---

# Architecture

The frontend is organised around Blazor pages and reusable components.

```text
Pages → Loader Components → Display/Form Components → Backend API
```

- Pages define routes and page-level layout
- Loader components request data from the backend API
- Display components render record information
- Form components collect and validate user input
- `HttpClient` sends HTTP requests to the API

---

# Frontend and Backend Data Flow

The frontend does not access the database directly.

Instead, the data flows through the application like this:

```text
User action → Blazor component → HttpClient request → Backend API → Service/Repository → Database
```

Example flow for viewing a single record:

```text
/records/3 → RecordPage → RecordLoader → GET /api/albums/3 → API response → RecordDetails
```

Example flow for adding a new record:

```text
AddRecordForm → POST /api/albums → Backend saves record → Success message shown
```

This separation keeps the frontend responsible for user interaction and display, while the backend handles API requests, business logic and database access.

---

# Routes

| Route | Description |
|---|---|
| `/` | Homepage with welcome section and featured record |
| `/records` | View all records |
| `/records/{id}` | View, edit or delete a single record |
| `/records/add` | Add a new record |
| `/search` | Search records by ID, title or artist |
| `/about` | About page for Midnight Groove |
| Unknown routes | Custom 404 page |

---

# API Integration

The frontend calls the backend API using `HttpClient`.

The API is expected to run at:

```text
https://localhost:7060
```

Main API endpoints used by the frontend:

| Method | Endpoint | Used For |
|---|---|---|
| GET | `/api/albums` | Load all records |
| GET | `/api/albums/{id}` | Load one record |
| POST | `/api/albums` | Add a new record |
| PUT | `/api/albums/{id}` | Update a record |
| DELETE | `/api/albums/{id}` | Delete a record |
| GET | `/api/albums/title/{title}` | Search by title |
| GET | `/api/albums/artist/{artist}` | Search by artist |

---

# Design Patterns and Concepts

## Component-Based UI

The application is split into smaller Blazor components such as `RecordSummary`, `RecordDetails`, `RecordsLoader` and `AddRecordForm`.

This helps keep the UI easier to understand, reuse and maintain.

## Loader Components

Components such as `RecordsLoader` and `RecordLoader` are responsible for fetching data from the API.

This separates data loading from display components.

## Cascading Parameters

`RecordsLoader` uses cascading values to share loaded records with child components such as the all records list and featured record.

This avoids passing the same data through several layers of components manually.

## Forms and Validation

The add and edit forms use Blazor `EditForm` and data annotations to validate user input before sending requests to the backend.

---

# Running the Project

## Start the Backend API

The backend API should be running first.

From the backend project:

```bash
dotnet run --launch-profile https
```

The API should run at:

```text
https://localhost:7060
```

## Start the Frontend

From the frontend project:

```bash
cd RecordShop.Web/RecordShop.Web/RecordShop.Web
dotnet watch run
```

Or run with a specific launch profile:

```bash
dotnet run --launch-profile https
```

The frontend should run at:

```text
https://localhost:7024
```

or:

```text
http://localhost:5059
```

---

# Future Improvements

Possible future improvements include:

- Improve the visual design further
- Add pagination for large record collections
- Investigate Blazor `Virtualize` for long record lists
- Add backend validation to protect against invalid API requests
- Add sorting options for search results
- Add advanced search filters for genre, price and release year
- Add search autocomplete with debounced input
- Improve the featured record into a carousel
- Add user ratings for records
- Add authentication for protected actions
- Only allow logged-in users to add, update or delete records
- Add a shopping cart
- Track stock more carefully during checkout
- Add automated frontend tests

---

# Author

Nazmul Hussain
