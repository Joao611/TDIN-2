# TDIN-2

* Abrir o projeto no Visual Studio.

* Nas propriedades da solu��o BookShop em Common Properties > Startup Project, selecionar a op��o "Multiple startup projects".

* Todos os projetos, excepto o BookShopWebsite, devem ter o "Action" a Start, sendo que os servi�os devem ser inicializados primeiro que os clientes (StoreService e WarehouseService no topo da lista)

* Dar "Start" � solu��o.

* Correr o script chrome_cors.bat que se encontra no caminho TDIN-2\BookShopWebsite\scripts