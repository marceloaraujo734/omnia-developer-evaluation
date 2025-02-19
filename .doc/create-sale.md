> [Home](/README.md) > API > Exemples > Create sale

## Sales

##### Create sales. `POST` - /api/sales


Request:

```json
{
  "number": "NUMBER-001",
  "openDate": "2025-02-18",
  "customerId": "d11dc35a-112b-472b-8736-ea8121351345",
  "customerName": "Elvis",
  "branchId": "615fb5d1-7b19-4013-bdd4-3e2b00abd04b",
  "branchName": "Sipes - Morar",
  "totalValue": 30.0,
  "products": [
    {
        "productId": "77aff759-1ead-4d0a-8959-431ea3f3fa41",
        "quantity": 3.999,
        "price": 1.00,
        "total": 4.00        
    },
    {
        "productId": "2a4d4500-d7a2-4828-a329-7aaa79554c9a",
        "quantity": 6.000,
        "price": 1.00,
        "total": 5.40        
    },
    {
        "productId": "8dcdf2b8-456a-46cd-9c88-c2327b3b85b6",
        "quantity": 20.000,
        "price": 10.00,
        "total": 16.00
    }
  ]
}
```

Response:

```json
{
    "data": {
        "id": "0e059cdf-e6ba-46e6-8101-0b13281be257",
        "number": "NUMBER-461",
        "openDate": "2025-02-18T00:00:00",
        "customerId": "d11dc35a-112b-472b-8736-ea8121351345",
        "customerName": "Elvis",
        "branchId": "615fb5d1-7b19-4013-bdd4-3e2b00abd04b",
        "branchName": "Sipes - Morar",
        "totalValue": 25.40,
        "canceled": false,
        "products": [
            {
                "productId": "77aff759-1ead-4d0a-8959-431ea3f3fa41",
                "quantity": 3.999,
                "price": 1.00,
                "total": 4.00,
                "discount": 0.00,
                "canceled": false
            },
            {
                "productId": "2a4d4500-d7a2-4828-a329-7aaa79554c9a",
                "quantity": 6,
                "price": 1.00,
                "total": 5.40,
                "discount": 0.10,
                "canceled": false
            },
            {
                "productId": "8dcdf2b8-456a-46cd-9c88-c2327b3b85b6",
                "quantity": 20,
                "price": 1.00,
                "total": 16.00,
                "discount": 0.20,
                "canceled": false
            }
        ]
    },
    "success": true,
    "message": "Sale created successfully",
    "errors": []
}
```