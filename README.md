# This Project

This project is included in the recruitment process for senior developers at Taking and involves creating prototypes for a sales management API.

## Project setup

1. Run `docker-compose up` to start the containers. Alternatively, you can open the project in an IDE like `Visual Studio, Visual Studio Code, or Rider`.


2. Run the command `update-database` to create tables in the database. If it doesn't work, check the appsettings connection string. By default, the PostgreSQL port 5432 is exposed.

3. To access the sales functionalities that require authorization, you need to create a user and obtain a token. Follow the user creation and token retrieval documentation for details.

## RESTful API Design
Clean and well-documented endpoints for client integration, built using **Swagger/OpenAPI** for automatic API documentation.

### Sales Management
Store and manage sales information, including:
- Sale number
- Date of the sale
- Customer
- Branch where the sale occurred
- Products involved in the sale
- Product details such as:
  - Quantity
  - Unit price
  - Discounts
  - Cancellation status

### Business Logic
Implemented discount rules based on item quantity:
- 10% discount for purchases between 4 and 9 items.
- 20% discount for purchases between 10 and 20 items.
- Purchases above 20 identical items are restricted.
- No discounts are applied for quantities below 4 items.

## Prerequisites

Before you begin, ensure you have met the following requirements:

- **Docker**: You should have Docker installed on your machine. [Get Docker](https://docs.docker.com/get-docker/)
- **Git**: Make sure Git is installed to clone the repository. [Get Git](https://git-scm.com/downloads)

## Installation

Follow these steps to get the application up and running locally.

1. **Clone the Repository**

   Start by cloning the repository from GitHub. Open your terminal and run the following command:

   ```bash
   git clone [clone](https://github.com/marceloaraujo734/omnia-developer-evaluation.git)
   
   cd omnia-developer-evaluation
    ```

## Running the Application
The application is containerized using Docker, making it simple to run:

Build and Run the Docker Containers
Use Docker Compose to build and run the application's containers. Execute the command below to start the services:

   ```bash
   docker-compose up --build
   ```
  This command will start the .NET Core application, RabbitMQ, and PostgreSQL together.

## Accessing the API

Once the containers are up, you can access the API via: [link-local](http://localhost:7181)

# Features

## Users

<table>
  <tr>
    <th>HTTP Method</th>
    <th>Endpoint</th>
    <th>Responses</th>
    <th>Link</th>
  </tr>
  <tr>
    <td>POST</td>
    <td>/api/users</td>
    <td>201 (Created) 400 (Bad Request)</td>
    <td><a href="/.doc/create-user.md" target="_blank">exemple</a></td>
  </tr>  
</table>

## Auth

<table>
  <tr>
    <th>HTTP Method</th>
    <th>Endpoint</th>
    <th>Responses</th>
    <th>Link</th>
  </tr>
  <tr>
    <td>POST</td>
    <td>/api/auth</td>
    <td>201 (Created) 400 (Bad Request)</td>
    <td><a href="/.doc/auth-api.md" target="_blank">exemple</a></td>
  </tr>  
</table>

## Sales

<table>
  <tr>
    <th>HTTP Method</th>
    <th>Endpoint</th>
    <th>Responses</th>
    <th>Link</th>
  </tr>
  <tr>
    <td>POST</td>
    <td>/api/sales</td>
    <td>201 (Created) 400 (Bad Request)</td>
    <td><a href="/.doc/create-sale.md" target="_blank">exemple</a></td>
  </tr>
  <tr>
    <td>PUT</td>
    <td>/api/sales</td>
    <td>200 (OK) 400 (Bad Request) 404 (Not Found)</td>
    <td><a href="/.doc/update-sale.md" target="_blank">exemple</a></td>
  </tr>
  <tr>
    <td>GET</td>
    <td>/api/sales/{id}</td>
    <td>200 (OK) 400 (Bad Request) 404 (Not Found)</td>
    <td><a href="/.doc/get-sale.md" target="_blank">exemple</a></td>
  </tr>
  <tr>
    <td>GET</td>
    <td>/api/sales</td>
    <td>200 (OK) 400 (Bad Request) 404 (Not Found)</td>
    <td><a href="/.doc/get-sales.md" target="_blank">exemple</a></td>
  </tr>
  <tr>
    <td>DELETE</td>
    <td>/api/sales/{id}</td>
    <td>200 (OK) 400 (Bad Request) 404 (Not Found)</td>
    <td><a href="/.doc/cancel-sale.md" target="_blank">exemple</a></td>
  </tr>
  <tr>
    <td>DELETE</td>
    <td>/api/sales/{id}/products/{productId}</td>
    <td>200 (OK) 400 (Bad Request) 404 (Not Found)</td>
    <td><a href="/.doc/cancel-sale-product.md" target="_blank">exemple</a></td>
  </tr>
</table>


## Testing the API

Use Postman or another API testing tool to test the following endpoints:

- **POST /sales** – Create a new sale
- **PUT /sales/{id}** – Change an existing sale
- **GET /sales/{id}** – Get sale details
- **GET /sales** – List sales
- **DELETE /sales/{id}** – Cancel a sale
- **DELETE /api/sales/{Id}/products/{productId}** – Cancel a specific product from a sale

## Running Unit Tests

Run unit tests with xUnit:

- .NET SDK 8: Required to build and run the application. [Download .NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

- Run unit and integration tests using xUnit with the following command:
```bash
dotnet test
```

## Project Structure
Briefly describe the significant components and organization of your project:

- `/src`: Contains the main source code of the .NET Core application.
- `/tests`: Unit and integration tests.