# Splitwise App

### `Note: This app is for learning purpose only `

Splitwise is REST Api based application which provides basic functionalities to split the expenses among individuals and groups.
It is build using C# .NET CORE framework and postgres db.


Following Frameworks and technologies are being used
* C# .NET Core
* Postgres
* Fluent Validations

### Prerequisite

* Postgres
  * Install Postgres
  * Add Postgres and create database with name splitwiseDB

### Setting Up App
* Create Postgres DB with name `splitwiseDb` with username `app_admin` and password as `postgres`
* Execute following commands to create the table
    * `dotnet ef migrations add InitialCreate`
    * `dotnet ef database update`


### Supported APIs
#### User APIs
```http
  GET /user/{userId}
```

| Parameter | Type     | Description              |
|:----------| :------- |:-------------------------|
| `userId`    | `string` | \* **Required**. User Id |
Response:
```json
    {
      "email": "email@domain.com",
      "name": "user_name",
      "password": "password",
      "phoneNumber": "+91 0123456789"
    }
```

```http
  POST /user/
```

| Body Parameter | Type     | Description                 |
|:---------------| :------- |:----------------------------|
| `email`        | `string` | **Required**. Email Address |
| `name`         | `string` | **Required**. Name          |
| `password`     | `string` | **Required**. Password      |
| `phone number` | `string` | **Required**. Phone number  |
Example:
```json
    {
      "description": "stationary",
      "amount": 100,
      "paidBy": ["userId1", "userId12"],
      "owedBy": ["userId3"]
    }
```


----------------------------------
#### Expense APIs
* Create: `POST` `/expense`

```http
  POST /user/
```

| Body Parameter      | Type                | Description               |
|:--------------------|:--------------------|:--------------------------|
| `description`       | `string`            | **Required**. Description |
| `amount`            | `number`            | **Required**. Number      |
| `paidBy`            | `list<string>`      | **Required**. PaidBy      |
| `owedBy`            | `list<string>`      | **Required**. Owed By     |
Example:
```json
    {
      "description": "stationary",
      "amount": 100,
      "paidBy": ["userId1", "userId12"],
      "owedBy": ["userId3"]
    }
```
---
* Get: `GET` `/expense/{expenseId}`

| Parameter   | Type     | Description                 |
|:------------| :------- |:----------------------------|
| `expenseId` | `string` | \* **Required**. Expense Id |
Response:
```json
    {
      "expenseId": "exp-Id",
      "description": "stationary",
      "amount": 100,
      "paidBy": ["userId1", "userId12"],
      "owedBy": ["userId3"]
    }           
```

