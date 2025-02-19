# This Project

This project is included in the recruitment process for senior developers at Taking and involves creating prototypes for a sales management API.

## Project setup

1. Run `docker-compose up` to start the containers or open your preferred Ide like `Visual Studio, Visual Studio Code or Rider`.


2. Run the command `update-database` to create tables in the database. If it doesn't work, check the appsettings connection string. By default, the PostgreSQL port 5432 is exposed.

# Endpoints Prototype Sales API

## Sales

<table>
  <tr>
    <th>HTTP Method</th>
    <th>Endpoint</th>
    <th>Responses</th>
    <th>:link:</th>
  </tr>
  <tr>
    <td>POST</td>
    <td>/api/sales</td>
    <td>201 (Created) 400 (Bad Request)</td>
    <td><a href="/.doc/create-sale.md" targer="__blank">exemple</a></td>
  </tr>
  <tr>
    <td>PUT</td>
    <td>/api/sales</td>
    <td>200 (OK) 400 (Bad Request) 404 (Not Found)</td>
    <td><a href="/.doc/update-sale.md" targer="__blank">exemple</a></td>
  </tr>
  <tr>
    <td>GET</td>
    <td>/api/sales/{id}</td>
    <td>200 (OK) 400 (Bad Request) 404 (Not Found)</td>
    <td><a href="/.doc/get-sale.md" targer="__blank">exemple</a></td>
  </tr>
  <tr>
    <td>GET</td>
    <td>/api/sales</td>
    <td>200 (OK) 400 (Bad Request) 404 (Not Found)</td>
    <td><a href="/.doc/get-sales.md" targer="__blank">exemple</a></td>
  </tr>
  <tr>
    <td>DELETE</td>
    <td>/api/sales/{id}</td>
    <td>200 (OK) 400 (Bad Request) 404 (Not Found)</td>
    <td><a href="/.doc/cancel-sale.md" targer="__blank">exemple</a></td>
  </tr>
  <tr>
    <td>DELETE</td>
    <td>/api/sales/{id}/products/{productId}</td>
    <td>200 (OK) 400 (Bad Request) 404 (Not Found)</td>
    <td><a href="/.doc/cancel-sale-product.md" targer="__blank">exemple</a></td>
  </tr>
</table>

### Testing

To run the tests, use the following command:

```bash
dotnet test
```

### License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.