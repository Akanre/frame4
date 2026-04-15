# Task1 Web Service (ASP.NET Core)

Мини веб-служба для управления списком элементов (каталог объектов).

## Тема проекта
Мини API для работы с каталогом элементов с хранением данных в памяти.

## Функциональность

Реализованы 3 основных endpoint-а:

- `GET /api/items` — получить список всех элементов
- `GET /api/items/{id}` — получить элемент по id
- `POST /api/items` — создать новый элемент

## Модель данных

Item:
- id (int)
- name (string)
- price (decimal)

## Валидация

- name не должен быть пустым
- price должен быть ≥ 0

## Особенности архитектуры

Реализован конвейер обработки запросов (middleware):

- LoggingMiddleware — логирование запросов и ответов
- ExceptionMiddleware — единый формат обработки ошибок
- TimingMiddleware — замер времени выполнения запросов

## Хранение данных

Данные хранятся в памяти приложения (in-memory storage), без базы данных.

## Запуск

1. Открыть проект в Visual Studio
2. Запустить через `F5` или `dotnet run`
3. Перейти:
   - `https://localhost:xxxx/swagger` (если включен Swagger)
   - или использовать Postman / curl

## Пример работоспособности 

<img width="873" height="893" alt="Снимок экрана 2026-04-15 142826" src="https://github.com/user-attachments/assets/22a0efc1-443c-469a-b92d-ac8d76f5ee88" />

<img width="1505" height="588" alt="Снимок экрана 2026-04-15 142846" src="https://github.com/user-attachments/assets/59d4b357-161d-42f2-aa3d-823addb5f3ef" />

