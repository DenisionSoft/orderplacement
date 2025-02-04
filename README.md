# Order Placement

Приложение для работы с заказами.

Используемый стек:
- Бэкенд - .NET 9, EF Core, ASP.NET, xUnit v3, Shouldly, FluentValidation
- Фронтенд - React, Axios, Chakra UI, Vite
- База данных - PostgreSQL
- Инфраструктура - Docker, Docker Compose

Ключевые проекты в решении бэкенда:
* `Web` - Web API
* `UnitTests` - тесты

## Описание API

Бэкенд предоставляет доступ к ручкам для работы с заказми.

### Orders
* `POST /api/v1/orders` - добавить заказ
* `GET /api/v1/orders` - получить страницу заказов, поддерживает пагинацию
* `GET /api/v1/orders/{orderId}` - получить заказ по идентификатору

## Запуск

### Через Docker

В проекте используется Docker Compose для запуска контейнеров с бэкенд и фронтенд приложениями, а также с базой данных. Это рекомендуемый способ запуска.

Строка подключения к базе данных в [appsettings.json](src/Web/appsettings.json) уже настроена на использование Docker.

Убедитесь, что Docker запущен. Из корневой директории проекта:

```shell
docker compose up --build
```

API будет доступно по адресу `http://localhost:5000`.

OpenAPI схема будет доступна по адресу`http://localhost:5000/openapi/v1.json`.

Фронтенд приложение будет доступно по адресу `http://localhost:3000`.

### Тестирование

Из корневой директории бэкенд проекта:

```shell
dotnet test
```

## Миграции

Миграция применится автоматически при запуске Web API. Для применения миграции вручную, выполните:

```shell
dotnet ef database update --project <MigrationProject> --startup-project src\Web\Web.csproj --context DataContext
```

В качестве `<MigrationProject>` используйте проект с миграциями, например:

`src\Data.Migrations.Psql\Data.Migrations.Psql.csproj`.

