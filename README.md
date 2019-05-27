# TDIN-2

## Instruções

* Abrir o projeto no Visual Studio.

* Nas propriedades da solução BookShop em Common Properties > Startup Project, selecionar a opção "Multiple startup projects".

* Todos os projetos, excepto o BookShopWebsite, devem ter o "Action" a Start, sendo que os serviços devem ser inicializados primeiro que os clientes (StoreService e WarehouseService no topo da lista)

* Dar "Start" à solução

* Na pasta TDIN-2/BookShopWebsite, correr os seguintes comandos:
    - npm install
    - npm run serve

* Correr o script chrome_cors.bat que se encontra no caminho TDIN-2\BookShopWebsite\scripts e navegar para localhost:8080

## Autores
- Beatriz Baldaia
- João Esteves
