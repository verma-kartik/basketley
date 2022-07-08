# E-Commerce API (Microservice Backend)

> `E-Commerce API` is a fictional ecommerce sample, built with .Net 6 and different software architecture and technologies like **Microservices Architecture**, **Onion Architecture**, **Domain Driven Design (DDD)**, **Event Driven Architecture**. For communication between independent services, we use asynchronous messaging with using Rabbitmq and gateway service using OcelotAPI Gateway.

## Goal of this Project

- The `Microservices Architecture` with `Domain Driven Design (DDD)` implementation.
- Correct separation of bounded contexts for each microservice.
- Using Database-per-Service pattern
- Communications between bounded contexts through asynchronous `Message Broker` with using `RabbitMQ` with some autonomous services.
- Using `Best Practice` and `New Technologies` and `Design Patterns`.
- Using `Event Storming` for extracting data model and bounded context (using Miro).
- Using Docker-Compose for our deployment mechanism.
 
## Plan
> This project is in progress, new features will be added over time. [Cries in DSA]

High-level plan is represented in the table

| Feature | Status |
| ------- | ------ |
| Building Blocks | Not Started 🚩 |
| API Gateway | Not Started 🚩 |
| Identity Service | In Progress 👷‍ |
| Customer Service | Completed ✔️ |
| Product Service | Completed ✔️ |
| Order Service |  In Progress 👷‍|
| Shipping Service | Not Started 🚩 |
| Payment Service | Not Started 🚩 |

## License
The project is under [MIT license](https://github.com/mehdihadeli/ecommerce-microservices-sample/blob/main/LICENSE).
