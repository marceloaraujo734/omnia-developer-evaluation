> [Home](/README.md) > API > Exemples > Update sale

## Sales

##### Update sales. `PUT` - /api/sales/*{id}*


Request:

```json
{  
  "customerId": "d11dc35a-112b-472b-8736-ea8121351345",
  "customerName": "Elvis",
  "branchId": "615fb5d1-7b19-4013-bdd4-3e2b00abd04b",
  "branchName": "Sipes - Morar",
  "totalValue": 30.0,
  "products": [
    {
        "productId": "77aff759-1ead-4d0a-8959-431ea3f3fa41",
        "quantity": 6.000,
        "price": 1.00,
        "total": 6.00        
    },
    {
        "productId": "2a4d4500-d7a2-4828-a329-7aaa79554c9a",
        "quantity": 9.000,
        "price": 1.00,
        "total": 9.00        
    },
    {
        "productId": "8dcdf2b8-456a-46cd-9c88-c2327b3b85b6",
        "quantity": 15.000,
        "price": 10.00,
        "total": 15.00
    }
  ]
}
```

Response:

```json
{
    "data": {
        "id": "50843ebd-5cb4-44fc-be79-b9299acc93f1",
        "number": "NUMBER-90",
        "openDate": "2025-02-18T00:00:00",
        "customerId": "544b1b1f-e98b-424e-951e-fb4ad1169e8d",
        "customerName": "Jayde",
        "branchId": "be4da797-9f7e-4c1c-b96b-e39dd25338eb",
        "branchName": "Fadel, Cremin and Reilly",
        "totalValue": 25.5000,
        "canceled": false,
        "products": [
            {
                "productId": "5a6ff4d4-1487-4a52-8831-9828a4f96296",
                "quantity": 6,
                "price": 1,
                "total": 5.40,
                "discount": 0.10,
                "canceled": false
            },
            {
                "productId": "8dcdf2b8-456a-46cd-9c88-c2327b3b85b6",
                "quantity": 15,
                "price": 1,
                "total": 12.0000,
                "discount": 0.20,
                "canceled": false
            },
            {
                "productId": "06d055b5-f21f-4434-a7f8-ff36b3b72a48",
                "quantity": 9,
                "price": 1,
                "total": 8.1000,
                "discount": 0.10,
                "canceled": false
            }
        ]
    },
    "success": true,
    "message": "",
    "errors": []
}
```