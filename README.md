# Пример использования Dockerfile
## Запуск приложения в контейнере
Для запуска приложения в контейнере:
```bash
# Находясь в корневой папке репозитория
docker build --tag matrix-std . -f deployment/Dockerfile
docker run matrix-std /App/entrypoint.sh
```

## Dockerfile
`Dockerfile` может быть найден по пути `/deployment/Dockerfile` и соответствует лучшим практикам:
 - все пути `WORKDIR` абсолютны от корня репозитория;
 - использован multi-stage build: в этапе `build` установлены sdk, восстановлены зависимости, но в итоговый контейнер идет только собранное приложени; 
 - проходит hadolint (предупреждение ```Dockerfile:8 DL3059 info: Multiple consecutive `RUN` instructions. Consider consolidation.``` является нарушением лучших практик разделения слоя восстановления пакетов и кода)