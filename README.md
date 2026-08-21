# Record Shop Frontend

The Blazor frontend for my full-stack Record Shop application, built as my solo project during the Northcoders Enterprise Engineering Bootcamp.

The application provides a user interface for browsing and managing a record catalogue. Users can view records, search the catalogue, add new records, update existing records and remove records.

The frontend communicates with a separate ASP.NET Core Web API using `HttpClient`, keeping the user interface separate from the backend business logic and database access.

## Live Application

**Live Demo:** https://recordshop.nazmulhussain.co.uk

**Backend Repository:** https://github.com/Nazmul5765/record-shop-api

---

# Features

## Record Management

- Browse all records in the catalogue
- View individual record details
- Add new records
- Update existing record information
- Delete records
- Navigate between pages using Blazor routing
- Display a custom 404 page for unknown routes

## Search

Users can search the catalogue by:

- Record ID
- Title
- Artist

## Homepage

The homepage includes:

- A welcome section for Midnight Groove
- A featured record selected from the record collection
- Quick navigation to browse or search the catalogue

## Form Validation

The add and edit forms use data annotation validation to check user input before requests are sent to the API.

Validation is applied to:

- Title
- Artist
- Genre
- Release year
- Price
- Stock quantity

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
- Docker

---

# Architecture

The frontend is organised around Blazor pages and reusable components.

```text
Pages → Loader Components → Display/Form Components → Backend API
```

- **Pages** define application routes and page-level layouts.
- **Loader components** request data from the backend API.
- **Display components** render record information.
- **Form components** collect and validate user input.
- **HttpClient** handles communication with the backend API.

This structure separates data loading, presentation and user interaction into smaller components.

---

# Frontend and Backend Data Flow

The frontend does not access the database directly.

Instead, requests flow through the full-stack application like this:

```text
User action
    ↓
Blazor component
    ↓
HttpClient request
    ↓
ASP.NET Core Web API
    ↓
Service layer
    ↓
Repository layer
    ↓
PostgreSQL database
```

For example, when a user views an individual record:

```text
/records/3
    ↓
Record page
    ↓
RecordLoader
    ↓
GET /api/albums/3
    ↓
API response
    ↓
RecordDetails
```

When a user adds a record:

```text
AddRecordForm
    ↓
POST /api/albums
    ↓
Backend processes the request
    ↓
Record stored in the database
    ↓
Success response returned to the frontend
```

This separation keeps the frontend responsible for presentation and user interaction while the backend handles API requests, application logic and persistent data storage.

---

# Routes

| Route | Description |
|---|---|
| `/` | Homepage with welcome section and featured record |
| `/records` | View all records |
| `/records/{id}` | View, edit or delete an individual record |
| `/records/add` | Add a new record |
| `/search` | Search records by ID, title or artist |
| `/about` | About Midnight Groove |
| Unknown routes | Custom 404 page |

---

# API Integration

The frontend communicates with the Record Shop ASP.NET Core Web API using `HttpClient`.

The API base URL is configured separately from the application code, allowing the frontend to communicate with the appropriate API when running locally or in production.

Main API endpoints used by the frontend:

| Method | Endpoint | Used For |
|---|---|---|
| GET | `/api/albums` | Load all records |
| GET | `/api/albums/{id}` | Load an individual record |
| POST | `/api/albums` | Add a new record |
| PUT | `/api/albums/{id}` | Update a record |
| DELETE | `/api/albums/{id}` | Delete a record |
| GET | `/api/albums/title/{title}` | Search by title |
| GET | `/api/albums/artist/{artist}` | Search by artist |

---

# Component Design

## Reusable Components

The application is split into smaller Blazor components including components for record summaries, record details, loading data and forms.

This keeps individual components focused on a particular responsibility and makes the application easier to maintain.

## Loader Components

Components such as `RecordsLoader` and `RecordLoader` are responsible for requesting data from the backend API.

This separates API communication from components primarily responsible for displaying information.

## Cascading Parameters

`RecordsLoader` uses cascading values to make loaded record data available to child components.

This allows components such as the record list and featured record to use the loaded data without manually passing it through several component levels.

## Forms and Validation

The add and edit functionality uses Blazor `EditForm` components and data annotations to validate user input before requests are sent to the API.

---

# Deployment

The frontend is deployed as part of the full-stack Record Shop application.

The frontend and backend are maintained as separate applications and deployed independently.

```text
User
  ↓
Blazor Frontend
  ↓
ASP.NET Core API
  ↓
PostgreSQL
```

The frontend is:

- Containerised using Docker
- Deployed on Railway
- Configured to communicate with the deployed backend API
- Available through a custom domain

The backend is deployed separately on Railway and uses a PostgreSQL database hosted on Neon.

This deployment process gave me practical experience moving an application from a local development environment to a production environment and configuring communication between independently deployed frontend and backend services.

---

# Running Locally

The frontend requires the Record Shop backend API to access record data.

## 1. Clone the Repository

```bash
git clone https://github.com/Nazmul5765/record-shop-frontend.git
```

## 2. Start the Backend API

Clone and run the backend project:

```text
https://github.com/Nazmul5765/record-shop-api
```

When using the local development configuration, the API runs at:

```text
https://localhost:7060
```

## 3. Start the Frontend

Navigate to the frontend project and run:

```bash
dotnet watch run
```

Alternatively:

```bash
dotnet run --launch-profile https
```

The local development URL depends on the configured launch profile.

---

# Styling

The application uses Bootstrap alongside custom CSS to create a responsive dark-themed interface.

The interface includes:

- Responsive record grids
- Record cards
- Styled forms
- Search panels
- Responsive navigation
- Consistent buttons and controls
- Dark backgrounds with contrasting text

---

# Future Improvements

Possible future improvements include:

- Add pagination for larger record collections
- Add sorting and additional filtering options
- Add search autocomplete
- Improve the featured record section
- Add user ratings
- Add authentication and protected record-management actions
- Add shopping basket functionality
- Improve stock management for purchasing
- Add automated frontend testing

---

# Related Repository

The ASP.NET Core backend API for this application is available here:

**Record Shop API:** https://github.com/Nazmul5765/record-shop-api

---

# Author

Nazmul Hussain
