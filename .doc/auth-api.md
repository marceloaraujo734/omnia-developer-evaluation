[Back to README](../README.md)


### Authentication

#### POST /auth/login
- Description: Authenticate a user
- Request Body:
  ```json
  {
    "username": "string",
    "password": "string"
  }
  ```
- Response: 
  ```json
  {
    "data": {
        "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJhNmMxODU4Mi1jMmNjLTQzOGQtYmI0Zi1mMDU1ZjhiMzU1ZDMiLCJ1bmlxdWVfbmFtZSI6IkFkbWluIiwicm9sZSI6IkFkbWluIiwibmJmIjoxNzM5OTYzODY4LCJleHAiOjE3Mzk5OTI2NjgsImlhdCI6MTczOTk2Mzg2OH0.ZXy_IROQNzgTYeKLC5QnqCDeKs1cnLKD3KvfEdfXYIU",
        "email": "admin@abinbev.com.br",
        "name": "Admin",
        "role": "Admin"
    },
    "success": true,
    "message": "",
    "errors": []
}
  ```