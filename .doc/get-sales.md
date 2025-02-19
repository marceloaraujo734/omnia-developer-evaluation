> [Home](/README.md) > API > Exemples > Get sales

## Sales

##### Get sales. `GET` - /api/sales

#### Parameters

- **`page`** (int, optional): Specifies the current page number (default is `1`).
- **`size`** (int, optional): Defines the number of items per request (default is `10`).
- **`order`** (string, optional): Determines the sorting order, example `"totalValue desc"` (`"asc"` for ascending, `"desc"` for descending).

Response:

```json
{
    "currentPage": 1,
    "totalPages": 1,
    "totalCount": 4,
    "data": [
        {
            "id": "0e059cdf-e6ba-46e6-8101-0b13281be257",
            "number": "NUMBER-461",
            "openDate": "2025-02-18T00:00:00",
            "customerId": "5b5dd44c-f1ad-4b35-b13b-adac8826aa1b",
            "customerName": "Mckenzie",
            "branchId": "8e089de9-91fa-4a06-9024-5da464c086d0",
            "branchName": "Bernhard - Schaden",
            "totalValue": 34.36,
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
                    "productId": "a7ec46ca-0764-4f25-b3bc-72ecca818851",
                    "quantity": 9.000,
                    "price": 1.00,
                    "total": 8.10,
                    "discount": 0.10,
                    "canceled": false
                },
                {
                    "productId": "3e80e81e-c089-4431-b97f-e6cef64b8dcd",
                    "quantity": 6.000,
                    "price": 1.00,
                    "total": 5.40,
                    "discount": 0.10,
                    "canceled": false
                },
                {
                    "productId": "2a4d4500-d7a2-4828-a329-7aaa79554c9a",
                    "quantity": 6.000,
                    "price": 1.00,
                    "total": 4.86,
                    "discount": 0.10,
                    "canceled": false
                },
                {
                    "productId": "8dcdf2b8-456a-46cd-9c88-c2327b3b85b6",
                    "quantity": 15.000,
                    "price": 1.00,
                    "total": 12.00,
                    "discount": 0.20,
                    "canceled": false
                }
            ]
        },
        {
            "id": "50843ebd-5cb4-44fc-be79-b9299acc93f1",
            "number": "NUMBER-90",
            "openDate": "2025-02-18T00:00:00",
            "customerId": "544b1b1f-e98b-424e-951e-fb4ad1169e8d",
            "customerName": "Jayde",
            "branchId": "be4da797-9f7e-4c1c-b96b-e39dd25338eb",
            "branchName": "Fadel, Cremin and Reilly",
            "totalValue": 25.50,
            "canceled": false,
            "products": [
                {
                    "productId": "06d055b5-f21f-4434-a7f8-ff36b3b72a48",
                    "quantity": 9.000,
                    "price": 1.00,
                    "total": 8.10,
                    "discount": 0.10,
                    "canceled": false
                },
                {
                    "productId": "8dcdf2b8-456a-46cd-9c88-c2327b3b85b6",
                    "quantity": 15.000,
                    "price": 1.00,
                    "total": 12.00,
                    "discount": 0.20,
                    "canceled": false
                },
                {
                    "productId": "5a6ff4d4-1487-4a52-8831-9828a4f96296",
                    "quantity": 6.000,
                    "price": 1.00,
                    "total": 5.40,
                    "discount": 0.10,
                    "canceled": false
                }
            ]
        },
        {
            "id": "2042bc32-6880-4491-9250-4cab492d1774",
            "number": "NUMBER-697",
            "openDate": "2025-02-18T00:00:00",
            "customerId": "f7112fcf-c562-45fb-b80f-bd5225029128",
            "customerName": "Florence",
            "branchId": "3ca7cadf-b18b-4690-bf25-12c36cc906e3",
            "branchName": "Kulas, Kling and Powlowski",
            "totalValue": 25.40,
            "canceled": false,
            "products": [
                {
                    "productId": "8dcdf2b8-456a-46cd-9c88-c2327b3b85b6",
                    "quantity": 20.000,
                    "price": 1.00,
                    "total": 16.00,
                    "discount": 0.20,
                    "canceled": false
                },
                {
                    "productId": "247e236a-efc5-41cc-b641-b7d100cf6f6c",
                    "quantity": 3.999,
                    "price": 1.00,
                    "total": 4.00,
                    "discount": 0.00,
                    "canceled": false
                },
                {
                    "productId": "219cd4e0-a03a-4c48-8435-4282799358be",
                    "quantity": 6.000,
                    "price": 1.00,
                    "total": 5.40,
                    "discount": 0.10,
                    "canceled": false
                }
            ]
        },
        {
            "id": "847ac891-e908-47b5-bd04-ef0312acdf71",
            "number": "NUMBER-981",
            "openDate": "2025-02-17T00:00:00",
            "customerId": "2ccaecb1-20ea-4c41-8836-ac53f1e8b0ed",
            "customerName": "Fletcher",
            "branchId": "841eca4b-0f1b-416f-b2b1-e3b1cf6a0a84",
            "branchName": "Hammes LLC",
            "totalValue": 25.40,
            "canceled": false,
            "products": [
                {
                    "productId": "7892e89e-032b-454c-b9d5-b1eb2adc69be",
                    "quantity": 6.000,
                    "price": 1.00,
                    "total": 5.40,
                    "discount": 0.10,
                    "canceled": false
                },
                {
                    "productId": "8dcdf2b8-456a-46cd-9c88-c2327b3b85b6",
                    "quantity": 20.000,
                    "price": 1.00,
                    "total": 16.00,
                    "discount": 0.20,
                    "canceled": false
                },
                {
                    "productId": "dec4ff29-69e3-4d0a-a248-3de1f17cf776",
                    "quantity": 3.999,
                    "price": 1.00,
                    "total": 4.00,
                    "discount": 0.00,
                    "canceled": false
                }
            ]
        }
    ],
    "success": true,
    "message": "",
    "errors": []
}
```