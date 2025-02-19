> [Home](/README.md) > API > Exemples > Create User

## Users

##### Create users. `POST` - /api/users


Request:

```json
{
  "username": "Admin",
  "password": "Admin@123",
  "phone": "11999999999",
  "email": "admin@abinbev.com.br",
  "status": 1,
  "role": 3
}
```

Response:

```json
{
    "data": {
        "id": "a6c18582-c2cc-438d-bb4f-f055f8b355d3",
        "name": "",
        "email": "",
        "phone": "",
        "role": 0,
        "status": 0
    },
    "success": true,
    "message": "User created successfully",
    "errors": []
}
```